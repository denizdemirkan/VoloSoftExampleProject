using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleProject.Migrations
{
    /// <inheritdoc />
    public partial class SqlExceptionRollBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Example",
                table: "AppBooks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Example",
                table: "AppBooks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
