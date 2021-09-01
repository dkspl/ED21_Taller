using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Context : DbContext
    {
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }
        public virtual DbSet<Automovil> Automoviles { get; set; }
        public virtual DbSet<Moto> Motos { get; set; }
        public virtual DbSet<Desperfecto> Desperfectos { get; set; }
        public virtual DbSet<Repuesto> Repuestos { get; set; }
        public virtual DbSet<Presupuesto> Presupuestos { get; set; }
        public virtual DbSet<RepuestoDesperfecto> RepuestosRequeridos { get; set; }

        public Context()
        {
        }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-M0USITF\\JOKER;Database=DiWork_TallerMecanico;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Vehiculo");
                entity.Property(e => e.Id)
                    .UseIdentityColumn();
                entity.Property(e => e.Patente)
                    .IsRequired()
                    .HasMaxLength(7);
                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            modelBuilder.Entity<Automovil>(entity =>
            {
                entity.ToTable("Automovil");
                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasConversion<int>();
                entity.Property(e => e.CantidadPuertas)
                    .IsRequired();
            });
            modelBuilder.Entity<Moto>(entity =>
            {
                entity.ToTable("Moto");
                entity.Property(e => e.Cilindrada)
                    .IsRequired();
            });
            modelBuilder.Entity<Desperfecto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Desperfecto");
                entity.Property(e => e.Id)
                   .UseIdentityColumn();
                entity.HasOne(d => d.Vehiculo)
                   .WithMany(p => p.Desperfectos)
                   .HasForeignKey(d => d.VehiculoId)
                   .HasConstraintName("FK_Vehiculo_Desperfecto")
                   .IsRequired();
                entity.HasOne(d => d.Presupuesto)
                    .WithOne(p => p.Desperfecto)
                    .HasForeignKey<Presupuesto>(b => b.DesperfectoId)
                    .IsRequired()
                    .HasConstraintName("FK_Desperfecto_Presupuesto"); ;
            });
            modelBuilder.Entity<Repuesto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Repuesto");
                entity.Property(e => e.Id)
                    .UseIdentityColumn();
                entity.Property(e => e.Nombre)
                   .IsRequired()
                   .HasMaxLength(200);
                entity.Property(e => e.Precio)
                   .IsRequired();
            });
            modelBuilder.Entity<RepuestoDesperfecto>(entity =>
            {
                entity.HasKey(e => new { e.RepuestoId, e.DesperfectoId });
                entity.ToTable("RepuestosRequeridos");
                entity.HasOne(d => d.Desperfecto)
                    .WithMany(p => p.Repuestos)
                    .HasForeignKey(d => d.DesperfectoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepuestoDesperfecto_Desperfecto");

                entity.HasOne(d => d.Repuesto)
                    .WithMany(p => p.RepuestosDesperfectos)
                    .HasForeignKey(d => d.RepuestoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepuestoDesperfecto_Repuesto");
            });
            modelBuilder.Entity<Presupuesto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Presupuesto");
                entity.Property(e => e.Id)
                    .UseIdentityColumn();
                entity.Property(e => e.ManoDeObra)
                   .IsRequired();
                entity.Property(e => e.Estacionamiento)
                   .IsRequired();
                entity.Property(e => e.Descuentos)
                   .HasDefaultValue<double?>(0.0);
                entity.Property(e => e.Recargos)
                   .HasDefaultValue<double?>(0.0);
                entity.Property(e => e.Repuestos)
                   .HasDefaultValue<double?>(0.0);
                entity.Property(e => e.Fecha)
                .HasDefaultValue(DateTime.Now);
            });
        }
    }
}
