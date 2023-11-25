using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEALERSHIPS_APP.Migrations
{
    /// <inheritdoc />
    public partial class SetMaxLengthAtUserType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "USER_TYPE",
                table: "LOGINCREDENTIALS",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "USER_TYPE",
                table: "LOGINCREDENTIALS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
