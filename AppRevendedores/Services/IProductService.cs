using AppRevendedores.Dtos;

namespace AppRevendedores.Services
{
    public interface IProductService
    {

        Task<IEnumerable<ProductDto>> Get();

        Task<ProductDto> GetById(int id);

        Task<ProductDto> Insert(ProductInsertDto productInsertDto);

        Task<ProductUpdateDto> Update(ProductUpdateDto productUpdateDto, int id);

        Task<ProductDto> Delete(int id);
    }
}
