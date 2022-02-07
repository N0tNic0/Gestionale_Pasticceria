using Pasticceria.Core.Models;
using Microsoft.EntityFrameworkCore;
using Pasticceria.Data.Configurations;

namespace Pasticceria.Data
{
    public class PasticceriaDbContext : DbContext
    {
        public DbSet<Ingrediente> Ingredienti { get; set; }
        public DbSet<Dolce> Dolci { get; set; }
        public DbSet<IngredientiOfDolce> IngredientiOfDolci { get; set; }

        public PasticceriaDbContext(DbContextOptions<PasticceriaDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new IngredienteConfiguration());

            builder
                .ApplyConfiguration(new DolceConfiguration());

            builder
                .ApplyConfiguration(new IngredientiOfDolceConfiguration());
        }
    }
}
