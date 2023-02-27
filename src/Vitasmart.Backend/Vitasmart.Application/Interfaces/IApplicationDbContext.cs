using Microsoft.EntityFrameworkCore;
using Vitasmart.Domain;

namespace Vitasmart.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Patient> Patients { get; set; }
        DbSet<Visiting> Visitings { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}