using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEALERSHIPS_APP.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OWNERSHIPS_VEHICLES",
                table: "OWNERSHIPS");

            migrationBuilder.DropIndex(
                name: "IX_OWNERSHIPS_OWNER_ID",
                table: "OWNERSHIPS");

            migrationBuilder.DropIndex(
                name: "IX_OWNERSHIPS_VEHICLE_ID",
                table: "OWNERSHIPS");

            migrationBuilder.DropIndex(
                name: "IX_APPOINTMENTS_GARAGE_ID",
                table: "APPOINTMENTS");

            migrationBuilder.CreateIndex(
                name: "IX_OWNERSHIPS_OWNERID_VEHICLEID",
                table: "OWNERSHIPS",
                columns: new[] { "OWNER_ID", "VEHICLE_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_APPOINTMENTS_GARAGEID_OWNERID_VEHICLEID_DATEOFARRIVAL",
                table: "APPOINTMENTS",
                columns: new[] { "GARAGE_ID", "OWNER_ID", "VEHICLE_ID", "DATE_OF_ARRIVAL" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OWNERSHIPS_VEHICLES",
                table: "VEHICLES",
                column: "ID",
                principalTable: "OWNERSHIPS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OWNERSHIPS_VEHICLES",
                table: "VEHICLES");

            migrationBuilder.DropIndex(
                name: "IX_OWNERSHIPS_OWNERID_VEHICLEID",
                table: "OWNERSHIPS");

            migrationBuilder.DropIndex(
                name: "UQ_APPOINTMENTS_GARAGEID_OWNERID_VEHICLEID_DATEOFARRIVAL",
                table: "APPOINTMENTS");

            migrationBuilder.CreateIndex(
                name: "IX_OWNERSHIPS_OWNER_ID",
                table: "OWNERSHIPS",
                column: "OWNER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OWNERSHIPS_VEHICLE_ID",
                table: "OWNERSHIPS",
                column: "VEHICLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENTS_GARAGE_ID",
                table: "APPOINTMENTS",
                column: "GARAGE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OWNERSHIPS_VEHICLES",
                table: "OWNERSHIPS",
                column: "VEHICLE_ID",
                principalTable: "VEHICLES",
                principalColumn: "ID");
        }
    }
}
