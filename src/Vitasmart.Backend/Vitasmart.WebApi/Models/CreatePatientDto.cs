using AutoMapper;
using Vitasmart.Application.Common.Mappings;
using Vitasmart.Application.Patients.Commands.CreatePatient;

namespace Vitasmart.WebApi.Models
{
    public class CreatePatientDto : IMapWith<CreatePatientCommand>
    {
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public DateTime BirthDay { get; set; }
        public long PhoneNumber { get; set; }
        public void Mappings(Profile profile)
        {
            profile.CreateMap<CreatePatientDto, CreatePatientCommand>()
                .ForMember(patientCommand => patientCommand.Surname,
                opt => opt.MapFrom(patientDto => patientDto.Surname))
                .ForMember(patientCommand => patientCommand.Name,
                opt => opt.MapFrom(patientDto => patientDto.Name))
                .ForMember(patientCommand => patientCommand.Patronymic,
                opt => opt.MapFrom(patientDto => patientDto.Patronymic))
                .ForMember(patientCommand => patientCommand.BirthDay,
                opt => opt.MapFrom(patientDto => patientDto.BirthDay))
                .ForMember(patientCommand => patientCommand.PhoneNumber,
                opt => opt.MapFrom(patientDto => patientDto.PhoneNumber));
        }
    }
}