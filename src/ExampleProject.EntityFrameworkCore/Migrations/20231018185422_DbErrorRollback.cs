using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleProject.Migrations
{
    /// <inheritdoc />
    public partial class DbErrorRollback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Example",
                table: "AppBooks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Example",
                table: "AppBooks");
        }
    }
}
