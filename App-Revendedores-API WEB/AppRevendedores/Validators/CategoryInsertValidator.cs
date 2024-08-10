using AppRevendedores.Dtos;
using FluentValidation;

namespace AppRevendedores.Validators
{
    public class CategoryInsertValidator : AbstractValidator<CategoryInsertDto>
    {
        public CategoryInsertValidator()
        {
            RuleFor(x => x.NameCategory).NotNull().WithMessage("El Nombre de la categoria es obligatorio");
            

        }
    }
}
