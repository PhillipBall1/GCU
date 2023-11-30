using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSQLMusicApp
{
    internal class Album
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string album_title { get; set; }
        public string artist { get; set; }
        public int year { get; set; }
        public string image { get; set; }
        public string description { get; set; }

        public List<Track> Tracks { get; set; }

        public override string ToString()
        {
            return "ID: " + ID + " Title: " + album_title + " Artist: " + artist + " Year: " + year;
        }
    }
}
