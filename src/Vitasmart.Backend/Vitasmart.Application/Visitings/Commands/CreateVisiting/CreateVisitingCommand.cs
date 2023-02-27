using MediatR;
using Vitasmart.Domain;

namespace Vitasmart.Application.Visitings.Commands.CreateVisiting
{
    public class CreateVisitingCommand : IRequest<Guid>
    {
        public DateTime Date { get; set; }
        public string? Diagnose { get; set; }
        public Guid PatientId { get; set; }
    }
}