using JSBTask.Constants;
using JSBTask.Dto;
using JSBTask.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSBTask.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet(ApiRoutes.Book.GetAllBooks)]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _bookService.GetAllBooks();

            return Ok(result);
        }

        [HttpGet(ApiRoutes.Book.GetBookById)]
        public async Task<IActionResult> GetBookById( int bookId)
        {
            var result = await _bookService.GetBookById(bookId);

            return Ok(result);
        }


        [HttpPost(ApiRoutes.Book.AddNewBook)]
        public async Task<IActionResult> AddNewBook([FromQuery] AddBookDto book)
        {
            var result = await _bookService.AddNewBook(book);

            return Ok(result);
        }


        [HttpPut(ApiRoutes.Book.UpdateBook)]
        public async Task<IActionResult> UpdateBook([FromQuery] UpdateBookDto book)
        {
            var result = await _bookService.UpdateBook(book);

            return Ok(result);
        }


        [HttpDelete(ApiRoutes.Book.DeleteBook)]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var result = await _bookService.DeleteBook(bookId);

            return Ok(result);
        }

    }
}
