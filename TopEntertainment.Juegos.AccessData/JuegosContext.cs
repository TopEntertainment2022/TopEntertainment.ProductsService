using Microsoft.EntityFrameworkCore;
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
                               NombreCategoria = "Accion",
                               Descripcion = "https://e7.pngegg.com/pngimages/136/884/png-clipart-clear-vision-3-sniper-shooter-clear-vision-2-sniper-fury-sniper-3d-gun-shooter-free-bullet-shooting-games-sniper-lens-android-sniper-fury.png"
                           },

                           new Categoria
                           {
                               CategoriaId = 2,
                               NombreCategoria = "Aventura",
                               Descripcion = "https://cdn.hobbyconsolas.com/sites/navi.axelspringer.es/public/styles/hc_1440x810/public/media/image/2017/12/mejores-juegos-accion-aventura-2018.jpg?itok=8GmFr_E5"
                           },

                           new Categoria
                           {
                               CategoriaId = 3,
                               NombreCategoria = "Estrategia",
                               Descripcion = "https://thumbs.dreamstime.com/b/icono-de-reglas-juego-elemento-simple-la-colecci%C3%B3n-desarrollo-juegos-rellenas-para-plantillas-infograf%C3%ADas-y-m%C3%A1s-signo-creativo-193118532.jpg"
                           },
                           new Categoria
                           {
                               CategoriaId = 4,
                               NombreCategoria = "Disparos",
                               Descripcion = "https://alfabetajuega.com/hero/2021/04/battlefield-bad-company-2.jpg?width=1200&aspect_ratio=1200:631"
                           },

                           new Categoria
                           {
                               CategoriaId = 5,
                               NombreCategoria = "Terror",
                               Descripcion = "https://img.captain-droid.com/wp-content/uploads/2017/11/eyes-icon.png"
                           },

                           new Categoria
                           {
                               CategoriaId = 6,
                               NombreCategoria = "Casual",
                               Descripcion = "https://is2-ssl.mzstatic.com/image/thumb/Purple62/v4/ba/ab/f5/baabf5f7-0bc7-5ae1-9de3-85a71b389617/mzl.yixomytg.png/230x0w.png"
                           },

                           new Categoria
                           {
                               CategoriaId = 7,
                               NombreCategoria = "Plataforma",
                               Descripcion = "https://img.freepik.com/vector-gratis/pad-juego-moderno-alambre-videojuegos-joystick-3d-azul-videoconsola-fondo-simbolos-geometricos-dinamicos-concepto-juegos-computadora-diseno-su-plantilla-ilustracion-vectorial_185386-790.jpg?w=360"
                           },

                           new Categoria
                           {
                               CategoriaId = 8,
                               NombreCategoria = "Supervivencia",
                               Descripcion = "https://www.androidsis.com/wp-content/uploads/2018/02/Juegos-de-supervivencia.png"
                           },

                           new Categoria
                           {
                               CategoriaId = 9,
                               NombreCategoria = "Mundo Abierto",
                               Descripcion = "https://w7.pngwing.com/pngs/118/906/png-transparent-video-game-platform-game-5-miscellaneous-game-video-game-thumbnail.png"
                           },

                           new Categoria
                           {
                               CategoriaId = 10,
                               NombreCategoria = "Primera Persona",
                               Descripcion = "https://as01.epimg.net/meristation/imagenes/2018/09/15/reportajes/1537047527_669497_1537047584_sumario_normal.jpg"
                           },

                           new Categoria
                           {
                               CategoriaId = 11,
                               NombreCategoria = "Simulacion",
                               Descripcion = "https://c8.alamy.com/compes/2cb364b/icono-juego-de-simulacion-elemento-simple-de-la-coleccion-de-desarrollo-de-juegos-icono-de-juego-de-simulacion-relleno-para-plantillas-infografias-y-mucho-mas-2cb364b.jpg"
                           },

                           new Categoria
                           {
                               CategoriaId = 12,
                               NombreCategoria = "Carrera",
                               Descripcion = "https://static.vecteezy.com/system/resources/previews/004/976/735/non_2x/gaming-accessory-glyph-icon-pc-steering-wheel-esports-device-gadget-for-driving-simulation-game-racing-silhouette-symbol-negative-space-isolated-illustration-vector.jpg"
                           }

                       );

            modelBuilder.Entity<Clasificacion>().HasData(
                new Clasificacion
                {
                    ClasificacionId = 1,
                    NombreClasificacion = "E for Everyone.",
                    Descripcion = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b8/ESRB_2013_Everyone_Spanish.svg/800px-ESRB_2013_Everyone_Spanish.svg.png"
                },

                new Clasificacion
                {
                    ClasificacionId = 2,
                    NombreClasificacion = "PG 16",
                    Descripcion = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/ESRB_2013_Teen_Spanish.svg/800px-ESRB_2013_Teen_Spanish.svg.png"
                },

                 new Clasificacion
                 {
                     ClasificacionId = 3,
                     NombreClasificacion = "PG 18",
                     Descripcion = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/60/ESRB_2013_Adults_Only_Spanish.svg/800px-ESRB_2013_Adults_Only_Spanish.svg.png"
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
                               NombrePlataforma = "PlayStation 4",
                               Descripcion = "Consola de Sony de última generación."
                           },

                           new Plataforma
                           {
                               PlataformaId = 3,
                               NombrePlataforma = "Xbox Series S",
                               Descripcion = "Consola Económica de Microsoft de última generación."
                           },

                           new Plataforma
                           {
                               PlataformaId = 4,
                               NombrePlataforma = "Xbox One",
                               Descripcion = "Consola Económica de Microsoft de última generación."
                           },

                           new Plataforma
                           {
                               PlataformaId = 5,
                               NombrePlataforma = "PC",
                               Descripcion = "Computadora de Escritorio o Notebook Gamer"
                           },

                           new Plataforma
                           {
                               PlataformaId = 6,
                               NombrePlataforma = "Nintendo Switch",
                               Descripcion = "Consola Portatil Nintendo Switch de última generación."
                           }
                       );

            modelBuilder.Entity<Juego>().HasData(

                new Juego
                {
                    JuegoId = 1,
                    PlataformaId = 4,
                    ClasificacionId = 1,
                    NombreProducto = "Sonic Origins",
                    Precio = 40,
                    Stock = 10,
                    Descripcion = "Juegos clásicos de Sonic remasterizados.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/ZzHXjAJ86Zw"
                },

                new Juego
                {
                    JuegoId = 2,
                    PlataformaId = 2,
                    ClasificacionId = 1,
                    NombreProducto = "Crash Bandicoot 4: It’s About Time",
                    Precio = 10,
                    Stock = 20,
                    Descripcion = "Juego de Crash más reciente.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/aOGwx3Ju6QQ"
                },

                new Juego
                {
                    JuegoId = 3,
                    PlataformaId = 1,
                    ClasificacionId = 3,
                    NombreProducto = "God of War",
                    Precio = 40,
                    Stock = 10,
                    Descripcion = "Kratos ha dejado atras su venganza contra los dioses del Olimpo y vive ahora como un hombre en los dominios de los dioses y monstruos nordicos.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/d8HmwZSskvY"
                },

                new Juego
                {
                    JuegoId = 4,
                    PlataformaId = 4,
                    ClasificacionId = 1,
                    NombreProducto = "Redout: Enhanced Edition",
                    Precio = 4,
                    Stock = 10,
                    Descripcion = "Redout es un tributo a los clásicos juegos de carreras.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/kcuFK7Xadyc"
                },

                new Juego
                {
                    JuegoId = 5,
                    PlataformaId = 5,
                    ClasificacionId = 1,
                    NombreProducto = "Fall Guys",
                    Precio = 10,
                    Stock = 10,
                    Descripcion = "Fall Guys es un party royale gratis y multiplataforma donde los jugadores compiten en delirantes carreras de obstáculos formadas por rondas cada vez más emocionantes hasta que una sola persona se alza con la victoria.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/KNDf4J4wmxs"
                },

                new Juego
                {
                    JuegoId = 6,
                    PlataformaId = 4,
                    ClasificacionId = 1,
                    NombreProducto = "LEGO® Star Wars™: La Saga Skywalker",
                    Precio = 50,
                    Stock = 10,
                    Descripcion = "Crea un equipo con hasta 3 amigos en Tom Clancy's Ghost Recon® Wildlands y disfruta del shooter militar definitivo en un enorme y peligroso mundo abierto.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/watch?v=kuYiHhx1_mw"
                },

                new Juego
                {
                    JuegoId = 7,
                    PlataformaId = 6,
                    ClasificacionId = 2,
                    NombreProducto = "Skul: The Hero Slayer",
                    Precio = 4,
                    Stock = 10,
                    Descripcion = "Guía a Skul en su mision para enfrentarse el solo al Ejercito Imperial y rescatar a su rey en un roguelite en 2D de plataformas cargado de accion que pasara a la historia.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/7uU1mOhOTH8"
                },

                new Juego
                {
                    JuegoId = 8,
                    PlataformaId = 6,
                    ClasificacionId = 1,
                    NombreProducto = "Tetris® Effect: Connected",
                    Precio = 8,
                    Stock = 10,
                    Descripcion = "Tetris® Effect: Connected amplía con una nueva y potente expansión multijugador la inmensa variedad de adictivos e innovadores modos de juego por los que se conoce a Tetris Effect.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/CCBpwyS0E1o"
                },

                new Juego
                {
                    JuegoId = 9,
                    PlataformaId = 5,
                    ClasificacionId = 1,
                    NombreProducto = "Car Mechanic Simulator 2018",
                    Precio = 4,
                    Stock = 10,
                    Descripcion = "Construye y amplía tu imperio de servicios de reparación en este juego de simulación increíblemente detallado y realista, donde la atención a los detalles de los coches es asombrosa.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/LCTF8wKWFSU"
                },

                new Juego
                {
                    JuegoId = 10,
                    PlataformaId = 5,
                    ClasificacionId = 2,
                    NombreProducto = "VALORANT",
                    Precio = 0,
                    Stock = 20,
                    Descripcion = "VALORANT es un shooter táctico 5v5 basado en personajes que está ambientado en un escenario internacional.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/KbFWhffLM-A"
                },

                new Juego
                {
                    JuegoId = 11,
                    PlataformaId = 5,
                    ClasificacionId = 2,
                    NombreProducto = "NARAKA: BLADEPOINT",
                    Precio = 20,
                    Stock = 20,
                    Descripcion = "NARAKA: BLADEPOINT es un título de lucha y acción mítica JcJ en el que hasta 60 jugadores se enfrentan en combates cuerpo a cuerpo de artes marciales.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/Q_uBBXiqL1s"
                },

                new Juego
                {
                    JuegoId = 12,
                    PlataformaId = 3,
                    ClasificacionId = 1,
                    NombreProducto = "Roller Champions",
                    Precio = 0,
                    Stock = 20,
                    Descripcion = "Patina y rueda hasta la victoria en Roller Champions. Descubre un juego deportivo JcJ por equipos y gratuito unico en su especie!",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/vdKJQBf2lL0"
                },

                new Juego
                {
                    JuegoId = 13,
                    PlataformaId = 4,
                    ClasificacionId = 1,
                    NombreProducto = "STAR WARS Battlefront II",
                    Precio = 40,
                    Stock = 20,
                    Descripcion = "Pon a prueba tu dominio del bláster, la espada láser y la Fuerza online y offline en STAR WARS Battlefront II: Celebration Edition.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/qbVsjbBllKQ"
                },

                new Juego
                {
                    JuegoId = 14,
                    PlataformaId = 1,
                    ClasificacionId = 3,
                    NombreProducto = "Wolfenstein: The New Order",
                    Precio = 13,
                    Stock = 20,
                    Descripcion = "Wolfenstein®: The New Order revitaliza la serie que creó el género de los shooters en primera persona.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/nidCcGtPLOQ"
                },

                new Juego
                {
                    JuegoId = 15,
                    PlataformaId = 1,
                    ClasificacionId = 3,
                    NombreProducto = "Hood: Outlaws & Legends",
                    Precio = 12,
                    Stock = 20,
                    Descripcion = "Supera a las bandas rivales en un mundo medieval y violento de intensos asaltos multijugador JcJcE.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/o26rvJIBLno"
                },

                new Juego
                {
                    JuegoId = 16,
                    PlataformaId = 3,
                    ClasificacionId = 2,
                    NombreProducto = "Tiny Tina's Wonderlands",
                    Precio = 60,
                    Stock = 20,
                    Descripcion = "¡Embárcate en una increíble aventura llena de extravagancias, asombro y armamento de alta potencia! Crea a tu propio héroe multiclase y saquea, dispara, corta y lanza hechizos para detener al Señor de los Dragones.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/AwFCFG9aBr8"
                },

                new Juego
                {
                    JuegoId = 17,
                    PlataformaId = 5,
                    ClasificacionId = 3,
                    NombreProducto = "BioShock Remastered",
                    Precio = 15,
                    Stock = 20,
                    Descripcion = "Explora la ciudad submarina de Rapture, un refugio para las mentes más brillantes de la sociedad que se ha transformado en una pesadilla distópica por culpa del orgullo desmedido de un hombre.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/BeP35Jw2_ho"
                },

                new Juego
                {
                    JuegoId = 18,
                    PlataformaId = 4,
                    ClasificacionId = 1,
                    NombreProducto = "ARK: Survival Evolved",
                    Precio = 6,
                    Stock = 20,
                    Descripcion = "Despiertas en la orilla de una isla misteriosa en la que debes aprender a sobrevivir. Usa tu inteligencia para matar o domar a las criaturas primitivas que vagan por el lugar.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/FW9vsrPWujI"
                },

                new Juego
                {
                    JuegoId = 19,
                    PlataformaId = 4,
                    ClasificacionId = 2,
                    NombreProducto = "theHunter: Call of the Wild™",
                    Precio = 4,
                    Stock = 20,
                    Descripcion = "Disfruta de un juego de caza con una ambientación sin igual en un mundo abierto realista y visualmente asombroso. Sumérgete en la atmósfera de la campaña individual, o comparte la experiencia de caza definitiva con tus amigos.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/VGOTYfGMyoE"
                },

                new Juego
                {
                    JuegoId = 20,
                    PlataformaId = 3,
                    ClasificacionId = 2,
                    NombreProducto = "Chivalry 2",
                    Precio = 8,
                    Stock = 20,
                    Descripcion = "Chivalry 2 es un juego multijugador de batallas en primera persona inspiradas en las películas de estilo medieval.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/HKlYVpCuab0"
                },

                new Juego
                {
                    JuegoId = 21,
                    PlataformaId = 6,
                    ClasificacionId = 1,
                    NombreProducto = "Hextech Mayhem",
                    Precio = 7,
                    Stock = 20,
                    Descripcion = "En este trepidante juego de avance rítmico, toda acción tiene una reacción explosiva ¡y todo caos es poco! Poneos en el pelaje de Ziggs, un experto en hexplosivos, conforme desatáis el caos a través de los barrios de Piltover.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/q6eWS8OEJiE"
                },

                new Juego
                {
                    JuegoId = 22,
                    PlataformaId = 3,
                    ClasificacionId = 1,
                    NombreProducto = "It Takes Two",
                    Precio = 40,
                    Stock = 20,
                    Descripcion = "Embárcate en la aventura de tu vida en It Takes Two. Invita a un amigo a acompañarte gratis con el Pase de amigo* para colaborar en una gran variedad de desafíos deliciosamente rompedores.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/ohClxMmNLQQ"
                },

                new Juego
                {
                    JuegoId = 23,
                    PlataformaId = 4,
                    ClasificacionId = 1,
                    NombreProducto = "Kao the Kangaroo",
                    Precio = 30,
                    Stock = 20,
                    Descripcion = "Vive una aventura épica, domina los guantes y explora escenarios increíbles.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/fww1BuVIxzo"
                },

                new Juego
                {
                    JuegoId = 24,
                    PlataformaId = 5,
                    ClasificacionId = 2,
                    NombreProducto = "ELEX II",
                    Precio = 18,
                    Stock = 20,
                    Descripcion = "En esta secuela del RPG vintage de mundo abierto ELEX, Jax debe volver a unir a los pueblos libres del mundo de ciencia ficción y fantasía de Magalan contra una nueva amenaza, los Celestiales, que pretenden cambiar para siempre la faz del planeta.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/u49qSkdq2r8"
                },

                new Juego
                {
                    JuegoId = 25,
                    PlataformaId = 3,
                    ClasificacionId = 2,
                    NombreProducto = "THE KING OF FIGHTERS XV",
                    Precio = 29,
                    Stock = 20,
                    Descripcion = "¡REVIENTA TODAS LAS EXPECTATIVAS! ¡El nuevo XV que sobrepasa todo!",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/9FukK1ItSZE"
                },

                new Juego
                {
                    JuegoId = 26,
                    PlataformaId = 5,
                    ClasificacionId = 3,
                    NombreProducto = "Tomb Raider GOTY",
                    Precio = 20,
                    Stock = 20,
                    Descripcion = "Armada solo con su instinto y una capacidad de aguante más allá de los límites de la resistencia humana, Lara debe luchar para huir de una isla remota y descubrir su oscura historia.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/OJc5yDgJ7lk"
                },

                new Juego
                {
                    JuegoId = 27,
                    PlataformaId = 2,
                    ClasificacionId = 3,
                    NombreProducto = "Shadow of the Tomb Raider: Definitive Edition",
                    Precio = 40,
                    Stock = 20,
                    Descripcion = "En Shadow of the Tomb Raider: Definitive Edition, vive el capítulo final de la historia sobre el origen de Lara, en el que se convierte en la saqueadora de tumbas que está destinada a ser.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/zmihOPh3enA"
                },

                new Juego
                {
                    JuegoId = 28,
                    PlataformaId = 5,
                    ClasificacionId = 3,
                    NombreProducto = "Rise of the Tomb Raider: Edición 20 aniversario",
                    Precio = 30,
                    Stock = 20,
                    Descripcion = "Rise of the Tomb Raider: Edición 20 aniversario incluye el juego de base y el pase de temporada con contenido totalmente nuevo.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/SfGqfEkfhjE"
                },

                new Juego
                {
                    JuegoId = 29,
                    PlataformaId = 6,
                    ClasificacionId = 1,
                    NombreProducto = "Kirby y la tierra olvidada",
                    Precio = 23,
                    Stock = 20,
                    Descripcion = "Kirby y la tierra olvidada, titulado en inglés como Kirby and the Forgotten Land, es un videojuego de plataformas en 3D de la saga Kirby, desarrollado por HAL Laboratory y publicado por Nintendo para la videoconsola Nintendo Switch.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/ZKNYy6IOUSE"
                },

                new Juego
                {
                    JuegoId = 30,
                    PlataformaId = 6,
                    ClasificacionId = 1,
                    NombreProducto = "Pokémon escarlata y Pokémon púrpura",
                    Precio = 17,
                    Stock = 20,
                    Descripcion = "Pokémon Escarlata y Pokémon Púrpura son un par de videojuegos de rol en desarrollo por Game Freak. Su lanzamiento está previsto para finales de 2022, ​ siendo publicados por The Pokémon Company para Nintendo Switch.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/yGoVJM5lpK0"
                },

                new Juego
                {
                    JuegoId = 31,
                    PlataformaId = 6,
                    ClasificacionId = 1,
                    NombreProducto = "Teenage Mutant Ninja Turtles: Shredder's Revenge",
                    Precio = 27,
                    Stock = 20,
                    Descripcion = "Teenage Mutant Ninja Turtles: Shredder's Revenge es un juego de lucha desarrollado por Tribute Games y publicado por Dotemu.",
                    EnOferta = false,
                    SoftDelete = false,
                    Video = "https://www.youtube.com/embed/c87XkB05xtg"
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
                               Id = 2,
                               JuegoId = 1,
                               CategoriaId = 2
                           },
                           new ProductoCategoria
                           {
                               Id = 3,
                               JuegoId = 1,
                               CategoriaId = 6
                           },

                           new ProductoCategoria
                           {
                               Id = 4,
                               JuegoId = 2,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 5,
                               JuegoId = 3,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 6,
                               JuegoId = 3,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 7,
                               JuegoId = 4,
                               CategoriaId = 12
                           },

                           new ProductoCategoria
                           {
                               Id = 8,
                               JuegoId = 5,
                               CategoriaId = 6
                           },

                           new ProductoCategoria
                           {
                               Id = 9,
                               JuegoId = 5,
                               CategoriaId = 7
                           },

                           new ProductoCategoria
                           {
                               Id = 10,
                               JuegoId = 6,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 11,
                               JuegoId = 6,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 12,
                               JuegoId = 7,
                               CategoriaId = 7
                           },

                           new ProductoCategoria
                           {
                               Id = 13,
                               JuegoId = 7,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 14,
                               JuegoId = 8,
                               CategoriaId = 3
                           },

                           new ProductoCategoria
                           {
                               Id = 15,
                               JuegoId = 8,
                               CategoriaId = 6
                           },

                           new ProductoCategoria
                           {
                               Id = 16,
                               JuegoId = 9,
                               CategoriaId = 11
                           },

                           new ProductoCategoria
                           {
                               Id = 17,
                               JuegoId = 9,
                               CategoriaId = 12
                           },

                           new ProductoCategoria
                           {
                               Id = 18,
                               JuegoId = 10,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 19,
                               JuegoId = 10,
                               CategoriaId = 4
                           },

                           new ProductoCategoria
                           {
                               Id = 20,
                               JuegoId = 10,
                               CategoriaId = 10
                           },

                           new ProductoCategoria
                           {
                               Id = 21,
                               JuegoId = 11,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 22,
                               JuegoId = 11,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 23,
                               JuegoId = 11,
                               CategoriaId = 9
                           },

                           new ProductoCategoria
                           {
                               Id = 24,
                               JuegoId = 12,
                               CategoriaId = 12
                           },

                           new ProductoCategoria
                           {
                               Id = 25,
                               JuegoId = 13,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 26,
                               JuegoId = 13,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 27,
                               JuegoId = 14,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 28,
                               JuegoId = 14,
                               CategoriaId = 4
                           },

                           new ProductoCategoria
                           {
                               Id = 29,
                               JuegoId = 15,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 30,
                               JuegoId = 15,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 31,
                               JuegoId = 15,
                               CategoriaId = 3
                           },

                           new ProductoCategoria
                           {
                               Id = 32,
                               JuegoId = 15,
                               CategoriaId = 9
                           },



                           new ProductoCategoria
                           {
                               Id = 33,
                               JuegoId = 16,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 34,
                               JuegoId = 16,
                               CategoriaId = 4
                           },

                           new ProductoCategoria
                           {
                               Id = 35,
                               JuegoId = 16,
                               CategoriaId = 9
                           },

                           new ProductoCategoria
                           {
                               Id = 36,
                               JuegoId = 16,
                               CategoriaId = 10
                           },

                           new ProductoCategoria
                           {
                               Id = 37,
                               JuegoId = 17,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 38,
                               JuegoId = 17,
                               CategoriaId = 4
                           },

                           new ProductoCategoria
                           {
                               Id = 39,
                               JuegoId = 17,
                               CategoriaId = 10
                           },

                           new ProductoCategoria
                           {
                               Id = 40,
                               JuegoId = 18,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 41,
                               JuegoId = 18,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 42,
                               JuegoId = 18,
                               CategoriaId = 8
                           },

                           new ProductoCategoria
                           {
                               Id = 43,
                               JuegoId = 18,
                               CategoriaId = 9
                           },

                           new ProductoCategoria
                           {
                               Id = 44,
                               JuegoId = 18,
                               CategoriaId = 10
                           },

                           new ProductoCategoria
                           {
                               Id = 45,
                               JuegoId = 19,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 46,
                               JuegoId = 19,
                               CategoriaId = 9
                           },

                           new ProductoCategoria
                           {
                               Id = 47,
                               JuegoId = 19,
                               CategoriaId = 10
                           },

                           new ProductoCategoria
                           {
                               Id = 48,
                               JuegoId = 19,
                               CategoriaId = 11
                           },

                           new ProductoCategoria
                           {
                               Id = 49,
                               JuegoId = 20,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 50,
                               JuegoId = 20,
                               CategoriaId = 10
                           },

                           new ProductoCategoria
                           {
                               Id = 51,
                               JuegoId = 21,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 52,
                               JuegoId = 21,
                               CategoriaId = 6
                           },

                           new ProductoCategoria
                           {
                               Id = 53,
                               JuegoId = 22,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 54,
                               JuegoId = 22,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 55,
                               JuegoId = 23,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 56,
                               JuegoId = 23,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 57,
                               JuegoId = 23,
                               CategoriaId = 6
                           },

                           new ProductoCategoria
                           {
                               Id = 58,
                               JuegoId = 24,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 59,
                               JuegoId = 24,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 60,
                               JuegoId = 24,
                               CategoriaId = 9
                           },

                           new ProductoCategoria
                           {
                               Id = 61,
                               JuegoId = 25,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 62,
                               JuegoId = 25,
                               CategoriaId = 7
                           },

                           new ProductoCategoria
                           {
                               Id = 63,
                               JuegoId = 26,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 64,
                               JuegoId = 26,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 65,
                               JuegoId = 26,
                               CategoriaId = 9
                           },

                           new ProductoCategoria
                           {
                               Id = 66,
                               JuegoId = 27,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 67,
                               JuegoId = 27,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 68,
                               JuegoId = 27,
                               CategoriaId = 9
                           },

                           new ProductoCategoria
                           {
                               Id = 69,
                               JuegoId = 28,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 70,
                               JuegoId = 28,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 71,
                               JuegoId = 28,
                               CategoriaId = 9
                           },

                           new ProductoCategoria
                           {
                               Id = 72,
                               JuegoId = 29,
                               CategoriaId = 1
                           },

                           new ProductoCategoria
                           {
                               Id = 73,
                               JuegoId = 29,
                               CategoriaId = 2
                           },

                           new ProductoCategoria
                           {
                               Id = 74,
                               JuegoId = 29,
                               CategoriaId = 7
                           },


                           new ProductoCategoria
                           {
                               Id = 75,
                               JuegoId = 29,
                               CategoriaId = 9
                           },


                           new ProductoCategoria
                           {
                               Id = 76,
                               JuegoId = 30,
                               CategoriaId = 1
                           },


                           new ProductoCategoria
                           {
                               Id = 77,
                               JuegoId = 30,
                               CategoriaId = 2
                           },


                           new ProductoCategoria
                           {
                               Id = 78,
                               JuegoId = 30,
                               CategoriaId = 7
                           },


                           new ProductoCategoria
                           {
                               Id = 79,
                               JuegoId = 30,
                               CategoriaId = 9
                           },


                           new ProductoCategoria
                           {
                               Id = 80,
                               JuegoId = 31,
                               CategoriaId = 1
                           },


                           new ProductoCategoria
                           {
                               Id = 81,
                               JuegoId = 31,
                               CategoriaId = 2
                           },


                           new ProductoCategoria
                           {
                               Id = 82,
                               JuegoId = 31,
                               CategoriaId = 7
                           }, 
                           new ProductoCategoria
                           {
                               Id = 83,
                               JuegoId = 16,
                               CategoriaId = 1
                           }


                       );

            modelBuilder.Entity<Imagen>().HasData(


                new Imagen
                {
                    ImagenId = 1,
                    JuegoId = 1,
                    ImagenUrl = "https://i.imgur.com/4Hk05rT.png"
                },

                new Imagen
                {
                    ImagenId = 2,
                    JuegoId = 2,
                    ImagenUrl = "https://i.imgur.com/86iraFT.png"
                },

                new Imagen
                {
                    ImagenId = 3,
                    JuegoId = 3,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-godofwar-santamonicastudio-g1a-02-1920x1080-f7c6fef5c876.jpg?h=720&resize=1&w=1280"
                },

                new Imagen
                {
                    ImagenId = 4,
                    JuegoId = 3,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-godofwar-santamonicastudio-g1a-01-1920x1080-c84d2a96aea3.jpg"
                },

                new Imagen
                {
                    ImagenId = 5,
                    JuegoId = 3,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-godofwar-santamonicastudio-g1a-03-1920x1080-65b80475ae32.jpg?h=720&resize=1&w=1280"
                },

                new Imagen
                {
                    ImagenId = 6,
                    JuegoId = 4,
                    ImagenUrl = "https://cdn1.epicgames.com/offer/93ea0d593cb04e62afb0741bbf894173/EGS_RedoutEnhancedEdition_34BigThingssrl_S1_2560x1440-23ab955c6537efdd53e1f407609f9036?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 7,
                    JuegoId = 4,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-redoutenhancededition-34bigthingssrl-g1a-01-1920x1080-6e1e9ea24bd5.jpg"
                },

                new Imagen
                {
                    ImagenId = 8,
                    JuegoId = 4,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-redoutenhancededition-34bigthingssrl-g1a-02-1920x1080-8eb05ed7cc60.jpg"
                },

                new Imagen
                {
                    ImagenId = 9,
                    JuegoId = 4,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-redoutenhancededition-34bigthingssrl-g1a-03-1920x1080-b48ac6857dfe.jpg"
                },

                new Imagen
                {
                    ImagenId = 10,
                    JuegoId = 5,
                    ImagenUrl = "https://cdn2.unrealengine.com/es-es-fallguysss1-productofferabout-1920x1080-1920x1080-a204121647bc.jpg"
                },

                new Imagen
                {
                    ImagenId = 11,
                    JuegoId = 5,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-fallguys-mediatonic-g1a-01-1920x1080-063acacc6f1a.jpg"
                },

                new Imagen
                {
                    ImagenId = 12,
                    JuegoId = 5,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-fallguys-mediatonic-g1a-02-1920x1080-a5f24303b646.jpg"
                },

                new Imagen
                {
                    ImagenId = 13,
                    JuegoId = 6,
                    ImagenUrl = "https://cdn1.epicgames.com/offer/9c59efaabb6a48f19b3485d5d9416032/EGS_LEGOStarWarsTheSkywalkerSaga_TTGames_S1_2560x1440-ae89e9c91aec1e461148f93f25b828ed?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 14,
                    JuegoId = 6,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-legostarwarstheskywalkersaga-ttgames-g1a-00-1920x1080-487a6e965579.jpg"
                },

                new Imagen
                {
                    ImagenId = 15,
                    JuegoId = 6,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-legostarwarstheskywalkersaga-ttgames-g1a-01-1920x1080-5da07b4a7838.jpg"
                },

                new Imagen
                {
                    ImagenId = 16,
                    JuegoId = 6,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-legostarwarstheskywalkersaga-ttgames-g1a-02-1920x1080-38aa896e6f5f.jpg"
                },

                new Imagen
                {
                    ImagenId = 17,
                    JuegoId = 7,
                    ImagenUrl = "https://cdn1.epicgames.com/salesEvent/salesEvent/Daffodil_1P_Awareness_INT_Epic_2560x1440_2560x1440-ba126bdeac3faab0596b7c56e9c09990?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 18,
                    JuegoId = 7,
                    ImagenUrl = "https://cdn2.unrealengine.com/ttwl-gameplay-reveal-screenshots-banshee-1080-1mb-1920x1080-bf235e1791e1.jpg"
                },

                new Imagen
                {
                    ImagenId = 19,
                    JuegoId = 7,
                    ImagenUrl = "https://cdn2.unrealengine.com/ttwl-gameplay-reveal-screenshots-mushroom-forest-1080-1mb-1920x1080-9f8ebad39534.jpg"
                },

                new Imagen
                {
                    ImagenId = 20,
                    JuegoId = 7,
                    ImagenUrl = "https://cdn2.unrealengine.com/crypt-01-3840x2160-4fd5e57cdc50.jpg"
                },

                new Imagen
                {
                    ImagenId = 21,
                    JuegoId = 8,
                    ImagenUrl = "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_TetrisEffectConnected_MonstarsincandResonair_S3_2560x1440-f2b7de145181b857418618f0ea6c4ad5?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 22,
                    JuegoId = 8,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-tetriseffectconnected-monstarsincresonairstagegames-g1a-01-12-13-21-1920x1080-87cd4694250f.jpg"
                },

                new Imagen
                {
                    ImagenId = 23,
                    JuegoId = 8,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-tetriseffectconnected-monstarsincresonairstagegames-g1a-02-12-13-21-1920x1080-346ccc7c35b6.jpg"
                },

                new Imagen
                {
                    ImagenId = 24,
                    JuegoId = 8,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-tetriseffectconnected-monstarsincresonairstagegames-g1a-03-12-13-21-1920x1080-726caf36858c.jpg"
                },

                new Imagen
                {
                    ImagenId = 25,
                    JuegoId = 9,
                    ImagenUrl = "https://cdn1.epicgames.com/offer/226306adde104c9092247dcd4bfa1499/EGS_CarMechanicSimulator2018_RedDotGames_S1_2560x1440-3489ef1499e64c168fdf4b14926d2c23?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 26,
                    JuegoId = 9,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-carmechanicsimulator2018-reddotgames-g1a-00-1920x1080-396668eaeb30.jpg"
                },

                new Imagen
                {
                    ImagenId = 27,
                    JuegoId = 9,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-carmechanicsimulator2018-reddotgames-g1a-02-1920x1080-c8d7441e80cd.jpg"
                },

                new Imagen
                {
                    ImagenId = 28,
                    JuegoId = 9,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-carmechanicsimulator2018-reddotgames-g1a-03-1920x1080-bfbe97557dc0.jpg"
                },

                new Imagen
                {
                    ImagenId = 29,
                    JuegoId = 10,
                    ImagenUrl = "https://cdn1.epicgames.com/offer/cbd5b3d310a54b12bf3fe8c41994174f/5a52c72d-80fc-4c3f-bc24-52b09ab9896a_2560x1440-12a1d9b80efd050055faa72feee71f8e?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 30,
                    JuegoId = 10,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-valorant-riotgames-g1a-02-1920x1080-580683fffe0f.jpg"
                },

                new Imagen
                {
                    ImagenId = 31,
                    JuegoId = 10,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-valorant-riotgames-g1a-03-1920x1080-f34bc7b4f1b5.jpg"
                },

                new Imagen
                {
                    ImagenId = 32,
                    JuegoId = 10,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-valorant-riotgames-g1a-05-1920x1080-42cf018303e5.jpg"
                },

                new Imagen
                {
                    ImagenId = 33,
                    JuegoId = 11,
                    ImagenUrl = "https://cdn1.epicgames.com/offer/0c6aee83b9b64372bf44a043001325f2/EGS_NARAKABLADEPOINT_24Entertainment_S1_2560x1440-62753d62ba83fc734916b63e3774cc4c?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 34,
                    JuegoId = 11,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-narakabladepoint-24entertainment-g1a-08-1920x1080-f1f3eade2832.jpg"
                },

                new Imagen
                {
                    ImagenId = 35,
                    JuegoId = 11,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-narakabladepoint-24entertainment-g1a-09-1920x1080-7d3aad3867aa.jpg"
                },

                new Imagen
                {
                    ImagenId = 36,
                    JuegoId = 11,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-narakabladepoint-24entertainment-g1a-10-1920x1080-e61c5693cd25.jpg"
                },

                new Imagen
                {
                    ImagenId = 37,
                    JuegoId = 12,
                    ImagenUrl = "https://cdn2.unrealengine.com/roll-02-3playersposing920x1080-1920x1080-8440693fc396.jpg"
                },

                new Imagen
                {
                    ImagenId = 38,
                    JuegoId = 12,
                    ImagenUrl = "https://cdn2.unrealengine.com/roll-03-superstaroption2-1920x1080-1920x1080-c6163a0beb18.jpg"
                },

                new Imagen
                {
                    ImagenId = 39,
                    JuegoId = 12,
                    ImagenUrl = "https://cdn2.unrealengine.com/roll-05-0-selectedairshot-1920x1080-1920x1080-43a1975d56ca.jpg"
                },

                new Imagen
                {
                    ImagenId = 40,
                    JuegoId = 13,
                    ImagenUrl = "https://cdn1.epicgames.com/b156c3365a5b4cb9a01a5e1108b4e3f4/offer/EGS_STARWARSBattlefrontIICelebrationEdition_DICE_S1-2560x1440-3dc68a07cace02e826ad42a2de5279b0.jpg?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 41,
                    JuegoId = 13,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-starwarsbattlefrontiicelebrationedition-dice-g1a-02-1920x1080-aeb9deb222c1.jpg"
                },

                new Imagen
                {
                    ImagenId = 42,
                    JuegoId = 13,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-starwarsbattlefrontiicelebrationedition-dice-g1a-03-1920x1080-9e43a5cc414f.jpg"
                },

                new Imagen
                {
                    ImagenId = 43,
                    JuegoId = 13,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-starwarsbattlefrontiicelebrationedition-dice-g1a-04-1920x1080-6ec1f5203cde.jpg"
                },

                new Imagen
                {
                    ImagenId = 44,
                    JuegoId = 14,
                    ImagenUrl = "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_WolfensteinTheNewOrder_MachineGames_S1_2560x1440-3a75b2c45a2a12e882feb2e2ff180b0c?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 45,
                    JuegoId = 14,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-wolfensteintheneworder-machinegames-g1a-07-1920x1080-75e96831363a.jpg"
                },

                new Imagen
                {
                    ImagenId = 46,
                    JuegoId = 14,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-wolfensteintheneworder-machinegames-g1a-08-1920x1080-ed79f030c810.jpg"
                },

                new Imagen
                {
                    ImagenId = 47,
                    JuegoId = 14,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-wolfensteintheneworder-machinegames-g1a-10-1920x1080-b73d1b85dc41.jpg"
                },

                new Imagen
                {
                    ImagenId = 48,
                    JuegoId = 15,
                    ImagenUrl = "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_HoodOutlawsLegends_SumoDigital_S1_2560x1440-8ba1f9be04e3d0c07f9890a0bb8860c7?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 49,
                    JuegoId = 15,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-hoodoutlawslgends-sumodigital-g1a-03-1920x1080-b28210417461.jpg"
                },

                new Imagen
                {
                    ImagenId = 50,
                    JuegoId = 15,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-hoodoutlawslgends-sumodigital-g1a-05-1920x1080-6b0b8e9f52f2.jpg"
                },

                new Imagen
                {
                    ImagenId = 51,
                    JuegoId = 15,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-hoodoutlawslgends-sumodigital-g1a-06-1920x1080-d9c895eaeff0.jpg"
                },

                new Imagen
                {
                    ImagenId = 52,
                    JuegoId = 16,
                    ImagenUrl = "https://cdn1.epicgames.com/salesEvent/salesEvent/Daffodil_1P_Awareness_INT_Epic_2560x1440_2560x1440-ba126bdeac3faab0596b7c56e9c09990?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 53,
                    JuegoId = 16,
                    ImagenUrl = "https://cdn2.unrealengine.com/ttwl-gameplay-reveal-screenshots-banshee-1080-1mb-1920x1080-bf235e1791e1.jpg"
                },

                new Imagen
                {
                    ImagenId = 54,
                    JuegoId = 16,
                    ImagenUrl = "https://cdn2.unrealengine.com/ttwl-gameplay-reveal-screenshots-mushroom-forest-1080-1mb-1920x1080-9f8ebad39534.jpg"
                },

                new Imagen
                {
                    ImagenId = 55,
                    JuegoId = 16,
                    ImagenUrl = "https://cdn2.unrealengine.com/crypt-01-3840x2160-4fd5e57cdc50.jpg"
                },

                new Imagen
                {
                    ImagenId = 56,
                    JuegoId = 17,
                    ImagenUrl = "https://cdn1.epicgames.com/offer/e9e3ee13329f434f94105e6ec63435e0/EGS_BioShockRemastered_MassMediaGames_S1_2560x1440-cb7067c24252c5602497ab42fc488eed?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 57,
                    JuegoId = 17,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-bioshockremastered-massmediagames-g1a-00-1920x1080-884ba4d9c648.jpg"
                },

                new Imagen
                {
                    ImagenId = 58,
                    JuegoId = 17,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-bioshockremastered-massmediagames-g1a-02-1920x1080-53419ae2abba.jpg"
                },

                new Imagen
                {
                    ImagenId = 59,
                    JuegoId = 17,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-bioshockremastered-massmediagames-g1a-04-1920x1080-ed1775dd7be6.jpg"
                },

                new Imagen
                {
                    ImagenId = 60,
                    JuegoId = 18,
                    ImagenUrl = "https://cdn1.epicgames.com/ark/offer/EGS_ARKSurvivalEvolved_StudioWildcard_S1-2560x1440-c316afb7c33a9dfb892eef6b99169e43.jpg?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 61,
                    JuegoId = 18,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-arksurvivalevolved-studiowildcard-g1a-07-1920x1080-136945680.jpg"
                },

                new Imagen
                {
                    ImagenId = 62,
                    JuegoId = 18,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-arksurvivalevolved-studiowildcard-g1a-10-1920x1080-136943551.jpg"
                },

                new Imagen
                {
                    ImagenId = 63,
                    JuegoId = 19,
                    ImagenUrl = "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_theHunterCalloftheWild_ExpansiveWorlds_S1_2560x1440-69120885e0b3acfb87f34ac0bad68ec6?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 64,
                    JuegoId = 19,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-thehuntercallofthewild-expansiveworlds-g1a-01-1920x1080-f03607ba5431.jpg"
                },

                new Imagen
                {
                    ImagenId = 65,
                    JuegoId = 19,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-thehuntercallofthewild-expansiveworlds-g1a-02-1920x1080-993584648afc.jpg"
                },

                new Imagen
                {
                    ImagenId = 66,
                    JuegoId = 19,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-thehuntercallofthewild-expansiveworlds-g1a-04-1920x1080-6a94e678d7cb.jpg"
                },

                new Imagen
                {
                    ImagenId = 67,
                    JuegoId = 20,
                    ImagenUrl = "https://cdn1.epicgames.com/offer/bd46d4ce259349e5bd8b3ded20274737/EGS_Chivalry2_TornBannerStudios_1_2560x1440-d9771ab1864d2db077d46f78f7731fcd?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 68,
                    JuegoId = 20,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-chivalry2-tornbannerstudios-g1a-07-1920x1080-189cecc3d888.jpg"
                },

                new Imagen
                {
                    ImagenId = 69,
                    JuegoId = 20,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-chivalry2-tornbannerstudios-g1a-08-1920x1080-043a3f4ff80d.jpg"
                },

                new Imagen
                {
                    ImagenId = 70,
                    JuegoId = 20,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-chivalry2-tornbannerstudios-g1a-09-1920x1080-53ec26c8daa3.jpg"
                },

                new Imagen
                {
                    ImagenId = 71,
                    JuegoId = 21,
                    ImagenUrl = "https://cdn1.epicgames.com/offer/c315a84ec4714288b34f7ac94ee2515d/EGS_HextechMayhemALeagueofLegendsStory_ChoiceProvisions_S1_2560x1440-dfef2c02d3b783eda069dc4c636993f5?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 72,
                    JuegoId = 21,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-hextechmayhemaleagueoflegendsstory-choiceprovisions-g1a-01-1920x1080-2ef9bf76c9ff.jpg"
                },

                new Imagen
                {
                    ImagenId = 73,
                    JuegoId = 21,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-hextechmayhemaleagueoflegendsstory-choiceprovisions-g1a-02-1920x1080-e0f106febf53.jpg"
                },

                new Imagen
                {
                    ImagenId = 74,
                    JuegoId = 21,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-hextechmayhemaleagueoflegendsstory-choiceprovisions-g1a-03-1920x1080-ae93d4a341b9.jpg"
                },

                new Imagen
                {
                    ImagenId = 75,
                    JuegoId = 22,
                    ImagenUrl = "https://cdn1.epicgames.com/offer/8ae7b3c0f490471b967ce26cc2f6e0e6/EGS_ItTakesTwo_Hazelight_S1_2560x1440-3ca0f21dd4d9ce4416e2d8e2a2178906_2560x1440-3ca0f21dd4d9ce4416e2d8e2a2178906?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 76,
                    JuegoId = 22,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-ittakestwo-hazelight-g1a-02-1920x1080-a767e6a24f42.jpg"
                },

                new Imagen
                {
                    ImagenId = 77,
                    JuegoId = 22,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-ittakestwo-hazelight-g1a-05-1920x1080-74e4df3b0d0b.jpg"
                },

                new Imagen
                {
                    ImagenId = 78,
                    JuegoId = 22,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-ittakestwo-hazelight-g1a-07-1920x1080-818d2460b157.jpg"
                },

                new Imagen
                {
                    ImagenId = 79,
                    JuegoId = 23,
                    ImagenUrl = "https://cdn1.epicgames.com/spt-assets/4a2dcb55ecca496aaaf328f60263bb56/kao-the-kangaroo-offer-5k0vx.jpg?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 80,
                    JuegoId = 23,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-ittakestwo-hazelight-g1a-02-1920x1080-a767e6a24f42.jpg"
                },

                new Imagen
                {
                    ImagenId = 81,
                    JuegoId = 23,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-ittakestwo-hazelight-g1a-05-1920x1080-74e4df3b0d0b.jpg"
                },

                new Imagen
                {
                    ImagenId = 82,
                    JuegoId = 23,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-ittakestwo-hazelight-g1a-07-1920x1080-818d2460b157.jpg"
                },

                new Imagen
                {
                    ImagenId = 83,
                    JuegoId = 24,
                    ImagenUrl = "https://cdn1.epicgames.com/offer/75c06d52a99942e9884a47deced106bb/EGS_ELEXII_PiranhaBytes_S1_2560x1440-92c8f0e41a7628ab9eb29911f2584292?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 84,
                    JuegoId = 24,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-elexii-piranhabytes-g1a-01-1920x1080-93a49092e0e2.jpg"
                },

                new Imagen
                {
                    ImagenId = 85,
                    JuegoId = 24,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-elexii-piranhabytes-g1a-02-1920x1080-e4e994e861be.jpg"
                },

                new Imagen
                {
                    ImagenId = 86,
                    JuegoId = 24,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-elexii-piranhabytes-g1a-03-1920x1080-409cd07f0509.jpg"
                },

                new Imagen
                {
                    ImagenId = 87,
                    JuegoId = 25,
                    ImagenUrl = "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_THEKINGOFFIGHTERSXV_SNKCORPORATION_S1_2560x1440-5d55ab8f79aeef9e9886bac3bbbf2204?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 88,
                    JuegoId = 25,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-thekingoffightersxvstandardedition-snkcorporation-bundles-g1a-01-1920x1080-a11849f0a7a3.jpg"
                },

                new Imagen
                {
                    ImagenId = 89,
                    JuegoId = 25,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-thekingoffightersxvstandardedition-snkcorporation-bundles-g1a-02-1920x1080-00085c73794c.jpg"
                },

                new Imagen
                {
                    ImagenId = 90,
                    JuegoId = 25,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-thekingoffightersxvstandardedition-snkcorporation-bundles-g1a-05-1920x1080-aa58f4840b78.jpg"
                },

                new Imagen
                {
                    ImagenId = 91,
                    JuegoId = 26,
                    ImagenUrl = "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_TombRaiderGAMEOFTHEYEAREDITION_CrystalDynamics_S1_2560x1440-0c41fcc8db62992e8d098d304b2277f8?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 92,
                    JuegoId = 26,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-tombraidergameoftheyearedition-crystaldynamics-g1a-01-1920x1080-e805b0875b06.jpg"
                },

                new Imagen
                {
                    ImagenId = 93,
                    JuegoId = 26,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-tombraidergameoftheyearedition-crystaldynamics-g1a-04-1920x1080-f2ad3f9c089c.jpg"
                },

                new Imagen
                {
                    ImagenId = 94,
                    JuegoId = 26,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-tombraidergameoftheyearedition-crystaldynamics-g1a-06-1920x1080-233dd5955a75.jpg"
                },

                new Imagen
                {
                    ImagenId = 95,
                    JuegoId = 27,
                    ImagenUrl = "https://cdn1.epicgames.com/offer/4b5461ca8d1c488787b5200b420de066/egs-shadowofthetombraiderdefinitiveedition-eidosmontralcrystaldynamicsnixxessoftware-s1-2560x1440-eca6506e95a1_2560x1440-193582a5fd76a593804e0171d6395cf4?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 96,
                    JuegoId = 27,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-shadowofthetombraiderdefinitiveedition-eidosmontralcrystaldynamicsnixxessoftware-g1a-01-1920x1080-508274bcd3fd.jpg"
                },

                new Imagen
                {
                    ImagenId = 97,
                    JuegoId = 27,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-shadowofthetombraiderdefinitiveedition-eidosmontralcrystaldynamicsnixxessoftware-g1a-02-1920x1080-54a6af8c99d1.jpg"
                },

                new Imagen
                {
                    ImagenId = 98,
                    JuegoId = 27,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-shadowofthetombraiderdefinitiveedition-eidosmontralcrystaldynamicsnixxessoftware-g1a-06-1920x1080-daee577d64c3.jpg"
                },

                new Imagen
                {
                    ImagenId = 99,
                    JuegoId = 28,
                    ImagenUrl = "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_RiseoftheTombRaider20YearCelebration_CrystalDynamics_S1_2560x1440-3bd5b3c4c11d46cc2dcb06bdf2f77627?h=270&resize=1&w=480"
                },

                new Imagen
                {
                    ImagenId = 100,
                    JuegoId = 28,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-riseofthetombraider20yearcelebration-crystaldynamics-g1a-02-1920x1080-f53afd374f40.jpg"
                },

                new Imagen
                {
                    ImagenId = 101,
                    JuegoId = 28,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-riseofthetombraider20yearcelebration-crystaldynamics-g1a-03-1920x1080-8139a7be5c54.jpg"
                },

                new Imagen
                {
                    ImagenId = 102,
                    JuegoId = 28,
                    ImagenUrl = "https://cdn2.unrealengine.com/egs-riseofthetombraider20yearcelebration-crystaldynamics-g1a-06-1920x1080-32ef2bd7bef9.jpg"
                },

                new Imagen
                {
                    ImagenId = 103,
                    JuegoId = 29,
                    ImagenUrl = "https://media.vandal.net/m/3-2022/202232312534795_1.jpg"
                },

                new Imagen
                {
                    ImagenId = 104,
                    JuegoId = 29,
                    ImagenUrl = "https://guiasyjuegos.com/wp-content/uploads/Kirby-y-la-tierra-olvidada-objetivo-secreto-de-Every-Winter.png"
                },

                new Imagen
                {
                    ImagenId = 105,
                    JuegoId = 29,
                    ImagenUrl = "https://img1.ak.crunchyroll.com/i/spire2/17460e3d58c86bcf88eb33a741a912b81632471800_main.jpg"
                },

                new Imagen
                {
                    ImagenId = 106,
                    JuegoId = 29,
                    ImagenUrl = "https://e00-marca.uecdn.es/assets/multimedia/imagenes/2022/01/12/16419978817192.jpg"
                },

                new Imagen
                {
                    ImagenId = 107,
                    JuegoId = 30,
                    ImagenUrl = "https://cdn.alfabetajuega.com/alfabetajuega/2022/06/pokemon-escarlata-purpura-koraidon-miraidon.jpg"
                },

                new Imagen
                {
                    ImagenId = 108,
                    JuegoId = 30,
                    ImagenUrl = "https://media.redadn.es/imagenes/pokemon-escarlata-y-pokemon-purpura-nintendo-switch_344447.jpg"
                },

                new Imagen
                {
                    ImagenId = 109,
                    JuegoId = 30,
                    ImagenUrl = "https://media.vandal.net/i/1200x630/6-2022/202262956397_1.jpg"
                },

                new Imagen
                {
                    ImagenId = 110,
                    JuegoId = 30,
                    ImagenUrl = "https://as01.epimg.net/meristation/imagenes/2022/06/01/noticias/1654093877_803563_1654094739_noticia_normal.jpg"
                },

                new Imagen
                {
                    ImagenId = 111,
                    JuegoId = 31,
                    ImagenUrl = "https://image.api.playstation.com/vulcan/ap/rnd/202206/0919/hq6KtnlrPbnUj7iNNI0V6gwe.png"
                },

                new Imagen
                {
                    ImagenId = 112,
                    JuegoId = 31,
                    ImagenUrl = "https://www.pcmrace.com/wp-content/uploads/2021/03/ss_f6dcf0cdc756ae083c39b237a996ac070a06ce5c.1920x1080.jpg"
                },

                new Imagen
                {
                    ImagenId = 113,
                    JuegoId = 31,
                    ImagenUrl = "https://www.pcmrace.com/wp-content/uploads/2022/02/ss_cdf307b445e56cc26834c3c101b197722e87eb82.1920x1080.jpg"
                },

                new Imagen
                {
                    ImagenId = 114,
                    JuegoId = 31,
                    ImagenUrl = "https://www.fun-academy.fr/wp-content/uploads/2022/06/1655720936_Shredders-Revenge-Dev-pourrait-creer-un-contenu-telechargeable-en-fonction..jpg"
                },

         new Imagen
         {
             ImagenId = 115,
             JuegoId = 1,
             ImagenUrl = "https://cdn.givemesport.com/wp-content/uploads/2022/05/sonic-the-hedgehog.jpg"
         },

                new Imagen
                {
                    ImagenId = 116,
                    JuegoId = 1,
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTewjNfHf1khy__CDnR8vUbIxeb6Q9FWqbWSAhWWK62DbHTSXZWVXoFUkeb5klKmflg7jQ&usqp=CAU"
                },

                new Imagen
                {
                    ImagenId = 117,
                    JuegoId = 1,
                    ImagenUrl = "https://deluxe.news/wp-content/uploads/2022/04/1650468696_Sonic-Origins-Collection-to-release-in-June-with-confusing-DLC.jpg"
                },


                new Imagen
                {
                    ImagenId = 118,
                    JuegoId = 2,
                    ImagenUrl = "https://t2.tudocdn.net/543353?w=1920&h=1080"
                },

                new Imagen
                {
                    ImagenId = 119,
                    JuegoId = 2,
                    ImagenUrl = "https://images-na.ssl-images-amazon.com/images/S/pv-target-images/4d74e8eabfe62b330b0fdc168f7b84980a72391769f19b846a095915a96a5cb0._RI_.jpg"
                },

                new Imagen
                {
                    ImagenId = 120,
                    JuegoId = 2,
                    ImagenUrl = "https://i.ytimg.com/vi/Tf-aqCnu4Jw/maxresdefault.jpg"
                },
                new Imagen
                {
                    ImagenId = 121,
                    JuegoId = 12,
                    ImagenUrl = "https://cdn1.epicgames.com/offer/03208f1f61764f5a8f6b7ea24c56edf1/XXXX_Store_Landscape_2560x1440_2560x1440-5f9186dedfc0626bcd7f347d5909723a?h=270&resize=1&w=480"
                }
            );
        }
    }
}
