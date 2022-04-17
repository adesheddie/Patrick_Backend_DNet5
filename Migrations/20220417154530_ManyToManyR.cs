using Microsoft.EntityFrameworkCore.Migrations;

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
                    Points = table.Column<int>(type: "int", nullable: false),
                    CharactersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CharactersId", "Name", "Points" },
                values: new object[] { 1, null, "Fireball", 20 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CharactersId", "Name", "Points" },
                values: new object[] { 2, null, "Frenzy", 30 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CharactersId", "Name", "Points" },
                values: new object[] { 3, null, "Blizzard", 55 });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CharactersId",
                table: "Skills",
                column: "CharactersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
