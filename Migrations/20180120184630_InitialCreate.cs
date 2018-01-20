using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace poptwit.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Comparisons",
                columns: table => new
                {
                    TweetComparisonId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AMatchCount = table.Column<long>(nullable: false),
                    APhrase = table.Column<string>(nullable: true),
                    BMatchCount = table.Column<long>(nullable: false),
                    BPhrase = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    DateRange = table.Column<TimeSpan>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comparisons", x => x.TweetComparisonId);
                    table.ForeignKey(
                        name: "FK_Comparisons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comparisons_UserId",
                table: "Comparisons",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comparisons");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
