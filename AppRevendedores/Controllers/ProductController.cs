using AppRevendedores.Dtos;
using AppRevendedores.Models;
using AppRevendedores.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppRevendedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private Context _context;
        private IValidator<ProductInsertDto> _ProductInsertValidator;
        private IProductService _ProductService;

        public ProductController(Context context, IValidator<ProductInsertDto> ProductInsertValidator,IProductService productService)
        {
            _context = context;
            _ProductInsertValidator = ProductInsertValidator;
            _ProductService = productService;

        }

        [HttpGet]

        public async Task<ActionResult<ProductDto>> Get()
        {
           await _ProductService.Get();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = _ProductService.GetById(id);

            return product != null ? Ok(product) : NotFound();
        }
        [HttpPost]

        public async Task<ActionResult<ProductInsertDto>> Insert(ProductInsertDto productInsertDto)
        {
            var validationResult = await _ProductInsertValidator.ValidateAsync(productInsertDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var newProduct = new Product
            {
                Name = productInsertDto.Name,
                Description = productInsertDto.Description,
                Price = productInsertDto.Price,
                CategoryId = productInsertDto.CategoryId

            };
            await _context.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductUpdateDto>> Update(ProductUpdateDto productUpdateDto,int id)
        {
            var Product = await _context.Products.FindAsync(id);

            if(Product == null)
            {
                return NotFound();
            }

            Product.Name = productUpdateDto.Name;
            Product.Price = productUpdateDto.Price;
            Product.Description = productUpdateDto.Description;
            Product.CategoryId = productUpdateDto.CategoryId;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ProductDto>> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);

             _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();

        }


    }
}
