using JSBTask.Dto;

namespace JSBTask.Services.Contract
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooks();

        Task<BookDto> GetBookById(int bookId);

        Task<bool> AddNewBook(AddBookDto book);

        Task<bool> UpdateBook(UpdateBookDto updateBook);

        Task<bool> DeleteBook(int bookId);
    }
}
