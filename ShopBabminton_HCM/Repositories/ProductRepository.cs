using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<ProductInfo> AddProductAsync(AddProductRequest addProduct)
        {
            try
            {
                var addToProdcut = _mapper.Map<Product>(addProduct);
                await _context.Products.AddAsync(addToProdcut);

                await _context.SaveChangesAsync();

                return _mapper.Map<ProductInfo>(addToProdcut);

            }catch { return null; }
        }

        public async Task<ProductInfo> UpdateProductAsync(UpdateProductRequest updateProduct)
        {
            try
            {
                var productToUpdate = await _context.Products.FindAsync(updateProduct.ProductId);
                _mapper.Map(updateProduct, productToUpdate);

                await _context.SaveChangesAsync();

                return _mapper.Map<ProductInfo>(productToUpdate);
            }
            catch 
            {
                return null;
            }
        }

        public async Task<ProductInfoById> GetProductAsync(Guid productId)
        {
            try
            {
                bool checkProductExistAsync = await CheckProductIdValidAsync(productId);
                if (!checkProductExistAsync)
                {
                    return new ProductInfoById();
                }

                var getInfoProduct = await (from products in _context.Products
                                      join categorys in _context.Categorys on products.CategoryId equals categorys.Id
                                      where products.Id == productId
                                      select new ProductInfoById
                                      {
                                          ProductId = products.Id,
                                          ProductName = products.ProductName,
                                          CategoryName = categorys.CategoryName,
                                          Description = products.Description,
                                          Quantity = products.Quantity, 
                                          Price = products.Price
                                      }).FirstOrDefaultAsync();
                return getInfoProduct; 
            }
            catch 
            {
                return new ProductInfoById();
            }
        }

        public async Task<List<ProductInfoById>> GetListProductAsync()
        {
            try
            {
                var getListInfoProducts = await (from products in _context.Products
                                              join categorys in _context.Categorys on products.CategoryId equals categorys.Id
                                              select new ProductInfoById
                                              {
                                                  ProductId = products.Id,
                                                  ProductName = products.ProductName,
                                                  CategoryName = categorys.CategoryName,
                                                  Description = products.Description,
                                                  Quantity = products.Quantity
                                              }).ToListAsync();

                return getListInfoProducts;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<ProductInfoById>> GetProductsByCategoryIdAsync(Guid categoryId)
        {
           var getInfoProduct = await (from products in _context.Products
                                       join categorys in _context.Categorys on products.CategoryId equals categorys.Id
                                       where categorys.Id == categoryId
                                       select new ProductInfoById
                                       {
                                           ProductId = products.Id,
                                           ProductName = products.ProductName,
                                           CategoryName = categorys.CategoryName,
                                           Description = products.Description,
                                           Quantity = products.Quantity,
                                       }).ToListAsync();
            if (getInfoProduct != null)
            {
              return getInfoProduct;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CheckProductNameValidAsync(string productName)
        {
            return await _context.Products.AnyAsync( x=>x.ProductName == productName);
        }

        public async Task<bool> CheckProductIdValidAsync(Guid productId)
        {
            return await _context.Products.AnyAsync(x => x.Id == productId); 
        }

        public async Task<bool> CheckProdcutQuantityAsync(Guid productId)
        {
            return await _context.Products.AnyAsync(x => x.Id == productId && x.Quantity > 0 );
        }

        public async Task<bool> DisableProductAsync(Guid productId)
        {
            var disableProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (disableProduct != null)
            {
                disableProduct.Status = 0;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<ProductInfoById>> GetAllProductByStatusAsync(int statusCustomize)
        {
            int statusCustomizeTMP = statusCustomize;
            var StatusProducts = await(from product in _context.Products
                                       join category in _context.Categorys on product.CategoryId equals category.Id
                                       where product.Status != statusCustomizeTMP
                                       select new ProductInfoById
                                       {
                                           ProductId = product.Id,
                                           ProductName = product.ProductName,
                                           Description = product.Description,
                                           Price = product.Price,
                                           Quantity = product.Quantity,
                                           CategoryName = category.CategoryName
                                       }).ToListAsync();

            return StatusProducts;
        }

        public async Task<bool> UpdateProductStatusAsync(UpdateProductStatusRequest updateProductStatus)
        {
            var productToUpdate = await _context.Products.FirstOrDefaultAsync(x => x.Id == updateProductStatus.productId);
            if (productToUpdate != null)
            { 
                productToUpdate.Status = updateProductStatus.Status;
                await _context.SaveChangesAsync();
                return true; 
            } else { return false; }
            
        }

        public async Task<ProductInfoById> GetProductInfoByIdAsync(Guid productId)
        {
            var infoProduct = await (from product in _context.Products
                                     join category in _context.Categorys on product.CategoryId equals category.Id
                                     where product.Id == productId
                                     select new ProductInfoById 
                                     {
                                         ProductId = productId,
                                         ProductName = product.ProductName,
                                         Description = product.Description,
                                         Price = product.Price,
                                         Quantity = product.Quantity,
                                         CategoryName = category.CategoryName
                                     }).FirstOrDefaultAsync();
            if (infoProduct != null)
            {
                return infoProduct;
            }
            else { return null; }
        }

        public async Task<List<ProductInfoById>> GetAllProducts()
        {
            var getAllProducts = await(from product in _context.Products
                                       join category in _context.Categorys on product.CategoryId equals category.Id
                                       select new ProductInfoById
                                       {
                                           ProductId = product.Id,
                                           ProductName = product.ProductName,
                                           Description = product.Description,
                                           Price = product.Price,
                                           Quantity = product.Quantity,
                                           CategoryName = category.CategoryName
                                       }).ToListAsync();
            if(getAllProducts != null)
            {
                return getAllProducts;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ProductInfoById>> GetAllProductByFilter(GetAllProductRequest filter)
        {
            var products = await (from p in _context.Products
                                  join c in _context.Categorys on p.CategoryId equals c.Id
                                  where (filter.CategoryId == null || p.CategoryId == filter.CategoryId) &&
                                        (filter.PriceFrom == null || p.Price >= filter.PriceFrom) &&
                                        (filter.PriceTo == null || p.Price <= filter.PriceTo)
                                  select new ProductInfoById
                                  {
                                      ProductId = p.Id,
                                      ProductName = p.ProductName,
                                      Description = p.Description,
                                      Price = p.Price,
                                      Quantity = p.Quantity,
                                      CategoryName = c.CategoryName
                                  }).ToListAsync();


            if (products != null)
            {
                return products;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ProductInfoById>> SearchProductsAsync(string KeySearch)
        {
            var searchProduct = await (from p in _context.Products
                                       join c in _context.Categorys on p.CategoryId equals c.Id
                                       where p.ProductName.ToLower().Contains(KeySearch.ToLower())
                                       select new ProductInfoById
                                       {
                                           ProductId = p.Id,
                                           ProductName = p.ProductName,
                                           Description = p.Description,
                                           Price = p.Price,
                                           Quantity = p.Quantity,
                                           CategoryName = c.CategoryName
                                       }
                                       ).ToListAsync();
            if( searchProduct != null ) { return searchProduct;}
            else
            {
                return null;
            }
        }
    }
}
