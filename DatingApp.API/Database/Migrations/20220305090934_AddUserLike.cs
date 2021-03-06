using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Database.Migrations
{
    public partial class AddUserLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLikes",
                columns: table => new
                {
                    SourceUserId = table.Column<int>(type: "int", nullable: false),
                    LikedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikes", x => new { x.LikedUserId, x.SourceUserId });
                    table.ForeignKey(
                        name: "FK_UserLikes_User_LikedUserId",
                        column: x => x.LikedUserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserLikes_User_SourceUserId",
                        column: x => x.SourceUserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_SourceUserId",
                table: "UserLikes",
                column: "SourceUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLikes");
        }
    }
}
