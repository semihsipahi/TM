using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TM.Core.Migrations
{
    /// <inheritdoc />
    public partial class V5_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoComments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoComments",
                columns: table => new
                {
                    PKTodoCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoPKTodoId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FKTodoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoComments", x => x.PKTodoCommentId);
                    table.ForeignKey(
                        name: "FK_TodoComments_Todos_TodoPKTodoId",
                        column: x => x.TodoPKTodoId,
                        principalTable: "Todos",
                        principalColumn: "PKTodoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoComments_TodoPKTodoId",
                table: "TodoComments",
                column: "TodoPKTodoId");
        }
    }
}
