using MediatR;

namespace Vitasmart.Application.Patients.Commands.CreatePatient
{
    public class CreatePatientCommand : IRequest<Guid>
    {
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public DateOnly BirthDay { get; set; }
        public long PhoneNumber { get; set; }
    }
}