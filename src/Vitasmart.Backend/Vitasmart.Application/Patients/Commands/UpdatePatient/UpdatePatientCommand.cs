using MediatR;

namespace Vitasmart.Application.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public DateOnly BirthDay { get; set; }
        public long PhoneNumber { get; set; }
    }
}