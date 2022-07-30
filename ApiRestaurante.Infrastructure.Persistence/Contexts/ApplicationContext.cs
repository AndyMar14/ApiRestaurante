using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Infrastructure.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApiRestaurante.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Ingredientes> Ingredientes { get; set; }
        public DbSet<Platos> Platos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new IngredientesMap());
            modelBuilder.ApplyConfiguration(new PlatosMap());
            modelBuilder.ApplyConfiguration(new MesasMap());

        }

    }
}
