using Microsoft.AspNetCore.Mvc;
using ShopBook187.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopBook187.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static readonly List<BookDTO> _books = new List<BookDTO>
        {
            new BookDTO { Id = Guid.NewGuid(), Title = "Book 1", Author = "Author 1", Name = "Name 1", Price = 10.99m },
            new BookDTO { Id = Guid.NewGuid(), Title = "Book 2", Author = "Author 2", Name = "Name 2", Price = 15.99m },
            // Thêm dữ liệu sách khác nếu cần
        };

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(Guid id)
        {
            var book = _books.Find(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(BookDTO book)
        {
            book.Id = Guid.NewGuid();
            _books.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id, BookDTO book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Name = book.Name;
            existingBook.Price = book.Price;

            return Ok(existingBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            _books.Remove(book);
            return Ok(book);
        }
    }
}
