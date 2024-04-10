using AutoMapper;
using ShopBabminton_HCM.DTOs.ProductDTO;
using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.AutoMappers
{
    public class ProductMapper :Profile
    {
        public ProductMapper() 
        { 
            CreateMap<Product , AddProductRequest>().ReverseMap();
            CreateMap<Product , UpdateProductRequest>().ReverseMap();
            CreateMap<Product , ProductInfo>().ReverseMap();    
           
        }
    }
}
