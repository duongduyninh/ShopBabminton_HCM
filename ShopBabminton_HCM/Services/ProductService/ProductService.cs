using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBabminton_HCM.Data;
using ShopBabminton_HCM.DTOs.ProductDTO;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Models.Entities;
using ShopBabminton_HCM.Repositories;
using System.Text.RegularExpressions;

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
        public async Task<AddProductResponse> AddProduct(AddProductRequest addProduct)
        {

            if (addProduct == null)
            {
                return new AddProductResponse
                {
                    Message = " Empty data or error data  ",
                    Status = false 
                };
            }

            bool checkProductName = await _productRepository.CheckProductNameValidAsync(addProduct.ProductName);
            if (checkProductName) 
            {
                return new AddProductResponse
                {
                    Message = " Product name valid ",
                    Status = false
                };
            }

            bool checkCategoryId = await _categoryRepository.CheckCategoryIdValidAsync(addProduct.CategoryId); ;
            if (!checkCategoryId) 
            {
                return new AddProductResponse
                {
                    Message = " CategoryId invalid ",
                    Status = false
                };
            }
                
            var result = await _productRepository.AddProductAsync(addProduct);
            return new AddProductResponse
            {
                Status = true,
                ProductInfo = result,
            };
        }

        public async Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest updateProduct)
        {
            if (updateProduct == null)
            {
                return new UpdateProductResponse
                {
                    Status = false,
                    Message = "empty data",
                    ProductInfo = null
                };
            }

            bool checkProductIdValid = await _productRepository.CheckProductIdValidAsync(updateProduct.ProductId);
            if(!checkProductIdValid)
            {
                return new UpdateProductResponse
                {
                    Status = false ,
                    Message = "ProductId InValid",
                    ProductId = updateProduct.ProductId,
                    ProductInfo = null 
                };
            }

            var result = await _productRepository.UpdateProductAsync(updateProduct);
            return new UpdateProductResponse
            {
                Status = true,
                ProductId = updateProduct.ProductId,
                ProductInfo = result
            };
        }

        public async Task<List<ProductInfoById>> GetListProduct()
        {
            try
            {
                var result = await _productRepository.GetListProductAsync();
                return result;

            }
            catch
            {
                return new List<ProductInfoById>();
            }
        }

        public async Task<ProductInfoById> GetProduct(Guid ProductId)
        {
            try
            {
                var result = await _productRepository.GetProductAsync(ProductId);
                 return result;

            }catch
            {
                return new ProductInfoById();
            }
        }

        public async Task<GetProductInfoByIdResponse> GetProductInfoById(Guid productId)
        {
            var returnTrue = new GetProductInfoByIdResponse { Status = true , ProductId = productId };
            var returnFalse = new GetProductInfoByIdResponse { Status = false, ProductId = productId };

            bool checkProductIdValid = await _productRepository.CheckProductIdValidAsync(productId);
            if (!checkProductIdValid)
            {
                returnFalse.Message = "Product id invalid";
                return returnFalse;
            }

            var result = await _productRepository.GetProductInfoByIdAsync(productId);
            if (result != null)
            {
                returnTrue.Message = "Get Info Product success";
                returnTrue.Product = result;
                return returnTrue;
            }
            else
            {
                returnFalse.Message = "Get Info Product false";
                return returnFalse;
            }
        }

        public async Task<GetProductsByCategoryResponse> GetProductsByCategoryId(Guid categoryId)
        {
            var checkCategoryIdValid = await _categoryRepository.CheckCategoryIdValidAsync(categoryId); 
            if (!checkCategoryIdValid) 
            {
                return new GetProductsByCategoryResponse { Status = false, Message ="Category id invalid"  };
            }
            
            var result = await _productRepository.GetProductsByCategoryIdAsync(categoryId); 
            if (result != null) 
            {
                return new GetProductsByCategoryResponse 
                {
                    Status = true,
                    Message = "Get products by category id success",
                    product = result
                };
            }
            else
            {
                return new GetProductsByCategoryResponse { Status = false, Message = "Get products by category id false" };
            }
        }

        public async Task<DisableProductResponse> DisableProduct(Guid productId)
        {
            bool checkProductIdValid = await _productRepository.CheckProductIdValidAsync(productId);
            if(!checkProductIdValid)
            {
                return new DisableProductResponse
                {
                    Status = false,
                    Message = "Prodcut id invalid"
                };
            }

            bool result = await _productRepository.DisableProductAsync(productId);
            if(result)
            {
                return new DisableProductResponse
                {
                    Status = true,
                    Message = "Disable product success"
                };
            }
            else
            {
                return new DisableProductResponse
                {
                    Status = false,
                    Message = "Disable product false"
                };
            }
        }

        public async Task<GetAllProductResponse> GetAllProductByStatus(int status)
        {
            var result = await _productRepository.GetAllProductByStatusAsync(status);
            if(result != null)
            {
                return new GetAllProductResponse
                {
                    Status = true,
                    Message = " Get all product by status success",
                    ProductInfo = result
                };
            }

            return new GetAllProductResponse
            {
                Status = false,
                Message = " Get all product by status success",
                ProductInfo = null
            };
        }

        public async Task<UpdateProductStatusResponse> UpdateProductStatus(UpdateProductStatusRequest updateProduct)
        {
            bool checkProductIdValid = await _productRepository.CheckProductIdValidAsync(updateProduct.productId);
            if(!checkProductIdValid) 
            {
                return new UpdateProductStatusResponse
                { 
                    Status = false,
                    Message = "Product id invalid",
                    ProductId = updateProduct.productId 
                };
            }

            bool result = await _productRepository.UpdateProductStatusAsync(updateProduct);
            if(result) 
            {
                return new UpdateProductStatusResponse 
                {
                    Status = true,
                    Message = " Update status product success",
                    ProductId = updateProduct.productId
                };
            }
            else
            {
                return new UpdateProductStatusResponse
                {
                    Status = false,
                    Message = " Update status product false",
                    ProductId = updateProduct.productId
                };
            }
        }

        public async Task<GetAllProductResponse> GetAllProductByFilter(GetAllProductRequest getProductByFilter)
        {

            if (getProductByFilter == null ||
                ( getProductByFilter.CategoryId == null
                && getProductByFilter.PriceFrom == null
                && getProductByFilter.PriceTo == null))
            {
                var result = await _productRepository.GetAllProducts();
                if (result != null)
                {
                    return new GetAllProductResponse
                    {
                        Status = true,
                        Message = "Get product success",
                        ProductInfo = result
                    };
                }
            }
            else
            {
                var result = await _productRepository.GetAllProductByFilter(getProductByFilter);
                if (result != null)
                {
                    return new GetAllProductResponse
                    {
                        Status = true,
                        Message = "Get product success",
                        ProductInfo = result
                    };
                }
                else
                {
                    return new GetAllProductResponse
                    {
                        Status = false,
                        Message = "There are no products that match the filter",
                        ProductInfo = null
                    };
                }
            }
            return null;
        }

        public async Task<SearchProductResponse> SearchProducts(string keySearch)
        {
            string pattern = "[^a-zA-Z0-9]";
            Regex regex = new Regex(pattern);

            string keySearchFiltered = regex.Replace(keySearch, "").Trim();

            if (string.IsNullOrEmpty(keySearchFiltered))
            {
                return new SearchProductResponse
                {
                    Status = false,
                    Message = "Invalid search keyword",
                    ProductInfo = null
                };
            }

            var result = await _productRepository.SearchProductsAsync(keySearchFiltered);
            if (result != null)
            {
                return new SearchProductResponse
                {
                    Status = true,
                    Message = "Search true",
                    ProductInfo = result
                };
            }
            else
            {
                return new SearchProductResponse
                {
                    Status = false,
                    Message = "Search true",
                    ProductInfo = result
                };
            }
        }
    }
}
