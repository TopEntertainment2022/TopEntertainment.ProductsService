using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.AccessData
{
    public class JuegosContext : DbContext
    {
        public JuegosContext() { }

        public JuegosContext(DbContextOptions<JuegosContext> options) : base(options) { }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Clasificacion> Clasificaciones { get; set; }
        public virtual DbSet<Imagen> Imagenes { get; set; }
        public virtual DbSet<Juego> Juegos { get; set; }
        public virtual DbSet<Plataforma> Plataformas { get; set; }
        public virtual DbSet<ProductoCategoria> ProductoCategoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CategoriaId);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCategoria)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clasificacion>(entity =>
            {
                entity.ToTable("Clasificacion");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreClasificacion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Imagen>(entity =>
            {
                entity.Property(e => e.ImagenUrl)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Juego)
                    .WithMany()
                    .HasForeignKey(d => d.JuegoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Juego>(entity =>
            {
                entity.ToTable("Juego");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);


                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Video)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Clasificacion)
                    .WithMany(p => p.Juegos)
                    .HasForeignKey(d => d.ClasificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Plataforma)
                    .WithMany(p => p.Juegos)
                    .HasForeignKey(d => d.PlataformaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Plataforma>(entity =>
            {
                entity.ToTable("Plataforma");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePlataforma)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductoCategoria>(entity =>
            {
                entity.ToTable("Producto_Categoria");

                entity.HasOne(d => d.Categoria)
                    .WithMany()
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Juego)
                    .WithMany()
                    .HasForeignKey(d => d.JuegoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            //INSERTS

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria 
                { 
                    CategoriaId = 1,
                    NombreCategoria = "Platformer",
                    Descripcion = "Juegos de plataforma y aventuras."
                },
                
                new Categoria
                {
                    CategoriaId = 2,
                    NombreCategoria = "FPS",
                    Descripcion = "Juegos de disparos."
                },

                new Categoria
                {
                    CategoriaId = 3,
                    NombreCategoria = "RPG",
                    Descripcion = "Juegos de Rol y Estrategia."
                }
            );

            modelBuilder.Entity<Clasificacion>().HasData(
                new Clasificacion
                {
                    ClasificacionId = 1,
                    NombreClasificacion = "E for Everyone.",
                    Descripcion = "Apto para todo público."
                },

                new Clasificacion
                {
                    ClasificacionId = 2,
                    NombreClasificacion = "PG 13",
                    Descripcion = "Apto para mayores de 13 años."
                }
            );

            modelBuilder.Entity<Plataforma>().HasData(
                
                new Plataforma
                {
                    PlataformaId = 1,
                    NombrePlataforma = "PlayStation 5",
                    Descripcion = "Consola de Sony de última generación."
                },

                new Plataforma
                {
                    PlataformaId = 2,
                    NombrePlataforma = "Xbox Series S",
                    Descripcion = "Consola Económica de Microsoft de última generación."
                }
            );

            modelBuilder.Entity<Juego>().HasData(

                new Juego
                {
                    JuegoId = 1,
                    PlataformaId = 1,
                    ClasificacionId = 1,
                    NombreProducto = "Sonic Origins",
                    Precio = 45,
                    Stock = 10,
                    Descripcion = "Juegos clásicos de Sonic remasterizados.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/watch?v=ZzHXjAJ86Zw"
                },

                new Juego
                {
                    JuegoId = 2,
                    PlataformaId = 2,
                    ClasificacionId = 1,
                    NombreProducto = "Crash Bandicoot 4: It’s About Time",
                    Precio = 30,
                    Stock = 20,
                    Descripcion = "Juego de Crash más reciente.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/watch?v=aOGwx3Ju6QQ"
                }
            );

            modelBuilder.Entity<ProductoCategoria>().HasData(

                new ProductoCategoria
                {
                    Id = 1,
                    JuegoId = 1,
                    CategoriaId = 1
                },

                new ProductoCategoria
                {
                    Id=2,
                    JuegoId = 2,
                    CategoriaId = 1
                }
            );

            modelBuilder.Entity<Imagen>().HasData(

                new Imagen
                {
                    ImagenId = 1,
                    JuegoId= 1,
                    ImagenUrl = "https://i.imgur.com/4Hk05rT.png"
                },

                new Imagen
                {
                    ImagenId= 2,
                    JuegoId = 2,
                    ImagenUrl = "https://i.imgur.com/86iraFT.png"
                }
            );
        }
    }
}
