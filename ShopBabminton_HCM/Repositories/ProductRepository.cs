using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopBabminton_HCM.Data;
using ShopBabminton_HCM.DTOs.ProductDTO;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Models.Entities;

namespace ShopBabminton_HCM.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContextStoreBabmintion _context;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public ProductRepository(DbContextStoreBabmintion context
                                , IMapper mapper
                                , ICategoryRepository categoryRepository)
        {
            _context = context;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<AddProductResultDTO> AddProductAsync(AddProductDTO addProduct)
        {
            try
            {
                var checkProductExistAsync = await CheckProductExistAsync(addProduct.ProductName);
                if (checkProductExistAsync)
                {
                    return new AddProductResultDTO { Status = false, ErrorMessage = "Product valid" };
                }

                var categoryValid = await _categoryRepository.CheckCategoryIdExistAsync(addProduct.CategoryId);
                if (categoryValid)
                {
                    var newProduct = _mapper.Map<Product>(addProduct);
                    var productId = await _context.Products.AddAsync(newProduct);
                    _context.SaveChanges();
                    return new AddProductResultDTO { ProductId = productId.Entity.Id, Status = true };
                }
                else
                {
                    return new AddProductResultDTO { Status = false, ErrorMessage = "Invalid category id" };
                }
            }
            catch (Exception ex)
            {
                return new AddProductResultDTO {  Status = false , ErrorMessage = ex.Message };
            }
        }

        public async Task<InfoProductDTO> GetProductAsync(Guid productId)
        {
            try
            {
                bool checkProductExistAsync = await CheckProductIdExistAsync(productId);
                if (!checkProductExistAsync)
                {
                    return new InfoProductDTO();
                }

                var getInfoProduct = await (from products in _context.Products
                                      join categorys in _context.Categorys on products.CategoryId equals categorys.Id
                                      where products.Id == productId
                                      select new InfoProductDTO
                                      {
                                          ProductId = products.Id,
                                          NameProduct = products.ProductName,
                                          CategoryName = categorys.NameCategory,
                                          Description = products.Description,
                                          Quantity = products.Quantity, 
                                      }).FirstOrDefaultAsync();
                return getInfoProduct; 
            }
            catch (Exception ex)
            {
                return new InfoProductDTO();
            }
        }

        public async Task<List<InfoProductDTO>> GetListProductAsync()
        {
            try
            {
                var getListInfoProducts = await (from products in _context.Products
                                              join categorys in _context.Categorys on products.CategoryId equals categorys.Id
                                              select new InfoProductDTO
                                              {
                                                  ProductId = products.Id,
                                                  NameProduct = products.ProductName,
                                                  CategoryName = categorys.NameCategory,
                                                  Description = products.Description,
                                                  Quantity = products.Quantity
                                              }).ToListAsync();

                return getListInfoProducts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<InfoProductDTO>> GetProductsByCategoryAsync(Guid categoryId)
        {

            try
            {
                var categoryValid = await _categoryRepository.CheckCategoryIdExistAsync(categoryId);
                if (!categoryValid)
                {
                  return new List<InfoProductDTO>();
                }
                var getInfoProduct = await (from products in _context.Products
                                            join categorys in _context.Categorys on products.CategoryId equals categorys.Id
                                            where categorys.Id == categoryId
                                            select new InfoProductDTO
                                            {
                                                ProductId = products.Id,
                                                NameProduct = products.ProductName,
                                                CategoryName = categorys.NameCategory,
                                                Description = products.Description,
                                                Quantity = products.Quantity,
                                            }).ToListAsync();
                return getInfoProduct;
            }
            catch (Exception ex)
            {
                return new List<InfoProductDTO>();
            }
        }

        public async Task<bool> CheckProductExistAsync(string productName)
        {
            return await _context.Products.AnyAsync( x=>x.ProductName == productName);
        }
        public async Task<bool> CheckProductIdExistAsync(Guid productId)
        {
            var tmp = await _context.Products.Where(x => x.Id == productId).AnyAsync();
            return tmp;
         
        }

    }
}
