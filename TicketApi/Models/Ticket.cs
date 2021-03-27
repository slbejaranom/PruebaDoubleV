using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TicketApi.Models{
    public class Ticket{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("id")]
        public string id { get; set; }

        public string usuario { get; set; }

        public string fechaCreacion { get; set; }

        public string fechaActualizacion { get; set; }

        public string status { get; set; }
    }
}