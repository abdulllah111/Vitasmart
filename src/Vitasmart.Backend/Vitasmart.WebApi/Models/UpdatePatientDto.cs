using AutoMapper;
using Vitasmart.Application.Common.Mappings;
using Vitasmart.Application.Patients.Commands.UpdatePatient;

namespace Vitasmart.WebApi.Models
{
    public class UpdatePatientDto : IMapWith<UpdatePatientCommand>
    {
        public Guid Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public DateTime BirthDay { get; set; }
        public int PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePatientDto, UpdatePatientCommand>()
                .ForMember(patientCommand => patientCommand.Id,
                opt => opt.MapFrom(patientDto => patientDto.Id))
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