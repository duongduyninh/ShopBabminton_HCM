using ShopBabminton_HCM.DTOs.CategoryDTO;

namespace ShopBabminton_HCM.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<bool> CheckCategoryIdValidAsync(Guid model);
        public Task<bool> CheckCategoryNameValidAsync(string model);
        public Task<CategoryInfo> AddCategoryAsync(AddCategoryRequest model);
        public Task<bool> DeleteCategoryAsync(Guid categoryId);
        public Task<CategoryInfo> UpdateCategoryAsync(UpdateCategoryRequest model);

    }
}
