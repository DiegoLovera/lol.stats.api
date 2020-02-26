using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lol.stats.api.Dtos
{
    public class Control
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("AccountId")]
        public string AccountId { get; set; }

        [BsonElement("LastGameTime")]
        public long LastGameTime { get; set; }

        [BsonElement("Queue")]
        public int Queue { get; set; }
    }
}
