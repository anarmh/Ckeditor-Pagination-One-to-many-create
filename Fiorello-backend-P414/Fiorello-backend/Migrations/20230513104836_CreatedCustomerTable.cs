using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello_backend.Migrations
{
    public partial class CreatedCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "CreatedDate", "FullName", "SoftDelete" },
                values: new object[] { 1, 16, new DateTime(2023, 5, 13, 14, 48, 35, 325, DateTimeKind.Local).AddTicks(2916), "Rasul Hasanov", false });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "CreatedDate", "FullName", "SoftDelete" },
                values: new object[] { 2, 25, new DateTime(2023, 5, 13, 14, 48, 35, 325, DateTimeKind.Local).AddTicks(2939), "Novreste Aslanzade", false });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "CreatedDate", "FullName", "SoftDelete" },
                values: new object[] { 3, 19, new DateTime(2023, 5, 13, 14, 48, 35, 325, DateTimeKind.Local).AddTicks(2941), "Musa Afandiyev", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
