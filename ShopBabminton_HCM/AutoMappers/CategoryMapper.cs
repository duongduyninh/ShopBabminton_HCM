using AutoMapper;
using ShopBabminton_HCM.DTOs.CategoryDTO;
using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.AutoMappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper() 
        {
            CreateMap<Category, AddCategoryDTO>().ReverseMap();
        }
    }
}
