using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FPIMusic.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CoverAndParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "CompilationArtistes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Parametre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametre", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Parametre",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 1, "MediathequePath", "" },
                    { 2, "CompilationPath", "" },
                    { 3, "DeezerPath", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parametre");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "CompilationArtistes");
        }
    }
}
