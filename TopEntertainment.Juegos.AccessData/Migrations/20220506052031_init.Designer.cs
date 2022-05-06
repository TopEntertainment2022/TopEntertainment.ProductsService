﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopEntertainment.Juegos.AccessData;

#nullable disable

namespace TopEntertainment.Juegos.AccessData.Migrations
{
    [DbContext(typeof(JuegosContext))]
    [Migration("20220506052031_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TopEntertainment.Juegos.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            Descripcion = "Juegos de plataforma y aventuras.",
                            NombreCategoria = "Platformer"
                        },
                        new
                        {
                            CategoriaId = 2,
                            Descripcion = "Juegos de disparos.",
                            NombreCategoria = "FPS"
                        },
                        new
                        {
                            CategoriaId = 3,
                            Descripcion = "Juegos de Rol y Estrategia.",
                            NombreCategoria = "RPG"
                        });
                });

            modelBuilder.Entity("TopEntertainment.Juegos.Domain.Entities.Clasificacion", b =>
                {
                    b.Property<int>("ClasificacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClasificacionId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("NombreClasificacion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("ClasificacionId");

                    b.ToTable("Clasificacion", (string)null);

                    b.HasData(
                        new
                        {
                            ClasificacionId = 1,
                            Descripcion = "Apto para todo público.",
                            NombreClasificacion = "E for Everyone."
                        },
                        new
                        {
                            ClasificacionId = 2,
                            Descripcion = "Apto para mayores de 13 años.",
                            NombreClasificacion = "PG 13"
                        });
                });

            modelBuilder.Entity("TopEntertainment.Juegos.Domain.Entities.Imagen", b =>
                {
                    b.Property<int>("ImagenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImagenId"), 1L, 1);

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("JuegoId")
                        .HasColumnType("int");

                    b.HasKey("ImagenId");

                    b.HasIndex("JuegoId");

                    b.ToTable("Imagenes");

                    b.HasData(
                        new
                        {
                            ImagenId = 1,
                            ImagenUrl = "https://i.imgur.com/4Hk05rT.png",
                            JuegoId = 1
                        },
                        new
                        {
                            ImagenId = 2,
                            ImagenUrl = "https://i.imgur.com/86iraFT.png",
                            JuegoId = 2
                        });
                });

            modelBuilder.Entity("TopEntertainment.Juegos.Domain.Entities.Juego", b =>
                {
                    b.Property<int>("JuegoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JuegoId"), 1L, 1);

                    b.Property<int>("ClasificacionId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("EnOferta")
                        .HasColumnType("bit");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("PlataformaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,0)");

                    b.Property<bool>("SoftDelete")
                        .HasColumnType("bit");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Video")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.HasKey("JuegoId");

                    b.HasIndex("ClasificacionId");

                    b.HasIndex("PlataformaId");

                    b.ToTable("Juego", (string)null);

                    b.HasData(
                        new
                        {
                            JuegoId = 1,
                            ClasificacionId = 1,
                            Descripcion = "Juegos clásicos de Sonic remasterizados.",
                            EnOferta = false,
                            NombreProducto = "Sonic Origins",
                            PlataformaId = 1,
                            Precio = 45m,
                            SoftDelete = false,
                            Stock = 10,
                            Video = "https://www.youtube.com/watch?v=ZzHXjAJ86Zw"
                        },
                        new
                        {
                            JuegoId = 2,
                            ClasificacionId = 1,
                            Descripcion = "Juego de Crash más reciente.",
                            EnOferta = false,
                            NombreProducto = "Crash Bandicoot 4: It’s About Time",
                            PlataformaId = 2,
                            Precio = 30m,
                            SoftDelete = false,
                            Stock = 20,
                            Video = "https://www.youtube.com/watch?v=aOGwx3Ju6QQ"
                        });
                });

            modelBuilder.Entity("TopEntertainment.Juegos.Domain.Entities.Plataforma", b =>
                {
                    b.Property<int>("PlataformaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlataformaId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("NombrePlataforma")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("PlataformaId");

                    b.ToTable("Plataforma", (string)null);

                    b.HasData(
                        new
                        {
                            PlataformaId = 1,
                            Descripcion = "Consola de Sony de última generación.",
                            NombrePlataforma = "PlayStation 5"
                        },
                        new
                        {
                            PlataformaId = 2,
                            Descripcion = "Consola Económica de Microsoft de última generación.",
                            NombrePlataforma = "Xbox Series S"
                        });
                });

            modelBuilder.Entity("TopEntertainment.Juegos.Domain.Entities.ProductoCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("JuegoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("JuegoId");

                    b.ToTable("Producto_Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriaId = 1,
                            JuegoId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoriaId = 1,
                            JuegoId = 2
                        });
                });

            modelBuilder.Entity("TopEntertainment.Juegos.Domain.Entities.Imagen", b =>
                {
                    b.HasOne("TopEntertainment.Juegos.Domain.Entities.Juego", "Juego")
                        .WithMany()
                        .HasForeignKey("JuegoId")
                        .IsRequired();

                    b.Navigation("Juego");
                });

            modelBuilder.Entity("TopEntertainment.Juegos.Domain.Entities.Juego", b =>
                {
                    b.HasOne("TopEntertainment.Juegos.Domain.Entities.Clasificacion", "Clasificacion")
                        .WithMany("Juegos")
                        .HasForeignKey("ClasificacionId")
                        .IsRequired();

                    b.HasOne("TopEntertainment.Juegos.Domain.Entities.Plataforma", "Plataforma")
                        .WithMany("Juegos")
                        .HasForeignKey("PlataformaId")
                        .IsRequired();

                    b.Navigation("Clasificacion");

                    b.Navigation("Plataforma");
                });

            modelBuilder.Entity("TopEntertainment.Juegos.Domain.Entities.ProductoCategoria", b =>
                {
                    b.HasOne("TopEntertainment.Juegos.Domain.Entities.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .IsRequired();

                    b.HasOne("TopEntertainment.Juegos.Domain.Entities.Juego", "Juego")
                        .WithMany()
                        .HasForeignKey("JuegoId")
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Juego");
                });

            modelBuilder.Entity("TopEntertainment.Juegos.Domain.Entities.Clasificacion", b =>
                {
                    b.Navigation("Juegos");
                });

            modelBuilder.Entity("TopEntertainment.Juegos.Domain.Entities.Plataforma", b =>
                {
                    b.Navigation("Juegos");
                });
#pragma warning restore 612, 618
        }
    }
}
