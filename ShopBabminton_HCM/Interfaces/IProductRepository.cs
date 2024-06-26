﻿using ShopBabminton_HCM.DTOs.ProductDTO;

namespace ShopBabminton_HCM.Interfaces
{
    public interface IProductRepository
    {
        public Task<ProductInfo> AddProductAsync(AddProductRequest model);
        public Task<ProductInfoById> GetProductAsync(Guid models);
        public Task<List<ProductInfoById>> GetListProductAsync();
        public Task<List<ProductInfoById>> GetProductsByCategoryIdAsync(Guid model);
        public Task<bool> CheckProductNameValidAsync(string models);
        public Task<bool> CheckProductIdValidAsync(Guid models);
        public Task<bool> CheckProdcutQuantityAsync(Guid models);
        public Task<ProductInfo> UpdateProductAsync(UpdateProductRequest model);
        public Task<bool> DisableProductAsync(Guid productId);
        public Task<List<ProductInfoById>> GetAllProductByStatusAsync(int status);
        public Task<bool> UpdateProductStatusAsync(UpdateProductStatusRequest model);
        public Task<ProductInfoById> GetProductInfoByIdAsync(Guid productId);
        public Task<List<ProductInfoById>> GetAllProducts();
        public Task<List<ProductInfoById>> GetAllProductByFilter(GetAllProductRequest models);
        public Task<List<ProductInfoById>> SearchProductsAsync(string KeySearch);
    }
}