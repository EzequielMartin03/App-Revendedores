using AppRevendedores.Dtos;
using AppRevendedores.Models;
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

        public ProductController(Context context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<ProductDto>> Get()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            return Ok(product);
        }
        [HttpPost]

        public async Task<ActionResult<ProductInsertDto>> Insert(ProductInsertDto productInsertDto)
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
