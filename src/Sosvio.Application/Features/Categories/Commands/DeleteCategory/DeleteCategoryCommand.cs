using MediatR;

namespace Sosvio.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}