using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopEntertainment.Juegos.AccessData.Migrations
{
    public partial class TopEnterTainmentJuegos : Migration
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
                    { 1, "Juegos de plataforma y aventuras.", "Platformer" },
                    { 2, "Juegos de disparos.", "FPS" },
                    { 3, "Juegos de Rol y Estrategia.", "RPG" }
                });

            migrationBuilder.InsertData(
                table: "Clasificacion",
                columns: new[] { "ClasificacionId", "Descripcion", "NombreClasificacion" },
                values: new object[,]
                {
                    { 1, "Apto para todo público.", "E for Everyone." },
                    { 2, "Apto para mayores de 13 años.", "PG 13" }
                });

            migrationBuilder.InsertData(
                table: "Plataforma",
                columns: new[] { "PlataformaId", "Descripcion", "NombrePlataforma" },
                values: new object[,]
                {
                    { 1, "Consola de Sony de última generación.", "PlayStation 5" },
                    { 2, "Consola Económica de Microsoft de última generación.", "Xbox Series S" }
                });

            migrationBuilder.InsertData(
                table: "Juego",
                columns: new[] { "JuegoId", "ClasificacionId", "Descripcion", "EnOferta", "NombreProducto", "PlataformaId", "Precio", "SoftDelete", "Stock", "Video" },
                values: new object[] { 1, 1, "Juegos clásicos de Sonic remasterizados.", false, "Sonic Origins", 1, 45m, false, 10, "https://www.youtube.com/watch?v=ZzHXjAJ86Zw" });

            migrationBuilder.InsertData(
                table: "Juego",
                columns: new[] { "JuegoId", "ClasificacionId", "Descripcion", "EnOferta", "NombreProducto", "PlataformaId", "Precio", "SoftDelete", "Stock", "Video" },
                values: new object[] { 2, 1, "Juego de Crash más reciente.", false, "Crash Bandicoot 4: It’s About Time", 2, 30m, false, 20, "https://www.youtube.com/watch?v=aOGwx3Ju6QQ" });

            migrationBuilder.InsertData(
                table: "Imagenes",
                columns: new[] { "ImagenId", "ImagenUrl", "JuegoId" },
                values: new object[,]
                {
                    { 1, "https://i.imgur.com/4Hk05rT.png", 1 },
                    { 2, "https://i.imgur.com/86iraFT.png", 2 }
                });

            migrationBuilder.InsertData(
                table: "Producto_Categoria",
                columns: new[] { "Id", "CategoriaId", "JuegoId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 }
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
