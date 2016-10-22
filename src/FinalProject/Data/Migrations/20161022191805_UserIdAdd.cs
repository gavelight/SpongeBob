using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Data.Migrations
{
    public partial class UserIdAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Sale",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ApplicationUserId",
                table: "Sale",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_AspNetUsers_ApplicationUserId",
                table: "Sale",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_AspNetUsers_ApplicationUserId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_ApplicationUserId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Sale");
        }
    }
}
