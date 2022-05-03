using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieSelection.Data.Migrations
{
    public partial class AddReviewForeignKeyInReviewLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReviewLikes_ReviewId",
                table: "ReviewLikes",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewLikes_Reviews_ReviewId",
                table: "ReviewLikes",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewLikes_Reviews_ReviewId",
                table: "ReviewLikes");

            migrationBuilder.DropIndex(
                name: "IX_ReviewLikes_ReviewId",
                table: "ReviewLikes");
        }
    }
}
