using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEALERSHIPS_APP.Migrations
{
	/// <inheritdoc />
	public partial class Initial : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "DEALERSHIPS",
				columns: table => new
				{
					ID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					PHONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					ADDRESS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					CREATED = table.Column<DateTime>(type: "datetime", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_DEALERSHIPS", x => x.ID);
				});

			migrationBuilder.CreateTable(
				name: "FACTORIES",
				columns: table => new
				{
					ID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					LOCATION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					CREATED = table.Column<DateTime>(type: "datetime", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_FACTORIES", x => x.ID);
				});

			migrationBuilder.CreateTable(
				name: "GARAGES",
				columns: table => new
				{
					ID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					PHONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					ADDRESS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					CREATED = table.Column<DateTime>(type: "datetime", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GARAGES", x => x.ID);
				});

			migrationBuilder.CreateTable(
				name: "OWNERS",
				columns: table => new
				{
					ID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FIRSTNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					LASTNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					PHONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					CREATED = table.Column<DateTime>(type: "datetime", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OWNERS", x => x.ID);
				});

			migrationBuilder.CreateTable(
				name: "VEHICLES",
				columns: table => new
				{
					ID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					VIN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					MODEL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					DATE_OF_MANUFACTURE = table.Column<DateTime>(type: "datetime", nullable: false),
					MILEAGE = table.Column<int>(type: "int", nullable: false),
					CRASHED = table.Column<bool>(type: "bit", nullable: false),
					CREATED = table.Column<DateTime>(type: "datetime", nullable: false),
					UPDATED = table.Column<DateTime>(type: "datetime", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_VEHICLES", x => x.ID);
				});

			migrationBuilder.CreateTable(
				name: "APPOINTMENTS",
				columns: table => new
				{
					ID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					OWNER_ID = table.Column<int>(type: "int", nullable: false),
					VEHICLE_ID = table.Column<int>(type: "int", nullable: false),
					GARAGE_ID = table.Column<int>(type: "int", nullable: false),
					DATE_OF_ARRIVAL = table.Column<DateTime>(type: "datetime", nullable: false),
					MILEAGE = table.Column<int>(type: "int", nullable: false),
					DIAGNOSIS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
					DATE_OF_PICKUP = table.Column<DateTime>(type: "datetime", nullable: true),
					CREATED = table.Column<DateTime>(type: "datetime", nullable: false),
					UPDATED = table.Column<DateTime>(type: "datetime", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_APPOINTMENTS", x => x.ID);
					table.ForeignKey(
						name: "FK_APPOINTMENTS_GARAGES",
						column: x => x.GARAGE_ID,
						principalTable: "GARAGES",
						principalColumn: "ID");
					table.ForeignKey(
						name: "FK_APPOINTMENTS_OWNERS",
						column: x => x.OWNER_ID,
						principalTable: "OWNERS",
						principalColumn: "ID");
					table.ForeignKey(
						name: "FK_APPOINTMENTS_VEHICLES",
						column: x => x.VEHICLE_ID,
						principalTable: "VEHICLES",
						principalColumn: "ID");
				});

			migrationBuilder.CreateTable(
				name: "OWNERSHIP_HISTORIES",
				columns: table => new
				{
					ID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					VEHICLE_ID = table.Column<int>(type: "int", nullable: false),
					FACTORY_ID = table.Column<int>(type: "int", nullable: false),
					DEALERSHIP_ID = table.Column<int>(type: "int", nullable: true),
					PREVIOUS_OWNER_ID = table.Column<int>(type: "int", nullable: true),
					CURRENT_OWNER_ID = table.Column<int>(type: "int", nullable: true),
					DATE_OF_MANUFACTURE = table.Column<DateTime>(type: "datetime", nullable: false),
					DATE_OF_SALE = table.Column<DateTime>(type: "datetime", nullable: true),
					DATE_OF_TRANSFER = table.Column<DateTime>(type: "datetime", nullable: true),
					CREATED = table.Column<DateTime>(type: "datetime", nullable: false),
					UPDATED = table.Column<DateTime>(type: "datetime", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OWNERSHIP_HISTORIES", x => x.ID);
					table.ForeignKey(
						name: "FK_OWNERSHIP_HISTORIES_CURRENT_OWNERS",
						column: x => x.CURRENT_OWNER_ID,
						principalTable: "OWNERS",
						principalColumn: "ID");
					table.ForeignKey(
						name: "FK_OWNERSHIP_HISTORIES_DEALERSHIPS",
						column: x => x.DEALERSHIP_ID,
						principalTable: "DEALERSHIPS",
						principalColumn: "ID");
					table.ForeignKey(
						name: "FK_OWNERSHIP_HISTORIES_FACTORIES",
						column: x => x.FACTORY_ID,
						principalTable: "FACTORIES",
						principalColumn: "ID");
					table.ForeignKey(
						name: "FK_OWNERSHIP_HISTORIES_PREVIOUS_OWNERS",
						column: x => x.PREVIOUS_OWNER_ID,
						principalTable: "OWNERS",
						principalColumn: "ID");
					table.ForeignKey(
						name: "FK_OWNERSHIP_HISTORIES_VEHICLES",
						column: x => x.VEHICLE_ID,
						principalTable: "VEHICLES",
						principalColumn: "ID");
				});

			migrationBuilder.CreateTable(
				name: "OWNERSHIPS",
				columns: table => new
				{
					ID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					VEHICLE_ID = table.Column<int>(type: "int", nullable: false),
					OWNER_ID = table.Column<int>(type: "int", nullable: false),
					CREATED = table.Column<DateTime>(type: "datetime", nullable: false),
					UPDATED = table.Column<DateTime>(type: "datetime", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OWNERSHIPS", x => x.ID);
					table.ForeignKey(
						name: "FK_OWNERSHIPS_OWNERS",
						column: x => x.OWNER_ID,
						principalTable: "OWNERS",
						principalColumn: "ID");
					table.ForeignKey(
						name: "FK_OWNERSHIPS_VEHICLES",
						column: x => x.VEHICLE_ID,
						principalTable: "VEHICLES",
						principalColumn: "ID");
				});

			migrationBuilder.CreateTable(
				name: "ISSUES",
				columns: table => new
				{
					ID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					APPOINTMENT_ID = table.Column<int>(type: "int", nullable: false),
					DESCRIPTION = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
					CREATED = table.Column<DateTime>(type: "datetime", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ISSUES", x => x.ID);
					table.ForeignKey(
						name: "FK_ISSUES_APPOINTMENTS",
						column: x => x.APPOINTMENT_ID,
						principalTable: "APPOINTMENTS",
						principalColumn: "ID");
				});

			migrationBuilder.CreateIndex(
				name: "IX_APPOINTMENTS_GARAGE_ID",
				table: "APPOINTMENTS",
				column: "GARAGE_ID");

			migrationBuilder.CreateIndex(
				name: "IX_APPOINTMENTS_OWNER_ID",
				table: "APPOINTMENTS",
				column: "OWNER_ID");

			migrationBuilder.CreateIndex(
				name: "IX_APPOINTMENTS_VEHICLE_ID",
				table: "APPOINTMENTS",
				column: "VEHICLE_ID");

			migrationBuilder.CreateIndex(
				name: "IX_ISSUES_APPOINTMENT_ID",
				table: "ISSUES",
				column: "APPOINTMENT_ID");

			migrationBuilder.CreateIndex(
				name: "IX_OWNERSHIP_HISTORIES_CURRENT_OWNER_ID",
				table: "OWNERSHIP_HISTORIES",
				column: "CURRENT_OWNER_ID");

			migrationBuilder.CreateIndex(
				name: "IX_OWNERSHIP_HISTORIES_DEALERSHIP_ID",
				table: "OWNERSHIP_HISTORIES",
				column: "DEALERSHIP_ID");

			migrationBuilder.CreateIndex(
				name: "IX_OWNERSHIP_HISTORIES_FACTORY_ID",
				table: "OWNERSHIP_HISTORIES",
				column: "FACTORY_ID");

			migrationBuilder.CreateIndex(
				name: "IX_OWNERSHIP_HISTORIES_PREVIOUS_OWNER_ID",
				table: "OWNERSHIP_HISTORIES",
				column: "PREVIOUS_OWNER_ID");

			migrationBuilder.CreateIndex(
				name: "IX_OWNERSHIP_HISTORIES_VEHICLE_ID",
				table: "OWNERSHIP_HISTORIES",
				column: "VEHICLE_ID");

			migrationBuilder.CreateIndex(
				name: "IX_OWNERSHIPS_OWNER_ID",
				table: "OWNERSHIPS",
				column: "OWNER_ID");

			migrationBuilder.CreateIndex(
				name: "IX_OWNERSHIPS_VEHICLE_ID",
				table: "OWNERSHIPS",
				column: "VEHICLE_ID");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ISSUES");

			migrationBuilder.DropTable(
				name: "OWNERSHIP_HISTORIES");

			migrationBuilder.DropTable(
				name: "OWNERSHIPS");

			migrationBuilder.DropTable(
				name: "APPOINTMENTS");

			migrationBuilder.DropTable(
				name: "DEALERSHIPS");

			migrationBuilder.DropTable(
				name: "FACTORIES");

			migrationBuilder.DropTable(
				name: "GARAGES");

			migrationBuilder.DropTable(
				name: "OWNERS");

			migrationBuilder.DropTable(
				name: "VEHICLES");
		}
	}
}
