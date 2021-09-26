using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDB.Data
{
    public partial class RemoveActorsfromMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_actors_movies_MoviesMovieID",
                table: "actors");

            migrationBuilder.DropIndex(
                name: "IX_actors_MoviesMovieID",
                table: "actors");

            migrationBuilder.DropColumn(
                name: "MoviesMovieID",
                table: "actors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoviesMovieID",
                table: "actors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_actors_MoviesMovieID",
                table: "actors",
                column: "MoviesMovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_actors_movies_MoviesMovieID",
                table: "actors",
                column: "MoviesMovieID",
                principalTable: "movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
