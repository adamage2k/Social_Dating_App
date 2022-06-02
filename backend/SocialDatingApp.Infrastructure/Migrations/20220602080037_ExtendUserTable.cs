using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialDatingApp.Infrastructure.Migrations
{
    public partial class ExtendUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LookingFor",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LookingFor",
                table: "User");
        }
    }
}
