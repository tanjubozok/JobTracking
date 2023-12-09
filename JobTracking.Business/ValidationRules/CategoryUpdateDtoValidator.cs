namespace JobTracking.Business.ValidationRules;

public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateDtoValidator()
    {
        this.RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori alanı boş olamaz")
            .MinimumLength(3).WithMessage("Kategori alanı en az 3 karakter olmalıdır")
            .MaximumLength(100).WithMessage("Kategori alanı en fazla 100 karakter olmalıdır");

        this.RuleFor(x => x.Color)
            .NotEmpty().WithMessage("Kategori renk alanı boş olamaz");
    }
}
