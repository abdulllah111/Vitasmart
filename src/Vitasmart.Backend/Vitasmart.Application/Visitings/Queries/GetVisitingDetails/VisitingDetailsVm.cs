using AutoMapper;
using MediatR;
using Vitasmart.Domain;

namespace Vitasmart.Application.Visitings.Queries.GetVisitingDetails
{
    public class VisitingDetailsVm : IRequest<Visiting>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Diagnose { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Visiting, VisitingDetailsVm>()
                .ForMember(visitingVm => visitingVm.Date,
                opt => opt.MapFrom(visiting => visiting.Date))
                .ForMember(visitingVm => visitingVm.Diagnose,
                opt => opt.MapFrom(visiting => visiting.Diagnose))
                .ForMember(visitingVm => visitingVm.DateAdded,
                opt => opt.MapFrom(visiting => visiting.DateAdded))
                .ForMember(visitingVm => visitingVm.DateUpdated,
                opt => opt.MapFrom(visiting => visiting.DateUpdated));
        }
    }
}