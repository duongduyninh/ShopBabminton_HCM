using ShopBabminton_HCM.DTOs.ProductDTO;

namespace ShopBabminton_HCM.Services.ProductService
{
    public interface IProductService
    {
        public Task<AddProductResponse> AddProduct(AddProductRequest model);
        public Task<GetProductInfoByIdResponse> GetProductInfoById(Guid productId);
        public Task<GetProductsByCategoryResponse> GetProductsByCategoryId(Guid categoryId);
        public Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest model);
        public Task<DisableProductResponse> DisableProduct(Guid productId);
        public Task<GetAllProductResponse> GetAllProductByStatus(int status);
        public Task<GetAllProductResponse> GetAllProductByFilter(GetAllProductRequest getAllProductRequest);
        public Task<UpdateProductStatusResponse> UpdateProductStatus(UpdateProductStatusRequest model);
        public Task<SearchProductResponse> SearchProducts(string keySearch);
    }
}
