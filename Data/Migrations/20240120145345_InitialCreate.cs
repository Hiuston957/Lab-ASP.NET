using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "albums");

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    birth_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth_date", "Email", "Name", "Phone" },
                values: new object[] { 1, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "adam@wsei.edu.pl", "Adam", "127813268163" });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth_date", "Email", "Name", "Phone" },
                values: new object[] { 2, new DateTime(1999, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ewa@wsei.edu.pl", "Ewa", "293443823478" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data_wydania = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false),
                    Notowanie = table.Column<int>(type: "INTEGER", nullable: true),
                    Zespol = table.Column<string>(type: "TEXT", nullable: true)
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
    }
}
