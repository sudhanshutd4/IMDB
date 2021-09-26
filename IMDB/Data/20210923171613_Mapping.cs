using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDB.Data
{
    public partial class Mapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movieactorMapping",
                columns: table => new
                {
                    MoviesMovieID = table.Column<int>(type: "int", nullable: true),
                    ActorsActorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_movieactorMapping_actors_ActorsActorID",
                        column: x => x.ActorsActorID,
                        principalTable: "actors",
                        principalColumn: "ActorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_movieactorMapping_movies_MoviesMovieID",
                        column: x => x.MoviesMovieID,
                        principalTable: "movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movieactorMapping_ActorsActorID",
                table: "movieactorMapping",
                column: "ActorsActorID");

            migrationBuilder.CreateIndex(
                name: "IX_movieactorMapping_MoviesMovieID",
                table: "movieactorMapping",
                column: "MoviesMovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieactorMapping");
        }
    }
}
