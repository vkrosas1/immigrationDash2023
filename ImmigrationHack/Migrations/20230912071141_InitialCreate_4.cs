using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImmigrationHack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Paths_PathId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PathId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PathId",
                table: "Documents");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentTypeId",
                table: "Forms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentTypeId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypes_Paths_PathId",
                        column: x => x.PathId,
                        principalTable: "Paths",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_DocumentTypeId",
                table: "Forms",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_PathId",
                table: "DocumentTypes",
                column: "PathId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_DocumentTypes_DocumentTypeId",
                table: "Forms",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_DocumentTypes_DocumentTypeId",
                table: "Forms");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Forms_DocumentTypeId",
                table: "Forms");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PathId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PathId",
                table: "Documents",
                column: "PathId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Paths_PathId",
                table: "Documents",
                column: "PathId",
                principalTable: "Paths",
                principalColumn: "Id");
        }
    }
}
