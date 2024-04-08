using ShopBabminton_HCM.DTOs.ProductDTO;

namespace ShopBabminton_HCM.Services.ProductService
{
    public interface IProductService
    {
        public Task<AddProductResultDTO> AddProduct(AddProductDTO model);
        public Task<InfoProductDTO> GetProduct(Guid ProductId);
        public Task<List<InfoProductDTO>> GetListProduct();
        public Task<List<InfoProductDTO>> GetProductsByCategory(Guid model);
    }
}
