using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace LibraryApi.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Isbn { get; set; }
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string BookName { get; set; }
        //Todo: Create & use Author class
        //Todo : Multiple Authors ? Illustrator(s) ?
        public string Author { get; set; }
        //Todo: Create & use Editor class
        public string Editor { get; set; }
    }
}