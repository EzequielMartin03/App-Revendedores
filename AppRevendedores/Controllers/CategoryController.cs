using AppRevendedores.Dtos;
using AppRevendedores.Models;
using AppRevendedores.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppRevendedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICommonService<CategoryDto, CategoryDto, CategoryInsertDto> _CategoryService;
        public CategoryController([FromKeyedServices("ProductService")] ICommonService<CategoryDto, CategoryDto, CategoryInsertDto> CategoryService) {


            _CategoryService = CategoryService;
        }


        [HttpGet]

        public async Task<ActionResult<CategoryDto>> Get()
        {
            var Category = await _CategoryService.Get();

            return Ok(Category);
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var CategoryById = await _CategoryService.GetById(id);

            return CategoryById == null ? NotFound() : Ok(CategoryById);
        }

        [HttpPost]

        public async Task<ActionResult<CategoryInsertDto>> Insert(CategoryInsertDto categoryInsertDto)
        {
            var Category = await _CategoryService.Insert(categoryInsertDto);

            return Ok(Category);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<CategoryDto>> Update(CategoryDto categoryDto, int id)
        {
            var Category = await _CategoryService.Update(categoryDto,id);

            return Category == null ? NotFound() : Ok(Category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDto>> Delete( int id)
        {
            var Category = await _CategoryService.Delete(id);

            return Category == null ? NotFound() : Ok(Category);
        }
        
    }
}
