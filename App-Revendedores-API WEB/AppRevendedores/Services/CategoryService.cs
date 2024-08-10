using AppRevendedores.Dtos;
using AppRevendedores.Models;
using AppRevendedores.Repository;

namespace AppRevendedores.Services
{
    public class CategoryService : ICommonService<CategoryDto, CategoryDto, CategoryInsertDto>
    {
        private IRepository<Category> _repository;
        public CategoryService(IRepository<Category>  categoryRepository) {
            
            _repository = categoryRepository;
        
        }
        public async Task<CategoryDto> Delete(int id)
        {
            var Category = await _repository.GetByid(id);

            _repository.Delete(Category);

            var CategoryDto = new CategoryDto()
            {
                CategoryId = Category.CategoryId,
                NameCategory = Category.NameCategory
            };

            return CategoryDto;

           
        }

        public async Task<IEnumerable<CategoryDto>> Get()
        {
            var Category = await _repository.Get();

            return Category.Select(c => new CategoryDto() {
                
                CategoryId=c.CategoryId,
                NameCategory = c.NameCategory
            
                });

           
        }
        public async Task<CategoryDto> GetById(int id)
        {
           var Category = await _repository.GetByid(id);

            if(Category != null)
            {
                var CategoryDto = new CategoryDto()
                {
                    CategoryId = Category.CategoryId,
                    NameCategory = Category.NameCategory
                };

                return CategoryDto;
            }

            return null;

            
        }

        public async Task<CategoryDto> Insert(CategoryInsertDto productInsertDto)
        {
           var NewCategory = new Category
           {
               NameCategory = productInsertDto.NameCategory
           };
            await _repository.Insert(NewCategory);
            await _repository.Save();


            var CategoryDto = new CategoryDto()
            {
                CategoryId = NewCategory.CategoryId,
                NameCategory = NewCategory.NameCategory
            };

            return CategoryDto;
        }

        public async Task<CategoryDto> Update(CategoryDto productDto, int id)
        {
            var category = await _repository.GetByid(id);

            if(category != null)
            {
                category.NameCategory = productDto.NameCategory;

            }

            var CategoryDto = new CategoryDto()
            {
                CategoryId = category.CategoryId,
                NameCategory = category.NameCategory
            };

            return CategoryDto;
        }
    }
}
