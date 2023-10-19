using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace muchik.market.transaction.domain.entities
{
    public class Transactions
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string id { get; set; }

        [BsonElement("id_transaction")]
        public string Id_Transaction { get; set; } = Guid.NewGuid().ToString("N");

        [BsonElement("id_invoice")]
        public string Id_Invoice { get; set; } = null!;

        [BsonElement("amount")]
        public decimal Amount { get; set;}

        [BsonElement("date")]
        public string Date { get; set; } = null!;
    }
}