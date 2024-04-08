using ShopBabminton_HCM.DTOs.ProductDTO;

namespace ShopBabminton_HCM.Interfaces
{
    public interface IProductRepository
    {
        public Task<AddProductResultDTO> AddProductAsync(AddProductDTO model);
        public Task<InfoProductDTO> GetProductAsync(Guid models);
        public Task<List<InfoProductDTO>> GetListProductAsync();
        public Task<List<InfoProductDTO>> GetProductsByCategoryAsync(Guid model);
        public Task<bool> CheckProductExistAsync(string models);
        public Task<bool> CheckProductIdExistAsync(Guid models);
        

    }
}
