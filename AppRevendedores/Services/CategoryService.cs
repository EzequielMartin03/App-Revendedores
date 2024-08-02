using AppRevendedores.Dtos;

namespace AppRevendedores.Services
{
    public class CategoryService : ICommonService<CategoryDto, CategoryDto, CategoryInsertDto>
    {
        public Task<CategoryDto> Delete(int id)
        {
            throw new NotImplementedException();
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
