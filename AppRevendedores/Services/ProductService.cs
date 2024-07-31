using AppRevendedores.Dtos;
using AppRevendedores.Models;
using Microsoft.EntityFrameworkCore;

namespace AppRevendedores.Services
{
    public class ProductService : ICommonService<ProductDto, ProductUpdateDto, ProductInsertDto>
    {
        private Context _context;
        public ProductService(Context context) {
           
            _context = context;
           
        }
        public async Task<ProductDto> Delete(int id)
        {
            var Product = await _context.Products.FindAsync(id);

            if (Product == null)
            {
                

                var ProductDto = new ProductDto
                {
                    CategoryId = Product.CategoryId,
                    Description = Product.Description,
                    Price = Product.Price,
                    ProductId = Product.ProductId
                };

                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();

                return ProductDto;

            }

            return null;
            

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

        public async Task<ProductDto> Insert(ProductInsertDto productInsertDto)
        {
           
            
                var newProduct = new Product
                {
                    Name = productInsertDto.Name,
                    Description = productInsertDto.Description,
                    Price = productInsertDto.Price,
                    CategoryId = productInsertDto.CategoryId

                };
                await _context.AddAsync(newProduct);
                await _context.SaveChangesAsync();

                var ProductDto = new ProductDto
                {

                    Name= newProduct.Name,
                    Description= newProduct.Description,
                    Price= newProduct.Price,
                    CategoryId = newProduct.CategoryId



                };

                return ProductDto;


            

            
            
        }

        public async Task<ProductUpdateDto> Update(ProductUpdateDto productUpdateDto, int id)
        {
            var Product = await _context.Products.FindAsync(id);

            if (Product != null)
            {
                Product.Name = productUpdateDto.Name;
                Product.Price = productUpdateDto.Price;
                Product.Description = productUpdateDto.Description;
                Product.CategoryId = productUpdateDto.CategoryId;

                await _context.SaveChangesAsync();

                var ProductUpdateDto = new ProductUpdateDto
                {
                    ProductId = productUpdateDto.ProductId,
                    Description = productUpdateDto.Description,
                    Price = productUpdateDto.Price,
                    CategoryId = productUpdateDto.CategoryId


                };

                return ProductUpdateDto;

               
            }

            return null;

           
        }
    }
}
