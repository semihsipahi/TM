using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TM.Core.Migrations
{
    /// <inheritdoc />
    public partial class v4_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoComments_Todos_TodoPKId",
                table: "TodoComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoComments",
                table: "TodoComments");

            migrationBuilder.DropIndex(
                name: "IX_TodoComments_TodoPKId",
                table: "TodoComments");

            migrationBuilder.DropColumn(
                name: "PKId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "PKId",
                table: "TodoComments");

            migrationBuilder.DropColumn(
                name: "TodoPKId",
                table: "TodoComments");

            migrationBuilder.AddColumn<int>(
                name: "PKTodoId",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PKTodoCommentId",
                table: "TodoComments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TodoPKTodoId",
                table: "TodoComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "PKTodoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoComments",
                table: "TodoComments",
                column: "PKTodoCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoComments_TodoPKTodoId",
                table: "TodoComments",
                column: "TodoPKTodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoComments_Todos_TodoPKTodoId",
                table: "TodoComments",
                column: "TodoPKTodoId",
                principalTable: "Todos",
                principalColumn: "PKTodoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoComments_Todos_TodoPKTodoId",
                table: "TodoComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoComments",
                table: "TodoComments");

            migrationBuilder.DropIndex(
                name: "IX_TodoComments_TodoPKTodoId",
                table: "TodoComments");

            migrationBuilder.DropColumn(
                name: "PKTodoId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "PKTodoCommentId",
                table: "TodoComments");

            migrationBuilder.DropColumn(
                name: "TodoPKTodoId",
                table: "TodoComments");

            migrationBuilder.AddColumn<Guid>(
                name: "PKId",
                table: "Todos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PKId",
                table: "TodoComments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TodoPKId",
                table: "TodoComments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "PKId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoComments",
                table: "TodoComments",
                column: "PKId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoComments_TodoPKId",
                table: "TodoComments",
                column: "TodoPKId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoComments_Todos_TodoPKId",
                table: "TodoComments",
                column: "TodoPKId",
                principalTable: "Todos",
                principalColumn: "PKId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
