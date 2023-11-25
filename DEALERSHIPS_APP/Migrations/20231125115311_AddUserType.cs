using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEALERSHIPS_APP.Migrations
{
    /// <inheritdoc />
    public partial class AddUserType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UPDATED",
                table: "OWNERSHIP_HISTORIES");

            migrationBuilder.CreateTable(
                name: "LOGINCREDENTIALS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PHONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime", nullable: false),
                    USER_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGINCREDENTIALS", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "UQ_OWNERS_PHONE",
                table: "OWNERS",
                column: "PHONE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_GARAGES_PHONE",
                table: "GARAGES",
                column: "PHONE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_LOGINCREDENTIALS_PHONE",
                table: "LOGINCREDENTIALS",
                column: "PHONE",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOGINCREDENTIALS");

            migrationBuilder.DropIndex(
                name: "UQ_OWNERS_PHONE",
                table: "OWNERS");

            migrationBuilder.DropIndex(
                name: "UQ_GARAGES_PHONE",
                table: "GARAGES");

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED",
                table: "OWNERSHIP_HISTORIES",
                type: "datetime",
                nullable: true);
        }
    }
}
