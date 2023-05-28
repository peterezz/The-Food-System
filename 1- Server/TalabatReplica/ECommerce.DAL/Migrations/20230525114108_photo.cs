using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refreshTokens_AspNetUsers_ApplicationUserId",
                table: "refreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_refreshTokens",
                table: "refreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_refreshTokens_ApplicationUserId",
                table: "refreshTokens");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "MenuItems");

            migrationBuilder.RenameTable(
                name: "refreshTokens",
                newName: "RefreshToken");

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "MenuItems",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "RefreshToken",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken",
                columns: new[] { "ApplicationUserId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_AspNetUsers_ApplicationUserId",
                table: "RefreshToken",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_AspNetUsers_ApplicationUserId",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "image",
                table: "MenuItems");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                newName: "refreshTokens");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "refreshTokens",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_refreshTokens",
                table: "refreshTokens",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_refreshTokens_ApplicationUserId",
                table: "refreshTokens",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_refreshTokens_AspNetUsers_ApplicationUserId",
                table: "refreshTokens",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
