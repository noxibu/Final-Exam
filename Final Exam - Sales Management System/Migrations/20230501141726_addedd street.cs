using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Exam___Sales_Management_System.Migrations
{
    public partial class addeddstreet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Street",
                table: "Addresses");
        }
    }
}
