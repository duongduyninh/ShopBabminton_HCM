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
        public Task<List<GetAllProductResponse>> GetAllProductActive();
        public Task<List<GetAllProductResponse>> GetAllProductInactive();
        public Task<UpdateProductStatusResponse> UpdateProductStatus(UpdateProductStatusRequest model);
    }
}
