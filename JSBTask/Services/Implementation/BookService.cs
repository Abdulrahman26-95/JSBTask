using FluentValidation;
using JSBTask.Dto;
using JSBTask.Entities;
using JSBTask.Persistence;
using JSBTask.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JSBTask.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext db;

        public BookService(ApplicationDbContext db)
        {
            this.db = db;
        }


        public async Task<List<BookDto>> GetAllBooks()
        {
            var books = await db.Books
                                .Select(b => new BookDto()
                                {
                                    id = b.BookId,
                                    name = b.Name,
                                    description = b.Description,
                                    price = b.Price,
                                    stock = b.Stock,
                                    auther = b.Auther,
                                    category = b.Category != null ? b.Category.Name : "لا يوجد قسم",
                                }).ToListAsync();

            return books;
        }

        public async Task<BookDto> GetBookById(int bookId)
        {
            var book = await db.Books
                               .Where(b => b.BookId == bookId)
                               .Select(b => new BookDto()
                               {
                                   id = b.BookId,
                                   name = b.Name,
                                   description = b.Description,
                                   price = b.Price,
                                   stock = b.Stock,
                                   auther = b.Auther,
                                   category = b.Category != null ? b.Category.Name : "لا يوجد قسم",
                               }).FirstOrDefaultAsync();

            return book;
        }

        public async Task<bool> AddNewBook([FromQuery] AddBookDto book)
        {
            #region Validations
            var AdBook = new AddBookDtoValidator();
            var AdBookModel = AdBook.Validate(book);

            if (!AdBookModel.IsValid)
            {
                var errors = AdBookModel.Errors.Select(e => new ValidationErrorMessage
                {
                    PropertyName = e.PropertyName,
                    Message = e.ErrorMessage
                }).FirstOrDefault();

                return false;
            }
            #endregion


            Book newBook = new Book()
            {
                Name = book.bookName,
                Description = book.bookDescription,
                Auther = book.bookAuther,
                Price = book.bookPrice,
                Stock = book.stock,
                CategoryId = book.categoryId,
            };

            await db.Books.AddAsync(newBook);
            var result = await db.SaveChangesAsync();

            if (result > 0)
                return true;

            else
                return false;
        }

        public async Task<bool> UpdateBook(UpdateBookDto updateBook)
        {
            var book = await db.Books.FindAsync(updateBook.bookId);

            if (book is null)
                return false;

            book.Name = updateBook.bookName is not null ? updateBook.bookName : book.Name;
            book.Description = updateBook.bookDescription is not null ? updateBook.bookDescription : book.Description;
            book.Auther = updateBook.bookAuther is not null ? updateBook.bookAuther : book.Auther;
            book.Price = updateBook.bookPrice is not 0 ? updateBook.bookPrice : book.Price;
            book.Stock = updateBook.stock is not 0 ? updateBook.stock : book.Stock;
            book.CategoryId = updateBook.categoryId;

            db.Books.Update(book);
            await db.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteBook(int bookId)
        {
            var book = await db.Books.FindAsync(bookId);

            if (book is null)
                return false;

            else
            {
                db.Books.Remove(book);
                await db.SaveChangesAsync();
                return true;
            }
        }
    }
}
