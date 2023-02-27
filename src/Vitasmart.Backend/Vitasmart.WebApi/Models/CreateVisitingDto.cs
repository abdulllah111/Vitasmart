using AutoMapper;
using Vitasmart.Application.Common.Mappings;
using Vitasmart.Application.Visitings.Commands.CreateVisiting;

namespace Vitasmart.WebApi.Models
{
    public class CreateVisitingDto : IMapWith<CreateVisitingCommand>
    {
        public DateTime Date { get; set; }
        public string? Diagnose { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateVisitingDto, CreateVisitingCommand>()
                .ForMember(visitingCommand => visitingCommand.Date,
                opt => opt.MapFrom(visitingDto => visitingDto.Date))
                .ForMember(visitingCommand => visitingCommand.Diagnose,
                opt => opt.MapFrom(visitingDto => visitingDto.Diagnose));
        }
    }
}