using System;
using BrowserTravel.LibraryTravel.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BrowserTravel.LibraryTravel.Infrastructure.Data
{
    public partial class LibraryTravelContext : DbContext
    {
        public LibraryTravelContext()
        {
        }

        public LibraryTravelContext(DbContextOptions<LibraryTravelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<AutoresHasLibro> AutoresHasLibros { get; set; }
        public virtual DbSet<Editoriale> Editoriales { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.ToTable("autores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<AutoresHasLibro>(entity =>
            {
                entity.ToTable("autores_has_libros");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAutores).HasColumnName("id_autores");

                entity.Property(e => e.IdLibro).HasColumnName("id_libro");

                entity.HasOne(d => d.IdAutoresNavigation)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.IdAutores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Autores_has_libros");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.IdLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Editorial_has_libros");
            });

            modelBuilder.Entity<Editoriale>(entity =>
            {
                entity.ToTable("editoriales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sede)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("sede");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("libros");

                entity.HasIndex(e => e.Isbn, "indexISBN")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdEditorial).HasColumnName("id_editorial");

                entity.Property(e => e.Isbn).HasColumnName("isbn");

                entity.Property(e => e.NPaginas)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("n_paginas");

                entity.Property(e => e.Sinopsis)
                    .HasColumnType("text")
                    .HasColumnName("sinopsis");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdEditorialNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdEditorial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Editorial");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
