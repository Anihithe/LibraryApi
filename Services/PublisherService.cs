using System.Collections.Generic;
using LibraryApi.Models;
using MongoDB.Driver;

namespace LibraryApi.Services
{
    public class PublisherService
    {
        private readonly IMongoCollection<Publisher> _publisher;

        public PublisherService(ILibraryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _publisher = database.GetCollection<Publisher>(settings.PublishersCollectionName);
        }

        public List<Publisher> Get() => _publisher.Find(publisher => true).ToList();

        public Publisher GetById(string id) =>
            _publisher.Find(book => book.Id == id).FirstOrDefault();

        public Publisher GetByName(string bookName) =>
            _publisher.Find(book => book.PublisherName == bookName).FirstOrDefault();


        public Publisher Create(Publisher book)
        {
            _publisher.InsertOne(book);
            return book;
        }

        public void Update(string id, Publisher bookIn) =>
            _publisher.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Publisher bookIn) =>
            _publisher.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _publisher.DeleteOne(book => book.Id == id);
    }
}