using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class IdentityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fefb3a39-ef3a-41db-a423-39844dbda7da", "2553e3cf-0293-40b9-942f-2573eda46e4d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aad82ec9-f685-4cf8-a424-76875936d557", "aa0193b6-736e-4961-962f-ef0d5705b446" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aad82ec9-f685-4cf8-a424-76875936d557");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fefb3a39-ef3a-41db-a423-39844dbda7da");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2553e3cf-0293-40b9-942f-2573eda46e4d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa0193b6-736e-4961-962f-ef0d5705b446");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a3d3dee9-2aa7-4964-a3c2-e3788471a376", "a3d3dee9-2aa7-4964-a3c2-e3788471a376", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc06a0c6-c7bc-4c8e-9d37-0d2175cdc698", "fc06a0c6-c7bc-4c8e-9d37-0d2175cdc698", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7b577e51-23c9-45b0-adf0-eca79d3f02f6", 0, "52011002-7a2f-4da5-b247-17b5cd4eab80", "user@wsei.edu.pl", true, false, null, null, "user", "AQAAAAEAACcQAAAAEO0ZFifY8mForagvxl72baj5eX8/PbAVGXwwMH0+KSyckekicOUVfhu9rltzAwL/kg==", null, false, "1435db12-40c4-41ab-8959-5b2003a9461f", false, "user" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "94f048a3-a032-4b55-905d-a9ac58b94cc6", 0, "4fbc8f10-cdfc-403b-8257-7923222fb6de", "adam@wsei.edu.pl", true, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEBRMsEcMVczkkSSqiAQtvQwELWPECGkZdZDjGT24OOYR1DvKVoYoPvopjZ9jD3ittA==", null, false, "f93875ce-62ba-4efa-b4d1-0e9d73c0ca3b", false, "adam" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a3d3dee9-2aa7-4964-a3c2-e3788471a376", "7b577e51-23c9-45b0-adf0-eca79d3f02f6" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fc06a0c6-c7bc-4c8e-9d37-0d2175cdc698", "94f048a3-a032-4b55-905d-a9ac58b94cc6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a3d3dee9-2aa7-4964-a3c2-e3788471a376", "7b577e51-23c9-45b0-adf0-eca79d3f02f6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc06a0c6-c7bc-4c8e-9d37-0d2175cdc698", "94f048a3-a032-4b55-905d-a9ac58b94cc6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3d3dee9-2aa7-4964-a3c2-e3788471a376");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc06a0c6-c7bc-4c8e-9d37-0d2175cdc698");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b577e51-23c9-45b0-adf0-eca79d3f02f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94f048a3-a032-4b55-905d-a9ac58b94cc6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aad82ec9-f685-4cf8-a424-76875936d557", "aad82ec9-f685-4cf8-a424-76875936d557", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fefb3a39-ef3a-41db-a423-39844dbda7da", "fefb3a39-ef3a-41db-a423-39844dbda7da", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2553e3cf-0293-40b9-942f-2573eda46e4d", 0, "64506397-0c43-45dd-baf4-d17bc6332e74", "adam@wsei.edu.pl", true, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEJUd0636pay6BIKGWULC4ek0Y8QJZzD1mYdUNjsmOI5JT6iDg4aIQzlTdvacN0HPrw==", null, false, "63c1466a-380f-4c53-8a9e-4415df51ec18", false, "adam" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "aa0193b6-736e-4961-962f-ef0d5705b446", 0, "00dd8806-adb2-4258-84e6-f50c8af2da12", "user@wsei.edu.pl", true, false, null, null, "user", "AQAAAAEAACcQAAAAEInVoCBSucqQW42Xs0iJKhNYjAXIOvlykrGBH2oiJl3Kaw96w8Wh5Nnuk0Hx4MebDg==", null, false, "0aa7264b-74be-419b-9b2b-69389a7f805a", false, "user" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fefb3a39-ef3a-41db-a423-39844dbda7da", "2553e3cf-0293-40b9-942f-2573eda46e4d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "aad82ec9-f685-4cf8-a424-76875936d557", "aa0193b6-736e-4961-962f-ef0d5705b446" });
        }
    }
}
