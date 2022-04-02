using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxFairy.Infrastructure.Data.Migrations
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Vendors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_ApplicationUserId",
                table: "Vendors",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_AspNetUsers_ApplicationUserId",
                table: "Vendors",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_AspNetUsers_ApplicationUserId",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_ApplicationUserId",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");
        }
    }
}
