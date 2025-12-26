using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sosvio.Application.Common.Interfaces;
using Sosvio.Application.Common.Models;

namespace Sosvio.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoriesListQueryHandler
    : IRequestHandler<GetCategoriesListQuery, List<CategoryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoriesListQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> Handle(
        GetCategoriesListQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await _context.Categories
            .Where(c => !c.IsDeleted && c.IsActive)
            .OrderBy(c => c.DisplayOrder)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return categories;
    }
}