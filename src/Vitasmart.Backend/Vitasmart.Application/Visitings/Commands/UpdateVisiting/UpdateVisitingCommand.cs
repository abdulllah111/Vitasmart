using MediatR;

namespace Vitasmart.Application.Visitings.Commands.UpdateVisiting
{
    public class UpdateVisitingCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Diagnose { get; set; }
        public DateTime Date { get; set; }
    }
}