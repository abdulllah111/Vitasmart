using AutoMapper;
using Vitasmart.Application.Common.Mappings;
using Vitasmart.Domain;

namespace Vitasmart.Application.Patients.Queries.GetPatientDetails
{
    public class PatientDetailsVm : IMapWith<Patient>
    {
        public Guid Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public DateOnly BirthDay { get; set; }
        public long PhoneNumber { get; set; }
        public DateOnly DateAdded { get; set; }
        public DateOnly DateUpdated { get; set; }
        public ICollection<Visiting>? Visitings { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Patient, PatientDetailsVm>()
                .ForMember(patientVm => patientVm.Surname,
                opt => opt.MapFrom(patient => patient.Surname))
                .ForMember(patientVm => patientVm.Name,
                opt => opt.MapFrom(patient => patient.Name))
                .ForMember(patientVm => patientVm.Patronymic,
                opt => opt.MapFrom(patient => patient.Patronymic))
                .ForMember(patientVm => patientVm.BirthDay,
                opt => opt.MapFrom(patient => patient.BirthDay))
                .ForMember(patientVm => patientVm.PhoneNumber,
                opt => opt.MapFrom(patient => patient.PhoneNumber))
                .ForMember(patientVm => patientVm.DateAdded,
                opt => opt.MapFrom(patient => patient.DateAdded))
                .ForMember(patientVm => patientVm.DateUpdated,
                opt => opt.MapFrom(patient => patient.DateUpdated))
                .ForMember(patientVm => patientVm.Visitings,
                opt => opt.MapFrom(patient => patient.Visitings));
        }
    }
}