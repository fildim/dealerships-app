using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEALERSHIPS_APP.Migrations
{
    /// <inheritdoc />
    public partial class final3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OWNERSHIPS_VEHICLES",
                table: "VEHICLES");

            migrationBuilder.DropIndex(
                name: "IX_OWNERSHIPS_OWNERID_VEHICLEID",
                table: "OWNERSHIPS");

            migrationBuilder.AlterColumn<int>(
                name: "OWNER_ID",
                table: "OWNERSHIPS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_OWNERSHIPS_OWNERID_VEHICLEID",
                table: "OWNERSHIPS",
                columns: new[] { "OWNER_ID", "VEHICLE_ID" },
                unique: true,
                filter: "[OWNER_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OWNERSHIPS_VEHICLE_ID",
                table: "OWNERSHIPS",
                column: "VEHICLE_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VEHICLES_OWNERSHIPS",
                table: "OWNERSHIPS",
                column: "VEHICLE_ID",
                principalTable: "VEHICLES",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VEHICLES_OWNERSHIPS",
                table: "OWNERSHIPS");

            migrationBuilder.DropIndex(
                name: "IX_OWNERSHIPS_OWNERID_VEHICLEID",
                table: "OWNERSHIPS");

            migrationBuilder.DropIndex(
                name: "IX_OWNERSHIPS_VEHICLE_ID",
                table: "OWNERSHIPS");

            migrationBuilder.AlterColumn<int>(
                name: "OWNER_ID",
                table: "OWNERSHIPS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OWNERSHIPS_OWNERID_VEHICLEID",
                table: "OWNERSHIPS",
                columns: new[] { "OWNER_ID", "VEHICLE_ID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OWNERSHIPS_VEHICLES",
                table: "VEHICLES",
                column: "ID",
                principalTable: "OWNERSHIPS",
                principalColumn: "ID");
        }
    }
}
