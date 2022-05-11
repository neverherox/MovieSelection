using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieSelection.Data.Migrations
{
    public partial class AddSavingId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Savings",
                table: "Savings");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Savings",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Savings",
                table: "Savings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_UserId",
                table: "Savings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Savings",
                table: "Savings");

            migrationBuilder.DropIndex(
                name: "IX_Savings_UserId",
                table: "Savings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Savings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Savings",
                table: "Savings",
                columns: new[] { "UserId", "MovieId" });
        }
    }
}
