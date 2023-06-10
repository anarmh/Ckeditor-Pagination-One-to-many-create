using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello_backend.Migrations
{
    public partial class AddIsMainProductImageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "ProductImages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "ProductImages");
        }
    }
}
