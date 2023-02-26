using MediatR;

namespace Vitasmart.Application.Visitings.Commands.DeleteVisiting
{
    public class DeleteVisitingCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}