using AutoMapper;
using Vitasmart.Application.Common.Mappings;
using Vitasmart.Domain;

namespace Vitasmart.Application.Patients.Queries.GetPatientList
{
    public class PatientLookupDto : IMapWith<Patient>
    {
        public Guid Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Patient, PatientLookupDto>()
                .ForMember(patientDto => patientDto.Id,
                opt => opt.MapFrom(patient => patient.Id))
                .ForMember(patientVm => patientVm.Surname,
                opt => opt.MapFrom(patient => patient.Surname))
                .ForMember(patientVm => patientVm.Name,
                opt => opt.MapFrom(patient => patient.Name))
                .ForMember(patientVm => patientVm.Patronymic,
                opt => opt.MapFrom(patient => patient.Patronymic));
        }
    }
}