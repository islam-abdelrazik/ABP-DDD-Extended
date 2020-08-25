using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARB.ERegistration.Migrations
{
    public partial class Reatil_Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EReg.RetailCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    CommercialRegisterNo = table.Column<string>(nullable: true),
                    CICNo = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ATMCard_PinCode = table.Column<string>(nullable: true),
                    ATMCard_CardNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EReg.RetailCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    BankNumber = table.Column<string>(nullable: true),
                    RetailCustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_EReg.RetailCustomers_RetailCustomerId",
                        column: x => x.RetailCustomerId,
                        principalTable: "EReg.RetailCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_RetailCustomerId",
                table: "BankAccount",
                column: "RetailCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_EReg.RetailCustomers_Name",
                table: "EReg.RetailCustomers",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "EReg.RetailCustomers");
        }
    }
}
