using Microsoft.EntityFrameworkCore;
using Vitasmart.Domain;

namespace Vitasmart.Application.Interfaces
{
    public interface IPatientsDbContext
    {
        DbSet<Patient> Patients { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}