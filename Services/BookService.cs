using System.Collections.Generic;
using LibraryApi.Models;
using MongoDB.Driver;

namespace LibraryApi.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(ILibraryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public List<Book> Get() => _books.Find(book => true).ToList();

        public Book GetById(string id) =>
            _books.Find(book => book.Id == id).FirstOrDefault();

        public Book GetByIsbn(string isbn) =>
            _books.Find(book => book.Isbn == isbn).FirstOrDefault();

        public Book GetByName(string bookName) =>
            _books.Find(book => book.BookName == bookName).FirstOrDefault();


        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Book bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Book bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);

    }
}