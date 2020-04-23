﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ecommerce.Domain.Models
{
    public partial class ProductsManagerContext : DbContext
    {
        public ProductsManagerContext()
        {
        }

        public ProductsManagerContext(DbContextOptions<ProductsManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulo { get; set; }
        public virtual DbSet<ArticuloTipo> ArticuloTipo { get; set; }
        public virtual DbSet<Lote> Lote { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<ArticuloTipo> ArticuloTipos { get; set; }
        public virtual DbSet<LoteHistorial> LoteHistoriales { get; set; }
        public virtual DbSet<UserArticle> UserArticles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;database=ProductsManager;user=usrpm;password=usrpm");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.NumeroSerie).IsUnicode(false);

                entity.Property(e => e.UsuarioAdjudicado).IsUnicode(false);

                entity.HasOne(d => d.IdLoteNavigation)
                    .WithMany(p => p.Articulo)
                    .HasForeignKey(d => d.IdLote)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articulo_Lote");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Articulo)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articulo_ArticuloTipo");
            });

            modelBuilder.Entity<ArticuloTipo>(entity =>
            {
                entity.Property(e => e.Codigo).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.NombreImagen).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Apellido).IsUnicode(false);

                entity.Property(e => e.Clave).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Usuario1).IsUnicode(false);
            });

            modelBuilder.Entity<ArticuloTipo>().HasData(
                new ArticuloTipo { Descripcion = "CPU", Id = 1 },
                new ArticuloTipo { Descripcion = "Teclado", Id = 2 },
                new ArticuloTipo { Descripcion = "Monitor", Id = 3 },
                new ArticuloTipo { Descripcion = "Notebook", Id = 4 },
                new ArticuloTipo { Descripcion = "Mouse", Id = 5 }
                );
        }
    }
}
