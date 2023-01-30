using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiExamen.Data
{
    public partial class ExamendbContext : DbContext
    {
        public ExamendbContext()
        {
        }

        public ExamendbContext(DbContextOptions<ExamendbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<ArticuloTiendum> ArticuloTienda { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClienteArticulo> ClienteArticulos { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tienda2> Tienda { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Database=Examendb; User=sa; Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodigoCn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CodigoCN");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArticuloTiendum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdArticulo).HasColumnName("idArticulo");

                entity.Property(e => e.IdTienda).HasColumnName("idTienda");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdArticulo)
                    .HasConstraintName("FK_ArticuloTienda_Articulos");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTienda)
                    .HasConstraintName("FK_ArticuloTienda_Tienda");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClienteArticulo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClienteArticulo");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdArticulo).HasColumnName("idArticulo");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdArticulo)
                    .HasConstraintName("FK_ClienteArticulo_Articulos");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_ClienteArticulo_Clientes");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RolName).HasMaxLength(50);
            });

            modelBuilder.Entity<Tienda2>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.GivenName).HasMaxLength(50);

                entity.Property(e => e.IdUser).HasMaxLength(10);

                entity.Property(e => e.Password).HasMaxLength(10);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_UserRoles_Roles");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_UserRoles_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
