using AppRevendedores.Models;

namespace AppRevendedores.Repository
{
    public interface IRepository<TEntity>
    {

        
        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> GetByid(int id);

        Task Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task Save();
    }
}
