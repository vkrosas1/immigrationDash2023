using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImmigrationHack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Path1s_DocumentTypes_DocumentTypeId",
                table: "Path1s");

            migrationBuilder.DropForeignKey(
                name: "FK_Path1s_Forms_FormId",
                table: "Path1s");

            migrationBuilder.DropForeignKey(
                name: "FK_Path1s_Path1s_Path1Id",
                table: "Path1s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Path1s",
                table: "Path1s");

            migrationBuilder.RenameTable(
                name: "Path1s",
                newName: "Path1");

            migrationBuilder.RenameIndex(
                name: "IX_Path1s_Path1Id",
                table: "Path1",
                newName: "IX_Path1_Path1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Path1s_FormId",
                table: "Path1",
                newName: "IX_Path1_FormId");

            migrationBuilder.RenameIndex(
                name: "IX_Path1s_DocumentTypeId",
                table: "Path1",
                newName: "IX_Path1_DocumentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Path1",
                table: "Path1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Path1_DocumentTypes_DocumentTypeId",
                table: "Path1",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Path1_Forms_FormId",
                table: "Path1",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Path1_Path1_Path1Id",
                table: "Path1",
                column: "Path1Id",
                principalTable: "Path1",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Path1_DocumentTypes_DocumentTypeId",
                table: "Path1");

            migrationBuilder.DropForeignKey(
                name: "FK_Path1_Forms_FormId",
                table: "Path1");

            migrationBuilder.DropForeignKey(
                name: "FK_Path1_Path1_Path1Id",
                table: "Path1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Path1",
                table: "Path1");

            migrationBuilder.RenameTable(
                name: "Path1",
                newName: "Path1s");

            migrationBuilder.RenameIndex(
                name: "IX_Path1_Path1Id",
                table: "Path1s",
                newName: "IX_Path1s_Path1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Path1_FormId",
                table: "Path1s",
                newName: "IX_Path1s_FormId");

            migrationBuilder.RenameIndex(
                name: "IX_Path1_DocumentTypeId",
                table: "Path1s",
                newName: "IX_Path1s_DocumentTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Path1s",
                table: "Path1s",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Path1s_DocumentTypes_DocumentTypeId",
                table: "Path1s",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Path1s_Forms_FormId",
                table: "Path1s",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Path1s_Path1s_Path1Id",
                table: "Path1s",
                column: "Path1Id",
                principalTable: "Path1s",
                principalColumn: "Id");
        }
    }
}
