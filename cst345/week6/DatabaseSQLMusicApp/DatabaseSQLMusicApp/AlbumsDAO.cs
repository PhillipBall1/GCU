using MongoDB.Driver;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatabaseSQLMusicApp
{
    internal class AlbumsDAO
    {
        private const string CONNECTION = "mongodb+srv://MyAtlasDBUser:MyAtlas-001@cluster0.rdbbu6f.mongodb.net/?retryWrites=true&w=majority";

        private const string DATABASENAME = "musicDatabase";

        private const string ALBUMSCOLLECTION = "albums";

        private MongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<Album> albumCollection;

        public AlbumsDAO()
        {
            client = new MongoClient(CONNECTION);
            database = client.GetDatabase(DATABASENAME);
            albumCollection = database.GetCollection<Album>(ALBUMSCOLLECTION);
        }

        public List<Album> GetAll() { return albumCollection.Find(x => true).ToList(); }

        public Album GetOne(string id) { return albumCollection.Find(x => x.ID == id).First(); }

        public void AddOne(Album album) { albumCollection.InsertOne(album); }

        internal List<Album> Search(string term) { return albumCollection.Find(x => x.album_title.ToLower().Contains(term.ToLower())).ToList(); }

        internal int DeleteOne(string item) { return (int)albumCollection.DeleteOne(x => x.ID == item).DeletedCount; }

        internal Album AddTrackToAlbum(Album recievingAlbum, Track newTrack)
        {
            if (recievingAlbum.Tracks == null) recievingAlbum.Tracks = new List<Track>();
            recievingAlbum.Tracks.Add(newTrack);
            albumCollection.FindOneAndReplace(a => a.ID == recievingAlbum.ID, recievingAlbum);
            return recievingAlbum;
        }

        internal bool DeleteOneTrack(Album selectedAlbum, string trackId)
        {
            Track track = selectedAlbum.Tracks.Find(x => x.ID == trackId);
            bool result = selectedAlbum.Tracks.Remove(track);
            albumCollection.FindOneAndReplace(a => a.ID == selectedAlbum.ID, selectedAlbum);

            return result;
        }
    }
}
