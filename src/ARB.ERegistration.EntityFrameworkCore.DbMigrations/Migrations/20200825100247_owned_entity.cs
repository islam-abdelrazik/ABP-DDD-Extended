using Microsoft.EntityFrameworkCore.Migrations;

namespace ARB.ERegistration.Migrations
{
    public partial class owned_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ATMCard_PinCode",
                table: "EReg.RetailCustomers",
                newName: "PinCode");

            migrationBuilder.RenameColumn(
                name: "ATMCard_CardNumber",
                table: "EReg.RetailCustomers",
                newName: "CardNumber");

            migrationBuilder.AlterColumn<string>(
                name: "PinCode",
                table: "EReg.RetailCustomers",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "EReg.RetailCustomers",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PinCode",
                table: "EReg.RetailCustomers",
                newName: "ATMCard_PinCode");

            migrationBuilder.RenameColumn(
                name: "CardNumber",
                table: "EReg.RetailCustomers",
                newName: "ATMCard_CardNumber");

            migrationBuilder.AlterColumn<string>(
                name: "ATMCard_PinCode",
                table: "EReg.RetailCustomers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ATMCard_CardNumber",
                table: "EReg.RetailCustomers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
