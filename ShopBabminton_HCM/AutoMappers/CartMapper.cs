using AutoMapper;
using ShopBabminton_HCM.DTOs.CartDTO;
using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.AutoMappers
{
    public class CartMapper : Profile 
    {
        public CartMapper()
        {
            CreateMap<CartDetail , AddToCartDTO>().ReverseMap();
        }
    }
}
