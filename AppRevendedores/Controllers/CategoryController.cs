using AppRevendedores.Dtos;
using AppRevendedores.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppRevendedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICommonService<CategoryDto, CategoryDto, CategoryInsertDto> _repository;
        public CategoryController([FromKeyedServices("ProductService")] ICommonService<CategoryDto, CategoryDto, CategoryInsertDto> CategoryService) {


            _repository = CategoryService;
        }


        [HttpGet]

        public async Task<ActionResult<CategoryDto>> Get()
        {
            var Category = await _repository.Get();

            return Ok(Category);
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var CategoryById = await _repository.GetById(id);

            return Ok(CategoryById);
        }

        [HttpPost]

        public async Task<ActionResult<CategoryInsertDto>> Insert(CategoryInsertDto categoryInsertDto)
        {
            var Category = await _repository.Insert(categoryInsertDto);

            return Ok(Category);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<CategoryDto>> Update(CategoryDto categoryDto, int id)
        {
            var Category = await _repository.Update(categoryDto,id);

            return Category == null ? NotFound() : Ok(Category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDto>> Delete( int id)
        {
            var Category = await _repository.Delete(id);

            return Category == null ? NotFound() : Ok(Category);
        }
        
    }
}
