using AppRevendedores.Dtos;
using AppRevendedores.Models;
using AppRevendedores.Repository;

namespace AppRevendedores.Services
{
    public class CategoryService : ICommonService<CategoryDto, CategoryDto, CategoryInsertDto>
    {
        private IRepository<Category> _repository;
        public CategoryService(CategoryRepository categoryRepository) {
            
            _repository = categoryRepository;
        
        }
        public async Task<CategoryDto> Delete(int id)
        {
            var Category = await _repository.GetByid(id);

            _repository.Delete(Category);

           
        }

        public Task<IEnumerable<CategoryDto>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> Insert(CategoryInsertDto productInsertDto)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> Update(CategoryDto productDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
