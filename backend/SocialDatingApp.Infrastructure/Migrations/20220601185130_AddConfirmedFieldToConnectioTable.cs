using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialDatingApp.Infrastructure.Migrations
{
    public partial class AddConfirmedFieldToConnectioTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Connection",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Connection");
        }
    }
}
