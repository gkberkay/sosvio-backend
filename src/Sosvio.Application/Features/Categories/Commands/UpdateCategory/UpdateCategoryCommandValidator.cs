using FluentValidation;

namespace Sosvio.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Kategori ID zorunludur.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı zorunludur.")
            .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Slug)
            .NotEmpty().WithMessage("Slug zorunludur.")
            .MaximumLength(100).WithMessage("Slug en fazla 100 karakter olabilir.")
            .Matches("^[a-z0-9-]+$").WithMessage("Slug sadece küçük harf, rakam ve tire içerebilir.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));

        RuleFor(x => x.DisplayOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Sıralama 0 veya daha büyük olmalıdır.");
    }
}