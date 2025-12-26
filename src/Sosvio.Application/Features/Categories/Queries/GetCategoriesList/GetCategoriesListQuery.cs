using MediatR;
using Sosvio.Application.Common.Models;

namespace Sosvio.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoriesListQuery : IRequest<List<CategoryDto>>
{
    // Parametresiz - tüm kategorileri getir
}