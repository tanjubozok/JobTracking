namespace JobTracking.Business.ValidationRules;

public class CategoryAddDtoValidator : AbstractValidator<CategoryAddDto>
{
    public CategoryAddDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Kategori alanı boş olamaz")
            .NotEmpty().WithMessage("Kategori alanı boş olamaz")
            .MinimumLength(3).WithMessage("Kategori alanı en az 3 karakter olmalıdır")
            .MaximumLength(100).WithMessage("Kategori alanı en fazla 100 karakter olmalıdır");

        RuleFor(x => x.Color)
            .NotEmpty().WithMessage("Kategori renk alanı boş olamaz");
    }
}
