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
       
        private IValidator<ProductInsertDto> _ProductInsertValidator;
        private IProductService _ProductService;

        public ProductController(Context context, IValidator<ProductInsertDto> ProductInsertValidator,IProductService productService)
        {
            
            _ProductInsertValidator = ProductInsertValidator;
            _ProductService = productService;

        }

        [HttpGet]

        public async Task<ActionResult<ProductDto>> Get()
        {
           var product = await _ProductService.Get();

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _ProductService.GetById(id);

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

            var ProductDto = await _ProductService.Insert(productInsertDto);

            return Ok(ProductDto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductUpdateDto>> Update(ProductUpdateDto productUpdateDto,int id)
        {
            var productUpdated = _ProductService.Update(productUpdateDto,id);
           if ( productUpdated != null) {
            
                return  Ok(productUpdated);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ProductDto>> Delete(int id)
        {
            var ProductDto = await _ProductService.Delete(id); 

            return ProductDto == null ? NotFound() : Ok(ProductDto);

        }


    }
}
