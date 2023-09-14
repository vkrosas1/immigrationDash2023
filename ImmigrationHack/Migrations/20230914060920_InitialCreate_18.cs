using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImmigrationHack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_DocumentTypes_DocumentTypeId",
                table: "Forms");

            migrationBuilder.DropTable(
                name: "Path1");

            migrationBuilder.DropIndex(
                name: "IX_Forms_DocumentTypeId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "Forms");

            migrationBuilder.AddColumn<string>(
                name: "DocumentTypeName",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EligiblePaths",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Paths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentTypes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paths", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paths");

            migrationBuilder.DropColumn(
                name: "DocumentTypeName",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "EligiblePaths",
                table: "Forms");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentTypeId",
                table: "Forms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Path1",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Path1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Path1_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Path1_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Path1_Path1_Path1Id",
                        column: x => x.Path1Id,
                        principalTable: "Path1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_DocumentTypeId",
                table: "Forms",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Path1_DocumentTypeId",
                table: "Path1",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Path1_FormId",
                table: "Path1",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Path1_Path1Id",
                table: "Path1",
                column: "Path1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_DocumentTypes_DocumentTypeId",
                table: "Forms",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
