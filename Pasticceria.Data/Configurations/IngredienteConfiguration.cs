using Pasticceria.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pasticceria.Data.Configurations
{
    public class IngredienteConfiguration : IEntityTypeConfiguration<Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Ingrediente> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Id)
                .UseIdentityColumn();

            builder
                .Property(i => i.Nome)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .ToTable("Ingredienti");
        }
    }
}
