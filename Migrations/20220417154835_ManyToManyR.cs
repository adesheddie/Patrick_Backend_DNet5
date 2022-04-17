﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Rpg_project.Migrations
{
    public partial class ManyToManyR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharactersSkill",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersSkill", x => new { x.CharactersId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_CharactersSkill_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharactersSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name", "Points" },
                values: new object[] { 1, "Fireball", 20 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name", "Points" },
                values: new object[] { 2, "Frenzy", 30 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name", "Points" },
                values: new object[] { 3, "Blizzard", 55 });

            migrationBuilder.CreateIndex(
                name: "IX_CharactersSkill_SkillsId",
                table: "CharactersSkill",
                column: "SkillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharactersSkill");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
