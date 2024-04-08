using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBabminton_HCM.DTOs.ProductDTO;
using ShopBabminton_HCM.Services.ProductService;

namespace ShopBabminton_HCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;   
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductDTO addProduct)
        {
            try
            {
                var result = await _productService.AddProduct(addProduct);
                return Ok(result);

            }catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetProductInfo")]
        public async Task<IActionResult> GetProductInfo(Guid productId)
        {
            try
            {
                var result = await _productService.GetProduct(productId);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetListProduct")]
        public async Task<IActionResult> GetListProduct( )
        {
            try
            {
                var result = await _productService.GetListProduct();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetProductsByCategory")]
        public async Task<IActionResult> GetProductsByCategory(Guid categoryId) 
        {
            try
            {
                var result = await _productService.GetProductsByCategory(categoryId);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
