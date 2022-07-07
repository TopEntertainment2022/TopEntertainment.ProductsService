using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopEntertainment.Juegos.AccessData.Migrations
{
    public partial class Juegos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Clasificacion",
                columns: table => new
                {
                    ClasificacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreClasificacion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificacion", x => x.ClasificacionId);
                });

            migrationBuilder.CreateTable(
                name: "Plataforma",
                columns: table => new
                {
                    PlataformaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePlataforma = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plataforma", x => x.PlataformaId);
                });

            migrationBuilder.CreateTable(
                name: "Juego",
                columns: table => new
                {
                    JuegoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlataformaId = table.Column<int>(type: "int", nullable: false),
                    ClasificacionId = table.Column<int>(type: "int", nullable: false),
                    NombreProducto = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    EnOferta = table.Column<bool>(type: "bit", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    Video = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juego", x => x.JuegoId);
                    table.ForeignKey(
                        name: "FK_Juego_Clasificacion_ClasificacionId",
                        column: x => x.ClasificacionId,
                        principalTable: "Clasificacion",
                        principalColumn: "ClasificacionId");
                    table.ForeignKey(
                        name: "FK_Juego_Plataforma_PlataformaId",
                        column: x => x.PlataformaId,
                        principalTable: "Plataforma",
                        principalColumn: "PlataformaId");
                });

            migrationBuilder.CreateTable(
                name: "Imagenes",
                columns: table => new
                {
                    ImagenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JuegoId = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagenes", x => x.ImagenId);
                    table.ForeignKey(
                        name: "FK_Imagenes_Juego_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juego",
                        principalColumn: "JuegoId");
                });

            migrationBuilder.CreateTable(
                name: "Producto_Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JuegoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId");
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_Juego_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juego",
                        principalColumn: "JuegoId");
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "NombreCategoria" },
                values: new object[,]
                {
                    { 1, "https://e7.pngegg.com/pngimages/136/884/png-clipart-clear-vision-3-sniper-shooter-clear-vision-2-sniper-fury-sniper-3d-gun-shooter-free-bullet-shooting-games-sniper-lens-android-sniper-fury.png", "Accion" },
                    { 2, "https://cdn.hobbyconsolas.com/sites/navi.axelspringer.es/public/styles/hc_1440x810/public/media/image/2017/12/mejores-juegos-accion-aventura-2018.jpg?itok=8GmFr_E5", "Aventura" },
                    { 3, "https://thumbs.dreamstime.com/b/icono-de-reglas-juego-elemento-simple-la-colecci%C3%B3n-desarrollo-juegos-rellenas-para-plantillas-infograf%C3%ADas-y-m%C3%A1s-signo-creativo-193118532.jpg", "Estrategia" },
                    { 4, "https://alfabetajuega.com/hero/2021/04/battlefield-bad-company-2.jpg?width=1200&aspect_ratio=1200:631", "Disparos" },
                    { 5, "https://img.captain-droid.com/wp-content/uploads/2017/11/eyes-icon.png", "Terror" },
                    { 6, "https://is2-ssl.mzstatic.com/image/thumb/Purple62/v4/ba/ab/f5/baabf5f7-0bc7-5ae1-9de3-85a71b389617/mzl.yixomytg.png/230x0w.png", "Casual" },
                    { 7, "https://img.freepik.com/vector-gratis/pad-juego-moderno-alambre-videojuegos-joystick-3d-azul-videoconsola-fondo-simbolos-geometricos-dinamicos-concepto-juegos-computadora-diseno-su-plantilla-ilustracion-vectorial_185386-790.jpg?w=360", "Plataforma" },
                    { 8, "https://www.androidsis.com/wp-content/uploads/2018/02/Juegos-de-supervivencia.png", "Supervivencia" },
                    { 9, "https://w7.pngwing.com/pngs/118/906/png-transparent-video-game-platform-game-5-miscellaneous-game-video-game-thumbnail.png", "Mundo Abierto" },
                    { 10, "https://as01.epimg.net/meristation/imagenes/2018/09/15/reportajes/1537047527_669497_1537047584_sumario_normal.jpg", "Primera Persona" },
                    { 11, "https://c8.alamy.com/compes/2cb364b/icono-juego-de-simulacion-elemento-simple-de-la-coleccion-de-desarrollo-de-juegos-icono-de-juego-de-simulacion-relleno-para-plantillas-infografias-y-mucho-mas-2cb364b.jpg", "Simulacion" },
                    { 12, "https://static.vecteezy.com/system/resources/previews/004/976/735/non_2x/gaming-accessory-glyph-icon-pc-steering-wheel-esports-device-gadget-for-driving-simulation-game-racing-silhouette-symbol-negative-space-isolated-illustration-vector.jpg", "Carrera" }
                });

            migrationBuilder.InsertData(
                table: "Clasificacion",
                columns: new[] { "ClasificacionId", "Descripcion", "NombreClasificacion" },
                values: new object[,]
                {
                    { 1, "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b8/ESRB_2013_Everyone_Spanish.svg/800px-ESRB_2013_Everyone_Spanish.svg.png", "E for Everyone." },
                    { 2, "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/ESRB_2013_Teen_Spanish.svg/800px-ESRB_2013_Teen_Spanish.svg.png", "PG 16" },
                    { 3, "https://upload.wikimedia.org/wikipedia/commons/thumb/6/60/ESRB_2013_Adults_Only_Spanish.svg/800px-ESRB_2013_Adults_Only_Spanish.svg.png", "PG 18" }
                });

            migrationBuilder.InsertData(
                table: "Plataforma",
                columns: new[] { "PlataformaId", "Descripcion", "NombrePlataforma" },
                values: new object[,]
                {
                    { 1, "Consola de Sony de última generación.", "PlayStation 5" },
                    { 2, "Consola de Sony de última generación.", "PlayStation 4" },
                    { 3, "Consola Económica de Microsoft de última generación.", "Xbox Series S" },
                    { 4, "Consola Económica de Microsoft de última generación.", "Xbox One" },
                    { 5, "Computadora de Escritorio o Notebook Gamer", "PC" },
                    { 6, "Consola Portatil Nintendo Switch de última generación.", "Nintendo Switch" }
                });

            migrationBuilder.InsertData(
                table: "Juego",
                columns: new[] { "JuegoId", "ClasificacionId", "Descripcion", "EnOferta", "NombreProducto", "PlataformaId", "Precio", "SoftDelete", "Stock", "Video" },
                values: new object[,]
                {
                    { 1, 1, "Juegos clásicos de Sonic remasterizados.", false, "Sonic Origins", 4, 40m, false, 10, "https://www.youtube.com/embed/ZzHXjAJ86Zw" },
                    { 2, 1, "Juego de Crash más reciente.", false, "Crash Bandicoot 4: It’s About Time", 2, 10m, false, 20, "https://www.youtube.com/embed/aOGwx3Ju6QQ" },
                    { 3, 3, "Kratos ha dejado atras su venganza contra los dioses del Olimpo y vive ahora como un hombre en los dominios de los dioses y monstruos nordicos.", false, "God of War", 1, 40m, false, 10, "https://www.youtube.com/embed/d8HmwZSskvY" },
                    { 4, 1, "Redout es un tributo a los clásicos juegos de carreras.", false, "Redout: Enhanced Edition", 4, 4m, false, 10, "https://www.youtube.com/embed/kcuFK7Xadyc" },
                    { 5, 1, "Fall Guys es un party royale gratis y multiplataforma donde los jugadores compiten en delirantes carreras de obstáculos formadas por rondas cada vez más emocionantes hasta que una sola persona se alza con la victoria.", false, "Fall Guys", 5, 10m, false, 10, "https://www.youtube.com/embed/KNDf4J4wmxs" },
                    { 6, 1, "Crea un equipo con hasta 3 amigos en Tom Clancy's Ghost Recon® Wildlands y disfruta del shooter militar definitivo en un enorme y peligroso mundo abierto.", false, "LEGO® Star Wars™: La Saga Skywalker", 4, 50m, false, 10, "https://www.youtube.com/watch?v=kuYiHhx1_mw" },
                    { 7, 2, "Guía a Skul en su mision para enfrentarse el solo al Ejercito Imperial y rescatar a su rey en un roguelite en 2D de plataformas cargado de accion que pasara a la historia.", false, "Skul: The Hero Slayer", 6, 4m, false, 10, "https://www.youtube.com/embed/7uU1mOhOTH8" },
                    { 8, 1, "Tetris® Effect: Connected amplía con una nueva y potente expansión multijugador la inmensa variedad de adictivos e innovadores modos de juego por los que se conoce a Tetris Effect.", false, "Tetris® Effect: Connected", 6, 8m, false, 10, "https://www.youtube.com/embed/CCBpwyS0E1o" },
                    { 9, 1, "Construye y amplía tu imperio de servicios de reparación en este juego de simulación increíblemente detallado y realista, donde la atención a los detalles de los coches es asombrosa.", false, "Car Mechanic Simulator 2018", 5, 4m, false, 10, "https://www.youtube.com/embed/LCTF8wKWFSU" },
                    { 10, 2, "VALORANT es un shooter táctico 5v5 basado en personajes que está ambientado en un escenario internacional.", false, "VALORANT", 5, 0m, false, 20, "https://www.youtube.com/embed/KbFWhffLM-A" },
                    { 11, 2, "NARAKA: BLADEPOINT es un título de lucha y acción mítica JcJ en el que hasta 60 jugadores se enfrentan en combates cuerpo a cuerpo de artes marciales.", false, "NARAKA: BLADEPOINT", 5, 20m, false, 20, "https://www.youtube.com/embed/Q_uBBXiqL1s" },
                    { 12, 1, "Patina y rueda hasta la victoria en Roller Champions. Descubre un juego deportivo JcJ por equipos y gratuito unico en su especie!", false, "Roller Champions", 3, 0m, false, 20, "https://www.youtube.com/embed/vdKJQBf2lL0" },
                    { 13, 1, "Pon a prueba tu dominio del bláster, la espada láser y la Fuerza online y offline en STAR WARS Battlefront II: Celebration Edition.", false, "STAR WARS Battlefront II", 4, 40m, false, 20, "https://www.youtube.com/embed/qbVsjbBllKQ" },
                    { 14, 3, "Wolfenstein®: The New Order revitaliza la serie que creó el género de los shooters en primera persona.", false, "Wolfenstein: The New Order", 1, 13m, false, 20, "https://www.youtube.com/embed/nidCcGtPLOQ" },
                    { 15, 3, "Supera a las bandas rivales en un mundo medieval y violento de intensos asaltos multijugador JcJcE.", false, "Hood: Outlaws & Legends", 1, 12m, false, 20, "https://www.youtube.com/embed/o26rvJIBLno" },
                    { 16, 2, "¡Embárcate en una increíble aventura llena de extravagancias, asombro y armamento de alta potencia! Crea a tu propio héroe multiclase y saquea, dispara, corta y lanza hechizos para detener al Señor de los Dragones.", false, "Tiny Tina's Wonderlands", 3, 60m, false, 20, "https://www.youtube.com/embed/AwFCFG9aBr8" },
                    { 17, 3, "Explora la ciudad submarina de Rapture, un refugio para las mentes más brillantes de la sociedad que se ha transformado en una pesadilla distópica por culpa del orgullo desmedido de un hombre.", false, "BioShock Remastered", 5, 15m, false, 20, "https://www.youtube.com/embed/BeP35Jw2_ho" },
                    { 18, 1, "Despiertas en la orilla de una isla misteriosa en la que debes aprender a sobrevivir. Usa tu inteligencia para matar o domar a las criaturas primitivas que vagan por el lugar.", false, "ARK: Survival Evolved", 4, 6m, false, 20, "https://www.youtube.com/embed/FW9vsrPWujI" },
                    { 19, 2, "Disfruta de un juego de caza con una ambientación sin igual en un mundo abierto realista y visualmente asombroso. Sumérgete en la atmósfera de la campaña individual, o comparte la experiencia de caza definitiva con tus amigos.", false, "theHunter: Call of the Wild™", 4, 4m, false, 20, "https://www.youtube.com/embed/VGOTYfGMyoE" },
                    { 20, 2, "Chivalry 2 es un juego multijugador de batallas en primera persona inspiradas en las películas de estilo medieval.", false, "Chivalry 2", 3, 8m, false, 20, "https://www.youtube.com/embed/HKlYVpCuab0" },
                    { 21, 1, "En este trepidante juego de avance rítmico, toda acción tiene una reacción explosiva ¡y todo caos es poco! Poneos en el pelaje de Ziggs, un experto en hexplosivos, conforme desatáis el caos a través de los barrios de Piltover.", false, "Hextech Mayhem", 6, 7m, false, 20, "https://www.youtube.com/embed/q6eWS8OEJiE" },
                    { 22, 1, "Embárcate en la aventura de tu vida en It Takes Two. Invita a un amigo a acompañarte gratis con el Pase de amigo* para colaborar en una gran variedad de desafíos deliciosamente rompedores.", false, "It Takes Two", 3, 40m, false, 20, "https://www.youtube.com/embed/ohClxMmNLQQ" },
                    { 23, 1, "Vive una aventura épica, domina los guantes y explora escenarios increíbles.", false, "Kao the Kangaroo", 4, 30m, false, 20, "https://www.youtube.com/embed/fww1BuVIxzo" },
                    { 24, 2, "En esta secuela del RPG vintage de mundo abierto ELEX, Jax debe volver a unir a los pueblos libres del mundo de ciencia ficción y fantasía de Magalan contra una nueva amenaza, los Celestiales, que pretenden cambiar para siempre la faz del planeta.", false, "ELEX II", 5, 18m, false, 20, "https://www.youtube.com/embed/u49qSkdq2r8" },
                    { 25, 2, "¡REVIENTA TODAS LAS EXPECTATIVAS! ¡El nuevo XV que sobrepasa todo!", false, "THE KING OF FIGHTERS XV", 3, 29m, false, 20, "https://www.youtube.com/embed/9FukK1ItSZE" },
                    { 26, 3, "Armada solo con su instinto y una capacidad de aguante más allá de los límites de la resistencia humana, Lara debe luchar para huir de una isla remota y descubrir su oscura historia.", false, "Tomb Raider GOTY", 5, 20m, false, 20, "https://www.youtube.com/embed/OJc5yDgJ7lk" },
                    { 27, 3, "En Shadow of the Tomb Raider: Definitive Edition, vive el capítulo final de la historia sobre el origen de Lara, en el que se convierte en la saqueadora de tumbas que está destinada a ser.", false, "Shadow of the Tomb Raider: Definitive Edition", 2, 40m, false, 20, "https://www.youtube.com/embed/zmihOPh3enA" },
                    { 28, 3, "Rise of the Tomb Raider: Edición 20 aniversario incluye el juego de base y el pase de temporada con contenido totalmente nuevo.", false, "Rise of the Tomb Raider: Edición 20 aniversario", 5, 30m, false, 20, "https://www.youtube.com/embed/SfGqfEkfhjE" },
                    { 29, 1, "Kirby y la tierra olvidada, titulado en inglés como Kirby and the Forgotten Land, es un videojuego de plataformas en 3D de la saga Kirby, desarrollado por HAL Laboratory y publicado por Nintendo para la videoconsola Nintendo Switch.", false, "Kirby y la tierra olvidada", 6, 23m, false, 20, "https://www.youtube.com/embed/ZKNYy6IOUSE" },
                    { 30, 1, "Pokémon Escarlata y Pokémon Púrpura son un par de videojuegos de rol en desarrollo por Game Freak. Su lanzamiento está previsto para finales de 2022, ​ siendo publicados por The Pokémon Company para Nintendo Switch.", false, "Pokémon escarlata y Pokémon púrpura", 6, 17m, false, 20, "https://www.youtube.com/embed/yGoVJM5lpK0" },
                    { 31, 1, "Teenage Mutant Ninja Turtles: Shredder's Revenge es un juego de lucha desarrollado por Tribute Games y publicado por Dotemu.", false, "Teenage Mutant Ninja Turtles: Shredder's Revenge", 6, 27m, false, 20, "https://www.youtube.com/embed/c87XkB05xtg" }
                });

            migrationBuilder.InsertData(
                table: "Imagenes",
                columns: new[] { "ImagenId", "ImagenUrl", "JuegoId" },
                values: new object[,]
                {
                    { 1, "https://i.imgur.com/4Hk05rT.png", 1 },
                    { 2, "https://i.imgur.com/86iraFT.png", 2 },
                    { 3, "https://cdn2.unrealengine.com/egs-godofwar-santamonicastudio-g1a-02-1920x1080-f7c6fef5c876.jpg?h=720&resize=1&w=1280", 3 },
                    { 4, "https://cdn2.unrealengine.com/egs-godofwar-santamonicastudio-g1a-01-1920x1080-c84d2a96aea3.jpg", 3 },
                    { 5, "https://cdn2.unrealengine.com/egs-godofwar-santamonicastudio-g1a-03-1920x1080-65b80475ae32.jpg?h=720&resize=1&w=1280", 3 },
                    { 6, "https://cdn1.epicgames.com/offer/93ea0d593cb04e62afb0741bbf894173/EGS_RedoutEnhancedEdition_34BigThingssrl_S1_2560x1440-23ab955c6537efdd53e1f407609f9036?h=270&resize=1&w=480", 4 },
                    { 7, "https://cdn2.unrealengine.com/egs-redoutenhancededition-34bigthingssrl-g1a-01-1920x1080-6e1e9ea24bd5.jpg", 4 },
                    { 8, "https://cdn2.unrealengine.com/egs-redoutenhancededition-34bigthingssrl-g1a-02-1920x1080-8eb05ed7cc60.jpg", 4 },
                    { 9, "https://cdn2.unrealengine.com/egs-redoutenhancededition-34bigthingssrl-g1a-03-1920x1080-b48ac6857dfe.jpg", 4 },
                    { 10, "https://cdn2.unrealengine.com/es-es-fallguysss1-productofferabout-1920x1080-1920x1080-a204121647bc.jpg", 5 },
                    { 11, "https://cdn2.unrealengine.com/egs-fallguys-mediatonic-g1a-01-1920x1080-063acacc6f1a.jpg", 5 },
                    { 12, "https://cdn2.unrealengine.com/egs-fallguys-mediatonic-g1a-02-1920x1080-a5f24303b646.jpg", 5 },
                    { 13, "https://cdn1.epicgames.com/offer/9c59efaabb6a48f19b3485d5d9416032/EGS_LEGOStarWarsTheSkywalkerSaga_TTGames_S1_2560x1440-ae89e9c91aec1e461148f93f25b828ed?h=270&resize=1&w=480", 6 },
                    { 14, "https://cdn2.unrealengine.com/egs-legostarwarstheskywalkersaga-ttgames-g1a-00-1920x1080-487a6e965579.jpg", 6 },
                    { 15, "https://cdn2.unrealengine.com/egs-legostarwarstheskywalkersaga-ttgames-g1a-01-1920x1080-5da07b4a7838.jpg", 6 },
                    { 16, "https://cdn2.unrealengine.com/egs-legostarwarstheskywalkersaga-ttgames-g1a-02-1920x1080-38aa896e6f5f.jpg", 6 },
                    { 17, "https://cdn1.epicgames.com/salesEvent/salesEvent/Daffodil_1P_Awareness_INT_Epic_2560x1440_2560x1440-ba126bdeac3faab0596b7c56e9c09990?h=270&resize=1&w=480", 7 },
                    { 18, "https://cdn2.unrealengine.com/ttwl-gameplay-reveal-screenshots-banshee-1080-1mb-1920x1080-bf235e1791e1.jpg", 7 },
                    { 19, "https://cdn2.unrealengine.com/ttwl-gameplay-reveal-screenshots-mushroom-forest-1080-1mb-1920x1080-9f8ebad39534.jpg", 7 },
                    { 20, "https://cdn2.unrealengine.com/crypt-01-3840x2160-4fd5e57cdc50.jpg", 7 },
                    { 21, "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_TetrisEffectConnected_MonstarsincandResonair_S3_2560x1440-f2b7de145181b857418618f0ea6c4ad5?h=270&resize=1&w=480", 8 },
                    { 22, "https://cdn2.unrealengine.com/egs-tetriseffectconnected-monstarsincresonairstagegames-g1a-01-12-13-21-1920x1080-87cd4694250f.jpg", 8 },
                    { 23, "https://cdn2.unrealengine.com/egs-tetriseffectconnected-monstarsincresonairstagegames-g1a-02-12-13-21-1920x1080-346ccc7c35b6.jpg", 8 },
                    { 24, "https://cdn2.unrealengine.com/egs-tetriseffectconnected-monstarsincresonairstagegames-g1a-03-12-13-21-1920x1080-726caf36858c.jpg", 8 },
                    { 25, "https://cdn1.epicgames.com/offer/226306adde104c9092247dcd4bfa1499/EGS_CarMechanicSimulator2018_RedDotGames_S1_2560x1440-3489ef1499e64c168fdf4b14926d2c23?h=270&resize=1&w=480", 9 },
                    { 26, "https://cdn2.unrealengine.com/egs-carmechanicsimulator2018-reddotgames-g1a-00-1920x1080-396668eaeb30.jpg", 9 },
                    { 27, "https://cdn2.unrealengine.com/egs-carmechanicsimulator2018-reddotgames-g1a-02-1920x1080-c8d7441e80cd.jpg", 9 },
                    { 28, "https://cdn2.unrealengine.com/egs-carmechanicsimulator2018-reddotgames-g1a-03-1920x1080-bfbe97557dc0.jpg", 9 },
                    { 29, "https://cdn1.epicgames.com/offer/cbd5b3d310a54b12bf3fe8c41994174f/5a52c72d-80fc-4c3f-bc24-52b09ab9896a_2560x1440-12a1d9b80efd050055faa72feee71f8e?h=270&resize=1&w=480", 10 },
                    { 30, "https://cdn2.unrealengine.com/egs-valorant-riotgames-g1a-02-1920x1080-580683fffe0f.jpg", 10 },
                    { 31, "https://cdn2.unrealengine.com/egs-valorant-riotgames-g1a-03-1920x1080-f34bc7b4f1b5.jpg", 10 },
                    { 32, "https://cdn2.unrealengine.com/egs-valorant-riotgames-g1a-05-1920x1080-42cf018303e5.jpg", 10 },
                    { 33, "https://cdn1.epicgames.com/offer/0c6aee83b9b64372bf44a043001325f2/EGS_NARAKABLADEPOINT_24Entertainment_S1_2560x1440-62753d62ba83fc734916b63e3774cc4c?h=270&resize=1&w=480", 11 },
                    { 34, "https://cdn2.unrealengine.com/egs-narakabladepoint-24entertainment-g1a-08-1920x1080-f1f3eade2832.jpg", 11 },
                    { 35, "https://cdn2.unrealengine.com/egs-narakabladepoint-24entertainment-g1a-09-1920x1080-7d3aad3867aa.jpg", 11 },
                    { 36, "https://cdn2.unrealengine.com/egs-narakabladepoint-24entertainment-g1a-10-1920x1080-e61c5693cd25.jpg", 11 },
                    { 37, "https://cdn2.unrealengine.com/roll-02-3playersposing920x1080-1920x1080-8440693fc396.jpg", 12 },
                    { 38, "https://cdn2.unrealengine.com/roll-03-superstaroption2-1920x1080-1920x1080-c6163a0beb18.jpg", 12 },
                    { 39, "https://cdn2.unrealengine.com/roll-05-0-selectedairshot-1920x1080-1920x1080-43a1975d56ca.jpg", 12 },
                    { 40, "https://cdn1.epicgames.com/b156c3365a5b4cb9a01a5e1108b4e3f4/offer/EGS_STARWARSBattlefrontIICelebrationEdition_DICE_S1-2560x1440-3dc68a07cace02e826ad42a2de5279b0.jpg?h=270&resize=1&w=480", 13 },
                    { 41, "https://cdn2.unrealengine.com/egs-starwarsbattlefrontiicelebrationedition-dice-g1a-02-1920x1080-aeb9deb222c1.jpg", 13 },
                    { 42, "https://cdn2.unrealengine.com/egs-starwarsbattlefrontiicelebrationedition-dice-g1a-03-1920x1080-9e43a5cc414f.jpg", 13 }
                });

            migrationBuilder.InsertData(
                table: "Imagenes",
                columns: new[] { "ImagenId", "ImagenUrl", "JuegoId" },
                values: new object[,]
                {
                    { 43, "https://cdn2.unrealengine.com/egs-starwarsbattlefrontiicelebrationedition-dice-g1a-04-1920x1080-6ec1f5203cde.jpg", 13 },
                    { 44, "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_WolfensteinTheNewOrder_MachineGames_S1_2560x1440-3a75b2c45a2a12e882feb2e2ff180b0c?h=270&resize=1&w=480", 14 },
                    { 45, "https://cdn2.unrealengine.com/egs-wolfensteintheneworder-machinegames-g1a-07-1920x1080-75e96831363a.jpg", 14 },
                    { 46, "https://cdn2.unrealengine.com/egs-wolfensteintheneworder-machinegames-g1a-08-1920x1080-ed79f030c810.jpg", 14 },
                    { 47, "https://cdn2.unrealengine.com/egs-wolfensteintheneworder-machinegames-g1a-10-1920x1080-b73d1b85dc41.jpg", 14 },
                    { 48, "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_HoodOutlawsLegends_SumoDigital_S1_2560x1440-8ba1f9be04e3d0c07f9890a0bb8860c7?h=270&resize=1&w=480", 15 },
                    { 49, "https://cdn2.unrealengine.com/egs-hoodoutlawslgends-sumodigital-g1a-03-1920x1080-b28210417461.jpg", 15 },
                    { 50, "https://cdn2.unrealengine.com/egs-hoodoutlawslgends-sumodigital-g1a-05-1920x1080-6b0b8e9f52f2.jpg", 15 },
                    { 51, "https://cdn2.unrealengine.com/egs-hoodoutlawslgends-sumodigital-g1a-06-1920x1080-d9c895eaeff0.jpg", 15 },
                    { 52, "https://cdn1.epicgames.com/salesEvent/salesEvent/Daffodil_1P_Awareness_INT_Epic_2560x1440_2560x1440-ba126bdeac3faab0596b7c56e9c09990?h=270&resize=1&w=480", 16 },
                    { 53, "https://cdn2.unrealengine.com/ttwl-gameplay-reveal-screenshots-banshee-1080-1mb-1920x1080-bf235e1791e1.jpg", 16 },
                    { 54, "https://cdn2.unrealengine.com/ttwl-gameplay-reveal-screenshots-mushroom-forest-1080-1mb-1920x1080-9f8ebad39534.jpg", 16 },
                    { 55, "https://cdn2.unrealengine.com/crypt-01-3840x2160-4fd5e57cdc50.jpg", 16 },
                    { 56, "https://cdn1.epicgames.com/offer/e9e3ee13329f434f94105e6ec63435e0/EGS_BioShockRemastered_MassMediaGames_S1_2560x1440-cb7067c24252c5602497ab42fc488eed?h=270&resize=1&w=480", 17 },
                    { 57, "https://cdn2.unrealengine.com/egs-bioshockremastered-massmediagames-g1a-00-1920x1080-884ba4d9c648.jpg", 17 },
                    { 58, "https://cdn2.unrealengine.com/egs-bioshockremastered-massmediagames-g1a-02-1920x1080-53419ae2abba.jpg", 17 },
                    { 59, "https://cdn2.unrealengine.com/egs-bioshockremastered-massmediagames-g1a-04-1920x1080-ed1775dd7be6.jpg", 17 },
                    { 60, "https://cdn1.epicgames.com/ark/offer/EGS_ARKSurvivalEvolved_StudioWildcard_S1-2560x1440-c316afb7c33a9dfb892eef6b99169e43.jpg?h=270&resize=1&w=480", 18 },
                    { 61, "https://cdn2.unrealengine.com/egs-arksurvivalevolved-studiowildcard-g1a-07-1920x1080-136945680.jpg", 18 },
                    { 62, "https://cdn2.unrealengine.com/egs-arksurvivalevolved-studiowildcard-g1a-10-1920x1080-136943551.jpg", 18 },
                    { 63, "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_theHunterCalloftheWild_ExpansiveWorlds_S1_2560x1440-69120885e0b3acfb87f34ac0bad68ec6?h=270&resize=1&w=480", 19 },
                    { 64, "https://cdn2.unrealengine.com/egs-thehuntercallofthewild-expansiveworlds-g1a-01-1920x1080-f03607ba5431.jpg", 19 },
                    { 65, "https://cdn2.unrealengine.com/egs-thehuntercallofthewild-expansiveworlds-g1a-02-1920x1080-993584648afc.jpg", 19 },
                    { 66, "https://cdn2.unrealengine.com/egs-thehuntercallofthewild-expansiveworlds-g1a-04-1920x1080-6a94e678d7cb.jpg", 19 },
                    { 67, "https://cdn1.epicgames.com/offer/bd46d4ce259349e5bd8b3ded20274737/EGS_Chivalry2_TornBannerStudios_1_2560x1440-d9771ab1864d2db077d46f78f7731fcd?h=270&resize=1&w=480", 20 },
                    { 68, "https://cdn2.unrealengine.com/egs-chivalry2-tornbannerstudios-g1a-07-1920x1080-189cecc3d888.jpg", 20 },
                    { 69, "https://cdn2.unrealengine.com/egs-chivalry2-tornbannerstudios-g1a-08-1920x1080-043a3f4ff80d.jpg", 20 },
                    { 70, "https://cdn2.unrealengine.com/egs-chivalry2-tornbannerstudios-g1a-09-1920x1080-53ec26c8daa3.jpg", 20 },
                    { 71, "https://cdn1.epicgames.com/offer/c315a84ec4714288b34f7ac94ee2515d/EGS_HextechMayhemALeagueofLegendsStory_ChoiceProvisions_S1_2560x1440-dfef2c02d3b783eda069dc4c636993f5?h=270&resize=1&w=480", 21 },
                    { 72, "https://cdn2.unrealengine.com/egs-hextechmayhemaleagueoflegendsstory-choiceprovisions-g1a-01-1920x1080-2ef9bf76c9ff.jpg", 21 },
                    { 73, "https://cdn2.unrealengine.com/egs-hextechmayhemaleagueoflegendsstory-choiceprovisions-g1a-02-1920x1080-e0f106febf53.jpg", 21 },
                    { 74, "https://cdn2.unrealengine.com/egs-hextechmayhemaleagueoflegendsstory-choiceprovisions-g1a-03-1920x1080-ae93d4a341b9.jpg", 21 },
                    { 75, "https://cdn1.epicgames.com/offer/8ae7b3c0f490471b967ce26cc2f6e0e6/EGS_ItTakesTwo_Hazelight_S1_2560x1440-3ca0f21dd4d9ce4416e2d8e2a2178906_2560x1440-3ca0f21dd4d9ce4416e2d8e2a2178906?h=270&resize=1&w=480", 22 },
                    { 76, "https://cdn2.unrealengine.com/egs-ittakestwo-hazelight-g1a-02-1920x1080-a767e6a24f42.jpg", 22 },
                    { 77, "https://cdn2.unrealengine.com/egs-ittakestwo-hazelight-g1a-05-1920x1080-74e4df3b0d0b.jpg", 22 },
                    { 78, "https://cdn2.unrealengine.com/egs-ittakestwo-hazelight-g1a-07-1920x1080-818d2460b157.jpg", 22 },
                    { 79, "https://cdn1.epicgames.com/spt-assets/4a2dcb55ecca496aaaf328f60263bb56/kao-the-kangaroo-offer-5k0vx.jpg?h=270&resize=1&w=480", 23 },
                    { 80, "https://cdn2.unrealengine.com/egs-ittakestwo-hazelight-g1a-02-1920x1080-a767e6a24f42.jpg", 23 },
                    { 81, "https://cdn2.unrealengine.com/egs-ittakestwo-hazelight-g1a-05-1920x1080-74e4df3b0d0b.jpg", 23 },
                    { 82, "https://cdn2.unrealengine.com/egs-ittakestwo-hazelight-g1a-07-1920x1080-818d2460b157.jpg", 23 },
                    { 83, "https://cdn1.epicgames.com/offer/75c06d52a99942e9884a47deced106bb/EGS_ELEXII_PiranhaBytes_S1_2560x1440-92c8f0e41a7628ab9eb29911f2584292?h=270&resize=1&w=480", 24 },
                    { 84, "https://cdn2.unrealengine.com/egs-elexii-piranhabytes-g1a-01-1920x1080-93a49092e0e2.jpg", 24 }
                });

            migrationBuilder.InsertData(
                table: "Imagenes",
                columns: new[] { "ImagenId", "ImagenUrl", "JuegoId" },
                values: new object[,]
                {
                    { 85, "https://cdn2.unrealengine.com/egs-elexii-piranhabytes-g1a-02-1920x1080-e4e994e861be.jpg", 24 },
                    { 86, "https://cdn2.unrealengine.com/egs-elexii-piranhabytes-g1a-03-1920x1080-409cd07f0509.jpg", 24 },
                    { 87, "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_THEKINGOFFIGHTERSXV_SNKCORPORATION_S1_2560x1440-5d55ab8f79aeef9e9886bac3bbbf2204?h=270&resize=1&w=480", 25 },
                    { 88, "https://cdn2.unrealengine.com/egs-thekingoffightersxvstandardedition-snkcorporation-bundles-g1a-01-1920x1080-a11849f0a7a3.jpg", 25 },
                    { 89, "https://cdn2.unrealengine.com/egs-thekingoffightersxvstandardedition-snkcorporation-bundles-g1a-02-1920x1080-00085c73794c.jpg", 25 },
                    { 90, "https://cdn2.unrealengine.com/egs-thekingoffightersxvstandardedition-snkcorporation-bundles-g1a-05-1920x1080-aa58f4840b78.jpg", 25 },
                    { 91, "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_TombRaiderGAMEOFTHEYEAREDITION_CrystalDynamics_S1_2560x1440-0c41fcc8db62992e8d098d304b2277f8?h=270&resize=1&w=480", 26 },
                    { 92, "https://cdn2.unrealengine.com/egs-tombraidergameoftheyearedition-crystaldynamics-g1a-01-1920x1080-e805b0875b06.jpg", 26 },
                    { 93, "https://cdn2.unrealengine.com/egs-tombraidergameoftheyearedition-crystaldynamics-g1a-04-1920x1080-f2ad3f9c089c.jpg", 26 },
                    { 94, "https://cdn2.unrealengine.com/egs-tombraidergameoftheyearedition-crystaldynamics-g1a-06-1920x1080-233dd5955a75.jpg", 26 },
                    { 95, "https://cdn1.epicgames.com/offer/4b5461ca8d1c488787b5200b420de066/egs-shadowofthetombraiderdefinitiveedition-eidosmontralcrystaldynamicsnixxessoftware-s1-2560x1440-eca6506e95a1_2560x1440-193582a5fd76a593804e0171d6395cf4?h=270&resize=1&w=480", 27 },
                    { 96, "https://cdn2.unrealengine.com/egs-shadowofthetombraiderdefinitiveedition-eidosmontralcrystaldynamicsnixxessoftware-g1a-01-1920x1080-508274bcd3fd.jpg", 27 },
                    { 97, "https://cdn2.unrealengine.com/egs-shadowofthetombraiderdefinitiveedition-eidosmontralcrystaldynamicsnixxessoftware-g1a-02-1920x1080-54a6af8c99d1.jpg", 27 },
                    { 98, "https://cdn2.unrealengine.com/egs-shadowofthetombraiderdefinitiveedition-eidosmontralcrystaldynamicsnixxessoftware-g1a-06-1920x1080-daee577d64c3.jpg", 27 },
                    { 99, "https://cdn1.epicgames.com/salesEvent/salesEvent/EGS_RiseoftheTombRaider20YearCelebration_CrystalDynamics_S1_2560x1440-3bd5b3c4c11d46cc2dcb06bdf2f77627?h=270&resize=1&w=480", 28 },
                    { 100, "https://cdn2.unrealengine.com/egs-riseofthetombraider20yearcelebration-crystaldynamics-g1a-02-1920x1080-f53afd374f40.jpg", 28 },
                    { 101, "https://cdn2.unrealengine.com/egs-riseofthetombraider20yearcelebration-crystaldynamics-g1a-03-1920x1080-8139a7be5c54.jpg", 28 },
                    { 102, "https://cdn2.unrealengine.com/egs-riseofthetombraider20yearcelebration-crystaldynamics-g1a-06-1920x1080-32ef2bd7bef9.jpg", 28 },
                    { 103, "https://media.vandal.net/m/3-2022/202232312534795_1.jpg", 29 },
                    { 104, "https://guiasyjuegos.com/wp-content/uploads/Kirby-y-la-tierra-olvidada-objetivo-secreto-de-Every-Winter.png", 29 },
                    { 105, "https://img1.ak.crunchyroll.com/i/spire2/17460e3d58c86bcf88eb33a741a912b81632471800_main.jpg", 29 },
                    { 106, "https://e00-marca.uecdn.es/assets/multimedia/imagenes/2022/01/12/16419978817192.jpg", 29 },
                    { 107, "https://cdn.alfabetajuega.com/alfabetajuega/2022/06/pokemon-escarlata-purpura-koraidon-miraidon.jpg", 30 },
                    { 108, "https://media.redadn.es/imagenes/pokemon-escarlata-y-pokemon-purpura-nintendo-switch_344447.jpg", 30 },
                    { 109, "https://media.vandal.net/i/1200x630/6-2022/202262956397_1.jpg", 30 },
                    { 110, "https://as01.epimg.net/meristation/imagenes/2022/06/01/noticias/1654093877_803563_1654094739_noticia_normal.jpg", 30 },
                    { 111, "https://image.api.playstation.com/vulcan/ap/rnd/202206/0919/hq6KtnlrPbnUj7iNNI0V6gwe.png", 31 },
                    { 112, "https://www.pcmrace.com/wp-content/uploads/2021/03/ss_f6dcf0cdc756ae083c39b237a996ac070a06ce5c.1920x1080.jpg", 31 },
                    { 113, "https://www.pcmrace.com/wp-content/uploads/2022/02/ss_cdf307b445e56cc26834c3c101b197722e87eb82.1920x1080.jpg", 31 },
                    { 114, "https://www.fun-academy.fr/wp-content/uploads/2022/06/1655720936_Shredders-Revenge-Dev-pourrait-creer-un-contenu-telechargeable-en-fonction..jpg", 31 },
                    { 115, "https://cdn.givemesport.com/wp-content/uploads/2022/05/sonic-the-hedgehog.jpg", 1 },
                    { 116, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTewjNfHf1khy__CDnR8vUbIxeb6Q9FWqbWSAhWWK62DbHTSXZWVXoFUkeb5klKmflg7jQ&usqp=CAU", 1 },
                    { 117, "https://deluxe.news/wp-content/uploads/2022/04/1650468696_Sonic-Origins-Collection-to-release-in-June-with-confusing-DLC.jpg", 1 },
                    { 118, "https://t2.tudocdn.net/543353?w=1920&h=1080", 2 },
                    { 119, "https://images-na.ssl-images-amazon.com/images/S/pv-target-images/4d74e8eabfe62b330b0fdc168f7b84980a72391769f19b846a095915a96a5cb0._RI_.jpg", 2 },
                    { 120, "https://i.ytimg.com/vi/Tf-aqCnu4Jw/maxresdefault.jpg", 2 },
                    { 121, "https://cdn1.epicgames.com/offer/03208f1f61764f5a8f6b7ea24c56edf1/XXXX_Store_Landscape_2560x1440_2560x1440-5f9186dedfc0626bcd7f347d5909723a?h=270&resize=1&w=480", 12 }
                });

            migrationBuilder.InsertData(
                table: "Producto_Categoria",
                columns: new[] { "Id", "CategoriaId", "JuegoId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 6, 1 },
                    { 4, 1, 2 },
                    { 5, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Producto_Categoria",
                columns: new[] { "Id", "CategoriaId", "JuegoId" },
                values: new object[,]
                {
                    { 6, 2, 3 },
                    { 7, 12, 4 },
                    { 8, 6, 5 },
                    { 9, 7, 5 },
                    { 10, 1, 6 },
                    { 11, 2, 6 },
                    { 12, 7, 7 },
                    { 13, 1, 7 },
                    { 14, 3, 8 },
                    { 15, 6, 8 },
                    { 16, 11, 9 },
                    { 17, 12, 9 },
                    { 18, 1, 10 },
                    { 19, 4, 10 },
                    { 20, 10, 10 },
                    { 21, 1, 11 },
                    { 22, 2, 11 },
                    { 23, 9, 11 },
                    { 24, 12, 12 },
                    { 25, 1, 13 },
                    { 26, 2, 13 },
                    { 27, 1, 14 },
                    { 28, 4, 14 },
                    { 29, 1, 15 },
                    { 30, 2, 15 },
                    { 31, 3, 15 },
                    { 32, 9, 15 },
                    { 33, 2, 16 },
                    { 34, 4, 16 },
                    { 35, 9, 16 },
                    { 36, 10, 16 },
                    { 37, 1, 17 },
                    { 38, 4, 17 },
                    { 39, 10, 17 },
                    { 40, 1, 18 },
                    { 41, 2, 18 },
                    { 42, 8, 18 },
                    { 43, 9, 18 },
                    { 44, 10, 18 },
                    { 45, 2, 19 },
                    { 46, 9, 19 },
                    { 47, 10, 19 }
                });

            migrationBuilder.InsertData(
                table: "Producto_Categoria",
                columns: new[] { "Id", "CategoriaId", "JuegoId" },
                values: new object[,]
                {
                    { 48, 11, 19 },
                    { 49, 1, 20 },
                    { 50, 10, 20 },
                    { 51, 1, 21 },
                    { 52, 6, 21 },
                    { 53, 1, 22 },
                    { 54, 2, 22 },
                    { 55, 1, 23 },
                    { 56, 2, 23 },
                    { 57, 6, 23 },
                    { 58, 1, 24 },
                    { 59, 2, 24 },
                    { 60, 9, 24 },
                    { 61, 1, 25 },
                    { 62, 7, 25 },
                    { 63, 1, 26 },
                    { 64, 2, 26 },
                    { 65, 9, 26 },
                    { 66, 1, 27 },
                    { 67, 2, 27 },
                    { 68, 9, 27 },
                    { 69, 1, 28 },
                    { 70, 2, 28 },
                    { 71, 9, 28 },
                    { 72, 1, 29 },
                    { 73, 2, 29 },
                    { 74, 7, 29 },
                    { 75, 9, 29 },
                    { 76, 1, 30 },
                    { 77, 2, 30 },
                    { 78, 7, 30 },
                    { 79, 9, 30 },
                    { 80, 1, 31 },
                    { 81, 2, 31 },
                    { 82, 7, 31 },
                    { 83, 1, 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imagenes_JuegoId",
                table: "Imagenes",
                column: "JuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_Juego_ClasificacionId",
                table: "Juego",
                column: "ClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Juego_PlataformaId",
                table: "Juego",
                column: "PlataformaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Categoria_CategoriaId",
                table: "Producto_Categoria",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Categoria_JuegoId",
                table: "Producto_Categoria",
                column: "JuegoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagenes");

            migrationBuilder.DropTable(
                name: "Producto_Categoria");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Juego");

            migrationBuilder.DropTable(
                name: "Clasificacion");

            migrationBuilder.DropTable(
                name: "Plataforma");
        }
    }
}
