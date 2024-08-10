using AppRevendedores.Models;
using Microsoft.EntityFrameworkCore;

namespace AppRevendedores.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private Context _context;
        public CategoryRepository(Context context) {

            _context = context;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            var Category = await _context.categories.ToListAsync();

            return Category;
        }

        public async Task<Category> GetByid(int id)
        {
            var Category = await _context.categories.FindAsync(id);

            return Category;
        }

        public async Task Insert(Category entity)
            => await _context.categories.AddAsync(entity); 

        public async Task Save() => await _context.SaveChangesAsync();

        public void Update(Category entity)
        {
            _context.categories.Attach(entity);
            _context.categories.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Category entity)

           => _context.categories.Remove(entity);
    }
}
