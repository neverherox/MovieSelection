using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieSelection.Data.Migrations
{
    public partial class DeleteMovieImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieImages");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Movies",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "MovieImages",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieImages", x => x.MovieId);
                });
        }
    }
}
