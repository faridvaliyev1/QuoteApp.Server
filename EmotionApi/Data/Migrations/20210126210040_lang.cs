using Microsoft.EntityFrameworkCore.Migrations;

namespace Catstagram.Server.Data.Migrations
{
    public partial class lang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lang",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lang",
                table: "Quotes");
        }
    }
}
