using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false),
                    Zespol = table.Column<string>(type: "TEXT", nullable: true),
                    Notowanie = table.Column<int>(type: "INTEGER", nullable: true),
                    Data_wydania = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "albums",
                columns: new[] { "Id", "Data_wydania", "Nazwa", "Notowanie", "Zespol" },
                values: new object[] { 5, null, "Nazwa", null, null });

            migrationBuilder.InsertData(
                table: "albums",
                columns: new[] { "Id", "Data_wydania", "Nazwa", "Notowanie", "Zespol" },
                values: new object[] { 6, null, "Nazwa2", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "albums");
        }
    }
}
