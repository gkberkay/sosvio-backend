using MediatR;
using Microsoft.EntityFrameworkCore;
using Sosvio.Application.Common.Interfaces;

namespace Sosvio.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(
        DeleteCategoryCommand request,
        CancellationToken cancellationToken)
    {
        // Kategoriyi bul
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == request.Id && !c.IsDeleted, cancellationToken);

        if (category == null)
        {
            throw new KeyNotFoundException($"Kategori bulunamadı: {request.Id}");
        }

        // Soft delete
        category.IsDeleted = true;
        category.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}