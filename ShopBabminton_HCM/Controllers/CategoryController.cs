using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBabminton_HCM.DTOs.CategoryDTO;
using ShopBabminton_HCM.Services.CategoryService;

namespace ShopBabminton_HCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(AddCategoryDTO addCategory)
        {
                var result = await _categoryService.AddCategoryAsync(addCategory);
               return Ok(result);
        }
    }
}
