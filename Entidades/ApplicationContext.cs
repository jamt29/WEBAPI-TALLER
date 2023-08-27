using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Ejercicio_26_07.Entidades
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la clave primaria compuesta para la tabla de unión TallerAuto
            modelBuilder.Entity<TallerAuto>().HasKey(x => new { x.TallerId, x.AutoId });
        }


        public DbSet<Taller> Talleres { get; set; }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<TallerAuto> TalleresAutos { get; set; }

    }
}
