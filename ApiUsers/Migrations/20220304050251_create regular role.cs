using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiUsers.Migrations
{
    public partial class createregularrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 48475,
                column: "ConcurrencyStamp",
                value: "f630a13e-efc8-4c83-a07e-773125e2a441");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 54859, "66276ad5-2206-48a1-8fee-d947d0cbf2a8", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 620251425,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ceaa2334-0034-4312-b78a-265103b0c46f", "AQAAAAEAACcQAAAAEC06O7mlIoS7YicK+Ag6kV3Ny2scgSEhgs1GuJTwAH3b/HCSsE+9HqPddqBqUit4ig==", "468ab464-74e5-446b-9575-b33feb483e7f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 54859);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 48475,
                column: "ConcurrencyStamp",
                value: "c032a9f4-1d17-4eb7-9825-3c5600650cac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 620251425,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9890d0c5-af8d-478b-b00d-3d6d96855b31", "AQAAAAEAACcQAAAAED9Xt4Q0wT/8RLzQu1IoKDLFq9/Bv67y1wAfMNLCcBmJT7/Rk48RzpVS5EH35v73+Q==", "61ed3a93-a743-4d74-b331-fe9278336855" });
        }
    }
}
