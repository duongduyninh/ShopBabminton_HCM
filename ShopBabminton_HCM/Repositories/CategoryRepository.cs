using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ShopBabminton_HCM.Data;
using ShopBabminton_HCM.DTOs.CategoryDTO;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper _mapper;
        private readonly DbContextStoreBabmintion _context;

        public CategoryRepository(DbContextStoreBabmintion context
                                    , IMapper mapper) 
        {
            _mapper = mapper;
            _context = context;
        } 
      
        public async Task<CategoryInfo> AddCategoryAsync(AddCategoryRequest addCategory)
        {
            try
            {
                var addToCategory = _mapper.Map<Category>(addCategory);
                await _context.Categorys.AddAsync(addToCategory);
                await _context.SaveChangesAsync();

                return _mapper.Map<CategoryInfo>(addCategory);

            }catch { return null; }
            
        }

        public async Task<bool> DeleteCategoryAsync(Guid categoryId)
        {
            
            var checkProductValidInCategory = await _context.Products.AnyAsync(x => x.CategoryId == categoryId);
            if (checkProductValidInCategory)
            {
                return false; 
            }

            var categoryToRemove = await _context.Categorys.FindAsync(categoryId);
            _context.Categorys.Remove(categoryToRemove);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<CategoryInfo> UpdateCategoryAsync(UpdateCategoryRequest updateCategory)
        {
            try
            {
                var category = await _context.Categorys.FindAsync(updateCategory.CategoryId);
                _mapper.Map(updateCategory, category);
                await _context.SaveChangesAsync();

                return _mapper.Map<CategoryInfo>(updateCategory);
            }
            catch {  return null; }
        }

        public async Task<bool> CheckCategoryIdValidAsync(Guid categoryId)
        {
            return await _context.Categorys.AnyAsync(x => x.Id == categoryId);
        }

        public async Task<bool> CheckCategoryNameValidAsync(string categoryName)
        {
            return await _context.Categorys.AnyAsync(x => x.CategoryName == categoryName);
        }

    }
}
