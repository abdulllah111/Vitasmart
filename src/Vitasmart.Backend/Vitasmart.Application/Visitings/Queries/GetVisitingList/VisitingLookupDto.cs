using AutoMapper;
using Vitasmart.Application.Common.Mappings;
using Vitasmart.Domain;

namespace Vitasmart.Application.Visitings.Queries.GetVisitingList
{
    public class VisitingLookupDto : IMapWith<Visiting>
    {
        public Guid Id { get; set; }
        public string? Diagnose { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Visiting, VisitingLookupDto>()
                .ForMember(visitingDto => visitingDto.Id,
                opt => opt.MapFrom(visiting => visiting.Id))
                .ForMember(visitingDto => visitingDto.Diagnose,
                opt => opt.MapFrom(visiting => visiting.Diagnose));
        }
    }
}