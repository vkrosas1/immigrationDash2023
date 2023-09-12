using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImmigrationHack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Paths_PathId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Users_UserId",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Documents");

            migrationBuilder.RenameIndex(
                name: "IX_Document_UserId",
                table: "Documents",
                newName: "IX_Documents_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_PathId",
                table: "Documents",
                newName: "IX_Documents_PathId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Paths_PathId",
                table: "Documents",
                column: "PathId",
                principalTable: "Paths",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Users_UserId",
                table: "Documents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Paths_PathId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Users_UserId",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "Document");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_UserId",
                table: "Document",
                newName: "IX_Document_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_PathId",
                table: "Document",
                newName: "IX_Document_PathId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Paths_PathId",
                table: "Document",
                column: "PathId",
                principalTable: "Paths",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Users_UserId",
                table: "Document",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
