using AppRevendedores.Dtos;
using FluentValidation;

namespace AppRevendedores.Validators
{
    public class ProductInsertValidator : AbstractValidator<ProductInsertDto>
    {

        public ProductInsertValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("El Nombre es obligatorio");
            RuleFor(x => x.Price).NotNull().WithMessage("El Precio es obligatorio");
            RuleFor(x => x.Description).NotNull().WithMessage("La Descripcion es obligatoria");
            RuleFor(x => x.CategoryId).NotNull().WithMessage("La Categoria es obligatoria");
            
        }
    }
}
