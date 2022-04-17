using Microsoft.EntityFrameworkCore.Migrations;

namespace Rpg_project.Migrations
{
    public partial class ModifiedCharactersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Skills",
                table: "Characters",
                newName: "Attack");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Attack",
                table: "Characters",
                newName: "Skills");
        }
    }
}
