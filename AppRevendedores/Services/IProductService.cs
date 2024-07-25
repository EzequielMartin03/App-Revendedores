using AppRevendedores.Dtos;

namespace AppRevendedores.Services
{
    public interface IProductService
    {

        Task<IEnumerable<ProductDto>> Get();

        Task<ProductDto> GetById(int id);

        Task<ProductInsertDto> Insert(ProductInsertDto productInsertDto);

        Task<ProductUpdateDto> Update(ProductInsertDto productInsertDto, int id);

        Task<ProductDto> Delete(int id);
    }
}
