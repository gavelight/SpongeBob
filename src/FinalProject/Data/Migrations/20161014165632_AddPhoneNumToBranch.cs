using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Data.Migrations
{
    public partial class AddPhoneNumToBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Branch",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Branch",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Branch",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Branch",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Branch");

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Branch",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Branch",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Branch",
                nullable: true);
        }
    }
}
