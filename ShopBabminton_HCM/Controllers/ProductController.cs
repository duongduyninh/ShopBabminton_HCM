using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ProductController(IProductService productService)
        {
            _productService = productService;   
        }
        [HttpPost("AddProduct")]
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

        [HttpPut("UpdateProduct")]
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
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("DisableProduct/{productId}")]
        public async Task<IActionResult> DisableProduct(Guid productId)
        {
            try 
            {
                var result = await _productService.DisableProduct(productId);
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

        [HttpGet("GetAllProductActive")]
        public async Task<IActionResult> GetAllProductActive()
        {
            try
            {
                var result = await _productService.GetAllProductActive();
                return Ok(result);
            }catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GetAllProductInactive")]
        public async Task<IActionResult> GetAllProductInactive()
        {
            try
            {
                var result = await _productService.GetAllProductInactive();
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateProductStatus")]
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

        [HttpGet("ProductInfoById/{productId}")]
        public async Task<IActionResult> GetProductInfoById(Guid productId)
        {
            try
            {
                var result = await _productService.GetProductInfoById(productId);
                if (result.Status)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GetProductsByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryId(Guid categoryId) 
        {
            try
            {
                var result = await _productService.GetProductsByCategoryId(categoryId);
                if (result.Status)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
