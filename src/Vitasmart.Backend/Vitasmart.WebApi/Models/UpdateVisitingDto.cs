using AutoMapper;
using Vitasmart.Application.Common.Mappings;
using Vitasmart.Application.Visitings.Commands.UpdateVisiting;
using Vitasmart.Application.Visitings.Queries.GetVisitingDetails;
using Vitasmart.Domain;

namespace Vitasmart.WebApi.Models
{
    public class UpdateVisitingDto : IMapWith<UpdateVisitingCommand>
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public string? Diagnose { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateVisitingDto, UpdateVisitingCommand>()
                .ForMember(visitingCommand => visitingCommand.Id,
                opt => opt.MapFrom(visitingDto => visitingDto.Id))
                .ForMember(visitingCommand => visitingCommand.Date,
                opt => opt.MapFrom(visitingDto => visitingDto.Date))
                .ForMember(visitingCommand => visitingCommand.Diagnose,
                opt => opt.MapFrom(visitingDto => visitingDto.Diagnose));
        }
    }
}