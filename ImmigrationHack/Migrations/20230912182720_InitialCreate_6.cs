using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImmigrationHack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserPathId",
                table: "Paths",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserPaths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPaths_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paths_UserPathId",
                table: "Paths",
                column: "UserPathId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaths_UserId",
                table: "UserPaths",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_UserPaths_UserPathId",
                table: "Paths",
                column: "UserPathId",
                principalTable: "UserPaths",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paths_UserPaths_UserPathId",
                table: "Paths");

            migrationBuilder.DropTable(
                name: "UserPaths");

            migrationBuilder.DropIndex(
                name: "IX_Paths_UserPathId",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "UserPathId",
                table: "Paths");
        }
    }
}
