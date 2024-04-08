
using Microsoft.EntityFrameworkCore;
using ShopBabminton_HCM.Data;
using ShopBabminton_HCM.DTOs.CategoryDTO;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Repositories;

namespace ShopBabminton_HCM.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository
                               ) 
        {
            _categoryRepository = categoryRepository;

        }
        public async Task<bool> AddCategoryAsync(AddCategoryDTO addCategory)
        {
            var checkCategoryName = await _categoryRepository.CheckCategoryNameExistAsync(addCategory.NameCategory);

            if (!checkCategoryName)
            {
                var result = await _categoryRepository.AddCategoryAsync(addCategory);
                return result;
            }
                return false;
        }
    }
}
