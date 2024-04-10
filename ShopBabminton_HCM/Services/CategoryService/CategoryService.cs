
using Microsoft.EntityFrameworkCore;
using ShopBabminton_HCM.Data;
using ShopBabminton_HCM.DTOs.CategoryDTO;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Models.Entities;
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
        public async Task<AddCategoryResponse> AddCategoryAsync(AddCategoryRequest addCategory)
        {
            var checkCategoryName = await _categoryRepository.CheckCategoryNameValidAsync(addCategory.CategoryName);
            if(checkCategoryName) { return new AddCategoryResponse { Status = false, Message = "Category name valid" }; }

            var result = await _categoryRepository.AddCategoryAsync(addCategory);
            if (result != null)
            {
                return new AddCategoryResponse { Status = true, Message = "Add Category success" };
            }
            else
            {
                return new AddCategoryResponse { Status = false,Message = "Add Category false"};
            }
        
        }

        public async Task<DeleteCategoryResponse> DeleteCategoryAsync(Guid CategoryId)
        {
            bool checkCategoryIdValid = await _categoryRepository.CheckCategoryIdValidAsync(CategoryId);
            if (!checkCategoryIdValid) { return new DeleteCategoryResponse { Status = false , Message = "Category id invalid" }; }    

            bool result = await _categoryRepository.DeleteCategoryAsync(CategoryId);
            if (!result) { return new DeleteCategoryResponse { Status = false, Message = "In the category of extant products" }; }

            return new DeleteCategoryResponse { Status = true, Message = "Delete category success" };
        }

        public async Task<UpdateCategoryResponse> UpdateCategoryAsync(UpdateCategoryRequest updateCategory)
        {

            bool checkCategoryIdValid = await _categoryRepository.CheckCategoryIdValidAsync(updateCategory.CategoryId);
            if (!checkCategoryIdValid) { return new UpdateCategoryResponse { Status = false, Message = "Category id invalid" }; }

            var result = await _categoryRepository.UpdateCategoryAsync(updateCategory);
            if (result != null) 
            { return new UpdateCategoryResponse { Status = true, Message = "Update Category true", Category = result }; }
            else { return new UpdateCategoryResponse { Status = false, Message = "Category name valid" }; }

        }
    }
}
