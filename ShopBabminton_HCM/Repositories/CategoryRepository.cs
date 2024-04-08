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
        public async Task<bool> CheckCategoryIdExistAsync(Guid categoryId)
        {
            return await _context.Categorys.AnyAsync(x => x.Id == categoryId);
        }
        public async Task<bool> CheckCategoryNameExistAsync(string nameCategory)
        {
            var checkCategoryName = await _context.Categorys.AnyAsync(x => x.NameCategory == nameCategory);
            return checkCategoryName;
           
        }
        public async Task<bool> AddCategoryAsync(AddCategoryDTO addCategory)
        {
            try
            {
                var newCatrgory = _mapper.Map<Category>(addCategory);
                await _context.Categorys.AddAsync(newCatrgory);
                _context.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }

    }
}
