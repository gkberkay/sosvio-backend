using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sosvio.Application.Common.Interfaces;
using Sosvio.Application.Common.Models;

namespace Sosvio.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler
    : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoryDto?> Handle(
        GetCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var category = await _context.Categories
            .Where(c => c.Id == request.Id && !c.IsDeleted)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return category;
    }
}