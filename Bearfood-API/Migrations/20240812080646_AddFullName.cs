﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bearfood_API.Migrations
{
    /// <inheritdoc />
    public partial class AddFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "identity",
                table: "AspNetUsers");
        }
    }
}
