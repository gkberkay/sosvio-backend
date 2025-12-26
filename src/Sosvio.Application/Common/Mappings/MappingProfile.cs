using AutoMapper;
using Sosvio.Application.Common.Models;
using Sosvio.Domain.Entities;

namespace Sosvio.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Category mappings
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.ParentCategoryName,
                opt => opt.MapFrom(src => src.ParentCategory != null ? src.ParentCategory.Name : null));
    }
}