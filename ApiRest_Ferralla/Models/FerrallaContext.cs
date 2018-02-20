using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiRest_Ferralla.Models
{
    public partial class FerrallaContext : DbContext
    {
        public virtual DbSet<Articulo> Articulo { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<ImagenArticulo> ImagenArticulo { get; set; }
        public virtual DbSet<TipoArticulo> TipoArticulo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning        To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=XONE_DESARROLLO\SQLEXPRESS;Database=Ferralla;User Id=sa;Password=Root1;");
//            }
//        }

        public FerrallaContext(DbContextOptions<FerrallaContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasIndex(e => e.TipoArticuloId)
                    .HasName("IX_FK_TipoArticuloArticulo");

                entity.Property(e => e.Anho).IsRequired();

                entity.Property(e => e.Contratista).IsRequired();

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fechaCreacion")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('01/01/1990')");

                entity.Property(e => e.Lugar).IsRequired();

                entity.Property(e => e.TipoArticuloId).HasDefaultValueSql("((1))");

            });


            modelBuilder.Entity<ImagenArticulo>(entity =>
            {
                entity.HasIndex(e => e.ArticuloId)
                    .HasName("IX_FK_ArticuloImagenArticulo");

                entity.Property(e => e.Ruta).IsRequired();

                //entity.HasOne(d => d.Articulo)
                //    .WithMany(p => p.ImagenArticulo)
                //    .HasForeignKey(d => d.ArticuloId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_ArticuloImagenArticulo");
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.Property(e => e.Apellidos).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Nombre).IsRequired();

                entity.Property(e => e.Texto).IsRequired();
            });

            modelBuilder.Entity<TipoArticulo>(entity =>
            {
                entity.Property(e => e.TipoArticulo1)
                    .IsRequired()
                    .HasColumnName("tipoArticulo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Login).IsRequired();

                entity.Property(e => e.Nombre).IsRequired();

                entity.Property(e => e.Password).IsRequired();
            });
        }
    }
}
