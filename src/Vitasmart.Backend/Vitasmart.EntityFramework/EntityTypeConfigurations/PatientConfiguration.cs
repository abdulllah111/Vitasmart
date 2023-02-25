using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vitasmart.Domain;

namespace Vitasmart.EntityFramework.EntityTypeConfigurations
{
    internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(patient => patient.Id);
            builder.HasIndex(patient => patient.Id).IsUnique();
        }
    }
}
