
using GestionEvidencias.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionEvidencias.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Evidencia> Evidencias { get; set; }
        public DbSet<EvidenciaEstudiante> EvidenciaEstudiantes { get; set; }
        public DbSet<Temporal> Temporales { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Estudiante>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Evidencia>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<EvidenciaEstudiante>().HasIndex("EvidenciaId", "EstudianteId").IsUnique();
            modelBuilder.Entity<Temporal>().HasIndex(c => c.Id).IsUnique();

        }
    }
}
