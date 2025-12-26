using MediatR;
using Microsoft.EntityFrameworkCore;
using Sosvio.Application.Common.Interfaces;

namespace Sosvio.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(
        UpdateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        // Kategoriyi bul
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == request.Id && !c.IsDeleted, cancellationToken);

        if (category == null)
        {
            throw new KeyNotFoundException($"Kategori bulunamadı: {request.Id}");
        }

        // Güncelle
        category.Name = request.Name;
        category.Slug = request.Slug;
        category.Description = request.Description;
        category.IconUrl = request.IconUrl;
        category.ParentCategoryId = request.ParentCategoryId;
        category.DisplayOrder = request.DisplayOrder;
        category.IsActive = request.IsActive;
        category.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value; // Void benzeri
    }
}