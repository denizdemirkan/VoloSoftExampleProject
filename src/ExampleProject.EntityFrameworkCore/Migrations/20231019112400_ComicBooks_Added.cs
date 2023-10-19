using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleProject.Migrations
{
    /// <inheritdoc />
    public partial class ComicBooks_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBooks_AppAuthors_AuthorId",
                table: "AppBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppBooks",
                table: "AppBooks");

            migrationBuilder.RenameTable(
                name: "AppBooks",
                newName: "AppComicBooks");

            migrationBuilder.RenameIndex(
                name: "IX_AppBooks_AuthorId",
                table: "AppComicBooks",
                newName: "IX_AppComicBooks_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppComicBooks",
                table: "AppComicBooks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ComicBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicBooks", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AppComicBooks_AppAuthors_AuthorId",
                table: "AppComicBooks",
                column: "AuthorId",
                principalTable: "AppAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppComicBooks_AppAuthors_AuthorId",
                table: "AppComicBooks");

            migrationBuilder.DropTable(
                name: "ComicBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppComicBooks",
                table: "AppComicBooks");

            migrationBuilder.RenameTable(
                name: "AppComicBooks",
                newName: "AppBooks");

            migrationBuilder.RenameIndex(
                name: "IX_AppComicBooks_AuthorId",
                table: "AppBooks",
                newName: "IX_AppBooks_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppBooks",
                table: "AppBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBooks_AppAuthors_AuthorId",
                table: "AppBooks",
                column: "AuthorId",
                principalTable: "AppAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
