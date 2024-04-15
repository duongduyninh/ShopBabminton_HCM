using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ShopBabminton_HCM.DTOs.ProductDTO;
using ShopBabminton_HCM.Models.Entities;
using ShopBabminton_HCM.Services.ProductService;

namespace ShopBabminton_HCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService
                                ,ILogger<ProductController> logger)
        {
            _productService = productService;   
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductRequest addProduct)
        {
            try
            {
                var result = await _productService.AddProduct(addProduct);
                if (result.Status)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }

            }catch { return StatusCode(500); }
        }

        [HttpDelete("{productid}")]
        public async Task<IActionResult> DisableProduct(Guid productid)
        {
            try 
            {
                var result = await _productService.DisableProduct(productid);
                if (result.Status) 
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }catch { return StatusCode(500); }
        }

        [HttpGet("products/filter")]
        public async Task<IActionResult> GetAllProductByFilter([FromQuery] GetAllProductRequest filter)
        {
            try
            {
                var result = await _productService.GetAllProductByFilter(filter);
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

        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts(string keySearch)
        {
            try
            {
                var result = await _productService.SearchProducts(keySearch);
                if (result.Status)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }catch { return StatusCode(500); }
        }

        [HttpGet("status/{statusid}")]
        public async Task<IActionResult> GetAllProductByStatus(int statusid)
        {
            try
            {
              var result = await _productService.GetAllProductByStatus(statusid);
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

        [HttpGet("{productid}/details")]
        public async Task<IActionResult> GetProductInfoById(Guid productid)
        {
            try
            {
                var result = await _productService.GetProductInfoById(productid);
                if (result.Status)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        [HttpGet("categoty/{categoryid}")]
        public async Task<IActionResult> GetProductsByCategoryId(Guid categoryid) 
        {
            try
            {
                var result = await _productService.GetProductsByCategoryId(categoryid);
                if (result.Status)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest updateProduct)
        {
            try
            {
                var result = await _productService.UpdateProduct(updateProduct);
                if (result.Status)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("update-productstatus")]
        public async Task<IActionResult> UpdateProductStatus(UpdateProductStatusRequest updateProduct)
        {
            try 
            {
                var result = await _productService.UpdateProductStatus(updateProduct);
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
