using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialDatingApp.Infrastructure.Migrations
{
    public partial class AddConnectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Connection",
                columns: table => new
                {
                    ConnectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId2 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_Connection_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Connection_User_UserId2",
                        column: x => x.UserId2,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connection_UserId1",
                table: "Connection",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_UserId2",
                table: "Connection",
                column: "UserId2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connection");
        }
    }
}
