using JSBTask.Constants;
using JSBTask.Dto;
using JSBTask.Services.Contract;
using JSBTask.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSBTask.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet(ApiRoutes.Category.GetAllCategories)]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllCategories();

            return Ok(result);
        }


        [HttpGet(ApiRoutes.Category.GetCategoryById)]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var result = await _categoryService.GetCategoryById(categoryId);

            return Ok(result);
        }


        [HttpPost(ApiRoutes.Category.AddNewCategory)]
        public async Task<IActionResult> AddNewCategory([FromQuery] AddCategoryDto category)
        {
            var result = await _categoryService.AddNewCategory(category);

            if (result)
                return Ok("تم الاضافة بنجاح");
            else
                return Ok("حدث خطأ ما أثناء الاضافة");
        }


        [HttpPut(ApiRoutes.Category.UpdateCategory)]
        public async Task<IActionResult> UpdateCategory([FromQuery] UpdateCategoryDto book)
        {
            var result = await _categoryService.UpdateCategory(book);

            if (result)
                return Ok("تم التعديل بنجاح");
            else
                return Ok("حدث خطأ ما أثناء التعديل");

        }


        [HttpDelete(ApiRoutes.Category.DeleteCategory)]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var result = await _categoryService.DeleteCategory(categoryId);

            if (result)
                return Ok("تم الحذف بنجاح");
            else
                return Ok("حدث خطأ ما أثناء الحذف");
        }
    }
}
