using Pasticceria.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pasticceria.Data.Configurations
{
    public class DolceConfiguration : IEntityTypeConfiguration<Dolce>
    {
        public void Configure(EntityTypeBuilder<Dolce> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Id)
                .UseIdentityColumn();

            builder
                .Property(d => d.Nome)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(d => d.Prezzo)
                .IsRequired();

            builder
                .Property(d => d.Quantita)
                .IsRequired();

            builder
                .Property(d => d.Data_Inserimento)
                .IsRequired();

            builder
                .ToTable("Dolci");
        }
    }
}
