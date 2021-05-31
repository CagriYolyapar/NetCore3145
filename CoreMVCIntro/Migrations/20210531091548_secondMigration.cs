using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreMVCIntro.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Profiles",
                newName: "Yaratılma Tarihi");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Products",
                newName: "Yaratılma Tarihi");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Orders",
                newName: "Yaratılma Tarihi");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Categories",
                newName: "Yaratılma Tarihi");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Products",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Yaratılma Tarihi",
                table: "Profiles",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Yaratılma Tarihi",
                table: "Products",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Yaratılma Tarihi",
                table: "Orders",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Yaratılma Tarihi",
                table: "Categories",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
