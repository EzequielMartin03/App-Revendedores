using AppRevendedores.Dtos;
using AppRevendedores.Models;
using AppRevendedores.Repository;
using Microsoft.EntityFrameworkCore;

namespace AppRevendedores.Services
{
    public class ProductService : ICommonService<ProductDto, ProductUpdateDto, ProductInsertDto>
    {
    
        private IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository) {
           
            
            _repository = repository;
           
        }
        public async Task<ProductDto> Delete(int id)
        {
            var Product = await _repository.GetByid(id);

            if (Product == null)
            {
                

                var ProductDto = new ProductDto
                {
                    CategoryId = Product.CategoryId,
                    Description = Product.Description,
                    Price = Product.Price,
                    ProductId = Product.ProductId
                };

                _repository.Delete(Product);
                await _repository.Save();

                return ProductDto;

            }

            return null;
            

        }

        public async Task<IEnumerable<ProductDto>> Get()
        {
            var products = await _repository.Get();

            return products.Select(p => new ProductDto()
            {
                ProductId = p.ProductId,
                CategoryId = p.CategoryId,
                Description = p.Description,
                Price = p.Price
            });
        }

            
        

        public async Task<ProductDto> GetById(int id)
        {
           var Product = await _repository.GetByid(id);

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
                await _repository.Insert(newProduct);
                await _repository.Save();

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
            var Product = await _repository.GetByid(id);
            if (Product != null)
            {
                Product.Name = productUpdateDto.Name;
                Product.Price = productUpdateDto.Price;
                Product.Description = productUpdateDto.Description;
                Product.CategoryId = productUpdateDto.CategoryId;

                _repository.Update(Product);
                await _repository.Save();

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
