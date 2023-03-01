using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Vitasmart.Application.Common.Mappings;
using Vitasmart.Application.Patients.Commands.CreatePatient;

namespace Vitasmart.WebApi.Models
{
    public class CreatePatientDto : IMapWith<CreatePatientCommand>
    {
        [Required]
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public DateOnly BirthDay { get; set; }
        public long PhoneNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePatientDto, CreatePatientCommand>()
                .ForMember(patientCommand => patientCommand.Surname,
                opt => opt.MapFrom(patientDto => patientDto.Surname)).ReverseMap()
                .ForMember(patientCommand => patientCommand.Name,
                opt => opt.MapFrom(patientDto => patientDto.Name)).ReverseMap()
                .ForMember(patientCommand => patientCommand.Patronymic,
                opt => opt.MapFrom(patientDto => patientDto.Patronymic)).ReverseMap()
                .ForMember(patientCommand => patientCommand.BirthDay,
                opt => opt.MapFrom(patientDto => patientDto.BirthDay)).ReverseMap()
                .ForMember(patientCommand => patientCommand.PhoneNumber,
                opt => opt.MapFrom(patientDto => patientDto.PhoneNumber)).ReverseMap();
        }
    }
}