namespace Trin.OnTour.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnTourContext : DbContext
    {
        public OnTourContext()
            : base("name=OnTourContext")
        {
        }

        public virtual DbSet<Apoderado> Apoderado { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<DetallePago> DetallePago { get; set; }
        public virtual DbSet<PagoDeposito> PagoDeposito { get; set; }
        public virtual DbSet<PaqueteTuristico> PaqueteTuristico { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Representante> Representante { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apoderado>()
                .HasMany(e => e.DetallePago)
                .WithRequired(e => e.Apoderado)
                .HasForeignKey(e => e.RutApoderado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contrato>()
                .HasMany(e => e.DetallePago)
                .WithRequired(e => e.Contrato)
                .HasForeignKey(e => e.CodigoContrato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Apoderado)
                .WithRequired(e => e.Curso)
                .HasForeignKey(e => e.CodigoCurso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Contrato)
                .WithOptional(e => e.Curso)
                .HasForeignKey(e => e.CodigoCurso);

            modelBuilder.Entity<DetallePago>()
                .HasOptional(e => e.PagoDeposito)
                .WithRequired(e => e.DetallePago);

            modelBuilder.Entity<PaqueteTuristico>()
                .HasMany(e => e.Contrato)
                .WithOptional(e => e.PaqueteTuristico)
                .HasForeignKey(e => e.CodigoPaqueteTuristico);

            modelBuilder.Entity<Persona>()
                .HasOptional(e => e.Apoderado)
                .WithRequired(e => e.Persona);

            modelBuilder.Entity<Persona>()
                .HasOptional(e => e.Representante)
                .WithRequired(e => e.Persona);

            modelBuilder.Entity<Representante>()
                .HasMany(e => e.Curso)
                .WithRequired(e => e.Representante)
                .HasForeignKey(e => e.RutRepresentante)
                .WillCascadeOnDelete(false);
        }
    }
}
