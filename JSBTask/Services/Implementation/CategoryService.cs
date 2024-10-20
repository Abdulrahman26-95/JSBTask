using JSBTask.Dto;
using JSBTask.Entities;
using JSBTask.Persistence;
using JSBTask.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JSBTask.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext db;

        public CategoryService(ApplicationDbContext db)
        {
            this.db = db;
        }


        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = await db.Categories
                                .Select(b => new CategoryDto()
                                {
                                    categoryId = b.CategoryId,
                                    categoryName = b.Name,
                                    categoryDescription = b.Description,
                                    books = b.Books.Select(book => new BookCategoryDto
                                    {
                                        bookId = book.BookId, 
                                        bookName = book.Name,                                     
                                    }).ToList() 
                                }).ToListAsync();

            return categories;
        }

        public async Task<CategoryDto> GetCategoryById(int categoryId)
        {
            var category = await db.Categories
                               .Where(b => b.CategoryId == categoryId)
                               .Select(b => new CategoryDto()
                               {
                                   categoryId = b.CategoryId,
                                   categoryName = b.Name,
                                   categoryDescription = b.Description,
                                   books = b.Books.Select(book => new BookCategoryDto
                                   {
                                       bookId = book.BookId,
                                       bookName = book.Name,
                                   }).ToList()
                               }).FirstOrDefaultAsync();

            return category;
        }

        public async Task<bool> AddNewCategory(AddCategoryDto category)
        {
            #region Validations
            var categoryDto = new AddCategoryDtoValidator();
            var CategoryModel = categoryDto.Validate(category);

            if (!CategoryModel.IsValid)
            {
                var errors = CategoryModel.Errors.Select(e => new ValidationErrorMessage
                {
                    PropertyName = e.PropertyName,
                    Message = e.ErrorMessage
                }).FirstOrDefault();

                return false;
            }
            #endregion


            Category newCategory = new Category()
            {
                Name = category.categoryName,
                Description = category.categoryDescription,
            };

            await db.Categories.AddAsync(newCategory);
            var result = await db.SaveChangesAsync();

            if (result > 0)
                return true;

            else
                return false;
        }


        public async Task<bool> UpdateCategory(UpdateCategoryDto updateCategory)
        {
            var category = await db.Categories.FindAsync(updateCategory.categoryId);

            if (category is null)
                return false;

            category.Name = updateCategory.categoryName is not null ? updateCategory.categoryName : category.Name;
            category.Description = updateCategory.categoryDescription is not null ? updateCategory.categoryDescription : category.Description;

            db.Categories.Update(category);
            await db.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteCategory(int categoryId)
        {
            var category = await db.Categories.FindAsync(categoryId);

            if (category is null)
                return false;

            if (category.Books?.Count > 0)
                return false;

            else
            {
                db.Categories.Remove(category);
                await db.SaveChangesAsync();
                return true;
            }
        }

    }
}
