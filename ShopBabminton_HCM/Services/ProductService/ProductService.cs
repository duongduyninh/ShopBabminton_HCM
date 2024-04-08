using Microsoft.EntityFrameworkCore;
using ShopBabminton_HCM.Data;
using ShopBabminton_HCM.DTOs.ProductDTO;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Models.Entities;
using ShopBabminton_HCM.Repositories;

namespace ShopBabminton_HCM.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly DbContextStoreBabmintion _context;

        public ProductService(IProductRepository productRepository
                            , DbContextStoreBabmintion context
                            , ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _context = context;
        }
        public async Task<AddProductResultDTO> AddProduct(AddProductDTO addProduct)
        {
            try
            {
                if (addProduct == null)
                {
                    return new AddProductResultDTO { ErrorMessage = " Empty data " , Status = false };
                }
               
                var newProduct = await _productRepository.AddProductAsync(addProduct);
                return new AddProductResultDTO { ProductId = newProduct.ProductId, Status = true };
            }
            catch (Exception ex)
            {
                return new AddProductResultDTO { ErrorMessage = "Error" + ex.Message , Status = false };
            }

            throw new NotImplementedException();
        }

        public async Task<List<InfoProductDTO>> GetListProduct()
        {
            try
            {
                var result = await _productRepository.GetListProductAsync();
                return result;

            }
            catch (Exception ex)
            {
                return new List<InfoProductDTO>();
            }
        }

        public async Task<InfoProductDTO> GetProduct(Guid ProductId)
        {
            try
            {
                var result = await _productRepository.GetProductAsync(ProductId);
                 return result;

            }catch (Exception ex)
            {
                return new InfoProductDTO();
            }
        }

        public async Task<List<InfoProductDTO>> GetProductsByCategory(Guid categoryId)
        {
            try
            {
                var result = await _productRepository.GetProductsByCategoryAsync(categoryId);
                return result;

            }
            catch (Exception ex)
            {
                return new List<InfoProductDTO>();
            }
        }
    }
}
