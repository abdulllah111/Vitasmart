using Microsoft.EntityFrameworkCore;
using Vitasmart.Application.Interfaces;
using Vitasmart.Domain;
using Vitasmart.EntityFramework.EntityTypeConfigurations;

namespace Vitasmart.EntityFramework
{
    public class PatientsDbContext : DbContext, IPatientsDbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public PatientsDbContext(DbContextOptions<PatientsDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PatientConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
