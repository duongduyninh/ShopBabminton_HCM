using ShopBabminton_HCM.DTOs.CategoryDTO;

namespace ShopBabminton_HCM.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<bool> AddCategoryAsync(AddCategoryDTO model);
    }
}
