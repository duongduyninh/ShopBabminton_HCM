using ShopBabminton_HCM.DTOs.CategoryDTO;

namespace ShopBabminton_HCM.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<AddCategoryResponse> AddCategoryAsync(AddCategoryRequest model);
        public Task<DeleteCategoryResponse> DeleteCategoryAsync(Guid categoryId);
        public Task<UpdateCategoryResponse> UpdateCategoryAsync(UpdateCategoryRequest model);
    }
}
