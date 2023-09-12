using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImmigrationHack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTypes_Paths_PathId",
                table: "DocumentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Paths_UserPaths_UserPathId",
                table: "Paths");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDocuments_UsersInfo_UserId",
                table: "UserDocuments");

            migrationBuilder.DropTable(
                name: "UserPaths");

            migrationBuilder.DropTable(
                name: "UsersAuth");

            migrationBuilder.DropTable(
                name: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_Paths_UserPathId",
                table: "Paths");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTypes_PathId",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "UserPathId",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "PathId",
                table: "DocumentTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentTypeId",
                table: "Paths",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paths_DocumentTypeId",
                table: "Paths",
                column: "DocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_DocumentTypes_DocumentTypeId",
                table: "Paths",
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
                name: "FK_Paths_DocumentTypes_DocumentTypeId",
                table: "Paths");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDocuments_Users_UserId",
                table: "UserDocuments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Paths_DocumentTypeId",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "Paths");

            migrationBuilder.AddColumn<Guid>(
                name: "UserPathId",
                table: "Paths",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PathId",
                table: "DocumentTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersAuth",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAuth", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "UsersInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CitizenCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPaths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPaths_UsersInfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UsersInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paths_UserPathId",
                table: "Paths",
                column: "UserPathId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_PathId",
                table: "DocumentTypes",
                column: "PathId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaths_UserInfoId",
                table: "UserPaths",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTypes_Paths_PathId",
                table: "DocumentTypes",
                column: "PathId",
                principalTable: "Paths",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_UserPaths_UserPathId",
                table: "Paths",
                column: "UserPathId",
                principalTable: "UserPaths",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDocuments_UsersInfo_UserId",
                table: "UserDocuments",
                column: "UserId",
                principalTable: "UsersInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
