using InventarioTI.Shared.Interfaces;
using InventarioTI.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventarioTI.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Usuario → tabla tbsuarios
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("tbusuarios");   // 👈 nombre real en SQL Server
                entity.HasKey(u => u.Id_Usuarios);
                entity.Property(u => u.Nombre).HasColumnName("nombre");
                entity.Property(u => u.Apellidos).HasColumnName("apellidos");
                entity.Property(u => u.Correo).HasColumnName("correo");
                entity.Property(u => u.Contraseña).HasColumnName("contraseña");
                entity.Property(u => u.Estado).HasColumnName("estado");
                entity.Property(u => u.Fecha_Creacion).HasColumnName("fecha_creacion");
                entity.Property(u => u.Fecha_Fin).HasColumnName("fecha_fin");
                entity.Property(u => u.Id_TipoU).HasColumnName("id_tipoU");
            });

            // Equipo → tabla tbequipos
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("tbequipos");   // 👈 nombre real en SQL Server
                entity.HasKey(e => e.Id_Equip);
                entity.Property(e => e.Placa).HasColumnName("placa");
                entity.Property(e => e.Serial).HasColumnName("serial");
                entity.Property(e => e.Fecha_Creacion).HasColumnName("fecha_creacion");
                entity.Property(e => e.Estado).HasColumnName("estado");
            });

            modelBuilder.Entity<Area>(entity =>
            {
               entity.ToTable("tbarea");   // 👈 nombre real en SQL Server
                entity.HasKey(a => a.Id_Area);
                entity.Property(a => a.Nombre).HasColumnName("Area");
                entity.Property(a => a.Estado).HasColumnName("Estado");
                entity.Property(a => a.Fecha_Creacion).HasColumnName("fecha_creacion");
                entity.Property(a => a.Fecha_Fin).HasColumnName("fecha_fin");
                entity.Property(a => a.Centro_costos).HasColumnName("centro_costos");

            });
        }
    }
}
