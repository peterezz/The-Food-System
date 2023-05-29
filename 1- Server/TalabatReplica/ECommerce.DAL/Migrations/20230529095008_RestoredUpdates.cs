using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class RestoredUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "MenuItems");

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "MenuItems",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "MenuItems");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
