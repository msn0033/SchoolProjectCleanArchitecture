using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_table_USerRefreshTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    JwtSecurityTokenId = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RefreshTokenString = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AddTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "UserRefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRefreshTokens");
        }
    }
}
