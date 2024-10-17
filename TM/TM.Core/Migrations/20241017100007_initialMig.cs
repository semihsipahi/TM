using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TM.Core.Migrations
{
    /// <inheritdoc />
    public partial class initialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    PKId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoryPoint = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.PKId);
                });

            migrationBuilder.CreateTable(
                name: "TodoComments",
                columns: table => new
                {
                    PKId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKTodoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TodoPKId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoComments", x => x.PKId);
                    table.ForeignKey(
                        name: "FK_TodoComments_Todos_TodoPKId",
                        column: x => x.TodoPKId,
                        principalTable: "Todos",
                        principalColumn: "PKId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoComments_TodoPKId",
                table: "TodoComments",
                column: "TodoPKId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoComments");

            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
