﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TM.Core.Migrations
{
    /// <inheritdoc />
    public partial class V23_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Users_UserPKUserId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_UserPKUserId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "UserPKUserId",
                table: "Todos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserPKUserId",
                table: "Todos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserPKUserId",
                table: "Todos",
                column: "UserPKUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Users_UserPKUserId",
                table: "Todos",
                column: "UserPKUserId",
                principalTable: "Users",
                principalColumn: "PKUserId");
        }
    }
}
