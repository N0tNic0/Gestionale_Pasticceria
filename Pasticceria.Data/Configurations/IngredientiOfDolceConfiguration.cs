using Pasticceria.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pasticceria.Data.Configurations
{
    public class IngredientiOfDolceConfiguration : IEntityTypeConfiguration<IngredientiOfDolce>
    {
        public void Configure(EntityTypeBuilder<IngredientiOfDolce> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Id)
                .UseIdentityColumn();

            builder
                .Property(i => i.Quantita)
                .IsRequired();

            builder
                .Property(i => i.UnitaDiMisura)
                .IsRequired();

            builder
                .HasOne(i => i.Dolce)
                .WithMany(d => d.IngredientiOfDolce)
                .HasForeignKey(i => i.IdDolce);

            builder
                .HasOne(i => i.Ingrediente)
                .WithMany(d => d.IngredientiOfDolce)
                .HasForeignKey(i => i.IdIngrediente);

            builder
                .ToTable("IngredientiOfDolce");
        }
    }
}
