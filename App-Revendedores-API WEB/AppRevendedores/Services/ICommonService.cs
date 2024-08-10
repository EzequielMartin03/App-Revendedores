using AppRevendedores.Dtos;

namespace AppRevendedores.Services
{
    public interface ICommonService<T,TU,TI>
    {

        Task<IEnumerable<T>> Get();

        Task<T> GetById(int id);

        Task<T> Insert(TI productInsertDto);

        Task<TU> Update(TU productUpdateDto, int id);

        Task<T> Delete(int id);
    }
}
