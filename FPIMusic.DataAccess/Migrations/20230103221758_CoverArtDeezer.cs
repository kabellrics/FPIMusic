using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPIMusic.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CoverArtDeezer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "DeezerArtistes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "DeezerArtistes");
        }
    }
}
