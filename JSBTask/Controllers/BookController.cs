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

            if (result)
                return Ok("تم الاضافة بنجاح");
            else
                return Ok("حدث خطأ ما أثناء الاضافة");
        }


        [HttpPut(ApiRoutes.Book.UpdateBook)]
        public async Task<IActionResult> UpdateBook([FromQuery] UpdateBookDto book)
        {
            var result = await _bookService.UpdateBook(book);

            if (result)
                return Ok("تم التعديل بنجاح");
            else
                return Ok("حدث خطأ ما أثناء التعديل");
        }


        [HttpDelete(ApiRoutes.Book.DeleteBook)]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var result = await _bookService.DeleteBook(bookId);

            if (result)
                return Ok("تم الحذف بنجاح");
            else
                return Ok("حدث خطأ ما أثناء الحذف");
        }

    }
}
