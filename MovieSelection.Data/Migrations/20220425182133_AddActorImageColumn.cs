using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieSelection.Data.Migrations
{
    public partial class AddActorImageColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Actors",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Actors");
        }
    }
}
