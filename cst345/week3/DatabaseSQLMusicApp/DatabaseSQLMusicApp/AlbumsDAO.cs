using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSQLMusicApp
{
    internal class AlbumsDAO
    {
        public List<Album> albums = new List<Album>();
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=music;";

        public List<Album> GetAllAlbums()
        {
            List<Album> albums = new List<Album>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM ALBUMS", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) 
                {
                    Album a = new Album
                    {
                        ID = reader.GetInt32(0),
                        AlbumName = reader.GetString(1),
                        ArtistName = reader.GetString(2),
                        Year = reader.GetInt32(3),
                        ImageURL = reader.GetString(4),
                        Description = reader.GetString(5),
                    };

                    a.Tracks = GetTracksForAlbum(a.ID);

                    albums.Add(a);
                }
            }

            connection.Close();

            return albums;
        }

        public List<Track> GetTracksForAlbum(int albumID)
        {
            List<Track> tracks = new List<Track>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM TRACKS WHERE album_id = @albumid";
            command.Parameters.AddWithValue("@albumid", albumID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Track a = new Track
                    {
                        ID = reader.GetInt32(1),
                        Name = reader.GetString(2),
                        Number = reader.GetInt32(3),
                        VideoURL = reader.GetString(4),
                        Lyrics = reader.GetString(5)
                    };

                    tracks.Add(a);
                }
            }

            connection.Close();

            return tracks;
        }

        public List<JObject> GetTracksForAlbumUsingJoin(int albumID)
        {
            List<JObject> tracks = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT tracks.tracks_id, albums.album_title, tracks.title, tracks.number, tracks.video_url, tracks.lyrics, albums.id FROM TRACKS  JOIN albums ON tracks.album_id = albums.id WHERE album_id = @albumid";
            command.Parameters.AddWithValue("@albumid", albumID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject newTrack = new JObject();
                    
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        newTrack.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }

                    tracks.Add(newTrack);
                }
            }

            connection.Close();

            return tracks;
        }

        public List<Album> SearchTitles(string search)
        {
            List<Album> albums = new List<Album>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            string searchPhrase = "%" + search + "%";

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM ALBUMS WHERE TITLE LIKE @search";
            command.Parameters.AddWithValue("@search", searchPhrase);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Album a = new Album
                    {
                        ID = reader.GetInt32(0),
                        AlbumName = reader.GetString(1),
                        ArtistName = reader.GetString(2),
                        Year = reader.GetInt32(3),
                        ImageURL = reader.GetString(4),
                        Description = reader.GetString(5),
                    };
                    albums.Add(a);
                }
            }

            connection.Close();

            return albums;
        }

        internal int AddOneALbum(Album album)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO albums (`title`, `artist`, `year`, `image`, `description`) VALUES (@albumTitle, @artistName, @year, @imageURL, @description)", connection);

            command.Parameters.AddWithValue("@albumTitle", album.AlbumName);
            command.Parameters.AddWithValue("@artistName", album.ArtistName);
            command.Parameters.AddWithValue("@year", album.Year);
            command.Parameters.AddWithValue("@imageURL", album.ImageURL);
            command.Parameters.AddWithValue("@description", album.Description);

            int newRows = command.ExecuteNonQuery();

            connection.Close();

            return newRows;
        }

        internal int DeleteTrack(int trackID)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "DELETE FROM TRACKS WHERE TRACKS.tracks_id = @trackID";
            command.Parameters.AddWithValue("@trackID", trackID);
            command.Connection = connection;

            int result = command.ExecuteNonQuery();
            connection.Close();

            return result;
        }
    }
}
