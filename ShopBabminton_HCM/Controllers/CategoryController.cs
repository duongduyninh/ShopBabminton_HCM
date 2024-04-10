using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBabminton_HCM.DTOs.CategoryDTO;
using ShopBabminton_HCM.Models.Entities;
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
        public async Task<IActionResult> AddCategory(AddCategoryRequest addCategory)
        {
            try
            {
                var result = await _categoryService.AddCategoryAsync(addCategory);
                if (result.Status)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch { return StatusCode(500); }
        }
       
        [HttpDelete("DeleteCategory/{CategoryId}")]
        public async Task<IActionResult> DeleteCategory(Guid CategoryId)
        {
            try
            {
                var result = await _categoryService.DeleteCategoryAsync(CategoryId);
                if (result.Status)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch { return StatusCode(500); }
        }
      
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest updateCategory)
        {
            try
            {
                var result = await _categoryService.UpdateCategoryAsync(updateCategory);
                if (result.Status)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch { return StatusCode(500); }
        }

    }
}
