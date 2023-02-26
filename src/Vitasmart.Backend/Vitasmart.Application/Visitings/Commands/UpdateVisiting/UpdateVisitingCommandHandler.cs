using MediatR;
using Microsoft.EntityFrameworkCore;
using Vitasmart.Application.Common.Exceptions;
using Vitasmart.Application.Interfaces;
using Vitasmart.Domain;

namespace Vitasmart.Application.Visitings.Commands.UpdateVisiting
{
    public class UpdateVisitingCommandHandler : IRequest<UpdateVisitingCommand>
    {
        private readonly IVisitingsDbContext _dbContext;
        public UpdateVisitingCommandHandler(IVisitingsDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateVisitingCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Visitings.FirstOrDefaultAsync(visiting =>
                    visiting.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Visiting), request.Id);
            }

            entity.Diagnose = request.Diagnose;
            entity.DateUpdated = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}