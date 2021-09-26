using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDB.Data
{
    public partial class AddingPrimaryKeytoMappingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MappingId",
                table: "movieactorMapping",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movieactorMapping",
                table: "movieactorMapping",
                column: "MappingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_movieactorMapping",
                table: "movieactorMapping");

            migrationBuilder.DropColumn(
                name: "MappingId",
                table: "movieactorMapping");
        }
    }
}
