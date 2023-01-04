using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPIMusic.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SongCover : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "MediathequeSongs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "DeezerSongs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "CompilationSongs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "MediathequeSongs");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "DeezerSongs");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "CompilationSongs");
        }
    }
}
