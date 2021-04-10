using System.Collections.Generic;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet, Route("list")]
        public ActionResult<List<Book>> Get() =>
            _bookService.Get();

        [HttpGet("{id:length(24)}", Name = nameof(GetById))]
        [Route("id")]
        public ActionResult<Book> GetById(string id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpGet("{isbn:length(13)}", Name = nameof(GetByIsbn))]
        [Route("isbn")]
        public ActionResult<Book> GetByIsbn(string isbn)
        {
            var book = _bookService.GetByIsbn(isbn);
            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpGet("{name}", Name = nameof(GetByName))]
        [Route("name")]
        public ActionResult<Book> GetByName(string name)
        {
            var book = _bookService.GetByName(name);
            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            _bookService.Create(book);
            return CreatedAtRoute("GetById", new { id = book.Id.ToString() }, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Book bookIn)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookService.Update(id, bookIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookService.Remove(book.Id);
            return NoContent();
        }
    }
}