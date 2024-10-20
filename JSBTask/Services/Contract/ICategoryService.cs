using JSBTask.Dto;
using JSBTask.Entities;

namespace JSBTask.Services.Contract
{
    public interface ICategoryService
    {

        Task<List<CategoryDto>> GetAllCategories();

        Task<CategoryDto> GetCategoryById(int categoryId);

        Task<bool> AddNewCategory(AddCategoryDto category);

        Task<bool> UpdateCategory(UpdateCategoryDto updateCategory);

        Task<bool> DeleteCategory(int categoryId);


    }
}
