using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPIMusic.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SetUniqueColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MediathequeSongs_Path",
                table: "MediathequeSongs",
                column: "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeezerSongs_Path",
                table: "DeezerSongs",
                column: "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompilationSongs_Path",
                table: "CompilationSongs",
                column: "Path",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MediathequeSongs_Path",
                table: "MediathequeSongs");

            migrationBuilder.DropIndex(
                name: "IX_DeezerSongs_Path",
                table: "DeezerSongs");

            migrationBuilder.DropIndex(
                name: "IX_CompilationSongs_Path",
                table: "CompilationSongs");
        }
    }
}
