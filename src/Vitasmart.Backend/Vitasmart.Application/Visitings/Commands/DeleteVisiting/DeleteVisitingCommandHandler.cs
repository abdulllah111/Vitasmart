using MediatR;
using Vitasmart.Application.Common.Exceptions;
using Vitasmart.Application.Interfaces;
using Vitasmart.Domain;

namespace Vitasmart.Application.Visitings.Commands.DeleteVisiting
{
    public class DeleteVisitingCommandHandler : IRequest<DeleteVisitingCommand>
    {
        private readonly IVisitingsDbContext _dbContext;
        public DeleteVisitingCommandHandler(IVisitingsDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteVisitingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Visitings
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Visiting), request.Id);
            }

            _dbContext.Visitings.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}