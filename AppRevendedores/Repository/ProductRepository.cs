using AppRevendedores.Models;
using Microsoft.EntityFrameworkCore;

namespace AppRevendedores.Repository
{
    public class ProductRepository : IRepository<Product>
    {

        private Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> Get()
            => await _context.Products.ToListAsync();

        public async Task<Product> GetByid(int id)
            => await _context.Products.FindAsync(id);

        public async Task Insert(Product entity)
            => await _context.Products.AddAsync(entity); 


        public void Update(Product entity)
        {
            _context.Products.Attach(entity);
            _context.Products.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Product entity) 
            => _context.Products.Remove(entity); 

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
