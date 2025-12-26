using MediatR;
using Sosvio.Application.Common.Models;

namespace Sosvio.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<CategoryDto?>
{
    public Guid Id { get; set; }
}