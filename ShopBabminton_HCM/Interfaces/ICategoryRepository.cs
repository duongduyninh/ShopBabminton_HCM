using ShopBabminton_HCM.DTOs.CategoryDTO;

namespace ShopBabminton_HCM.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<bool> CheckCategoryIdExistAsync(Guid model);
        public Task<bool> CheckCategoryNameExistAsync(string model);
        public Task<bool> AddCategoryAsync(AddCategoryDTO model);

    }
}
