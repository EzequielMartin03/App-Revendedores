using AppRevendedores.Dtos;
using AppRevendedores.Models;
using Microsoft.EntityFrameworkCore;

namespace AppRevendedores.Services
{
    public class ProductService : IProductService
    {
        private Context _context;
        public ProductService(Context context) {
           
            _context = context;
           
        }
        public async Task<ProductDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> Get() =>
        
            await _context.Products.Select(b => new ProductDto
            {
                CategoryId = b.CategoryId,
                Price = b.Price,
                ProductId = b.ProductId,
                Name = b.Name
            }).ToListAsync();

            
        

        public async Task<ProductDto> GetById(int id)
        {
           var Product = await _context.Products.FindAsync(id);

            if(Product != null)
            {
                var ProductDto = new ProductDto { 
                    CategoryId = Product.CategoryId,
                    Description = Product.Description,
                    Price = Product.Price,
                    ProductId = Product.ProductId };

                return ProductDto;
            }

            return null;
        }

        public async Task<ProductInsertDto> Insert(ProductInsertDto productInsertDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductUpdateDto> Update(ProductInsertDto productInsertDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
