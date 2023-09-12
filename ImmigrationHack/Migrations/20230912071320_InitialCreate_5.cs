using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImmigrationHack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Users_UserId",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "UserDocuments");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_UserId",
                table: "UserDocuments",
                newName: "IX_UserDocuments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "UserDocuments",
                newName: "IX_UserDocuments_DocumentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDocuments",
                table: "UserDocuments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocuments_DocumentTypes_DocumentTypeId",
                table: "UserDocuments",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocuments_Users_UserId",
                table: "UserDocuments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDocuments_DocumentTypes_DocumentTypeId",
                table: "UserDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDocuments_Users_UserId",
                table: "UserDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDocuments",
                table: "UserDocuments");

            migrationBuilder.RenameTable(
                name: "UserDocuments",
                newName: "Documents");

            migrationBuilder.RenameIndex(
                name: "IX_UserDocuments_UserId",
                table: "Documents",
                newName: "IX_Documents_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDocuments_DocumentTypeId",
                table: "Documents",
                newName: "IX_Documents_DocumentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Users_UserId",
                table: "Documents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
