using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TM.Core.Migrations
{
    /// <inheritdoc />
    public partial class V11_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FKUserId",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FKUserId",
                table: "Todos");
        }
    }
}
