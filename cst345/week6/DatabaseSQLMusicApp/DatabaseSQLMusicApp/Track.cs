using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSQLMusicApp
{
    
    internal class Track
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string title { get; set; }
        public int Number { get; set; }
        public string video_url { get; set; }
        public string Lyrics { get; set; }

        public Track()
        {
            ID = ObjectId.GenerateNewId().ToString();
        }
    }
}
