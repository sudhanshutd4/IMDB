using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDB.Data
{
    public partial class AddingMovieEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoviesMovieID",
                table: "actors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    MovieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProducerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_movies_producers_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "producers",
                        principalColumn: "ProducerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actors_MoviesMovieID",
                table: "actors",
                column: "MoviesMovieID");

            migrationBuilder.CreateIndex(
                name: "IX_movies_ProducerID",
                table: "movies",
                column: "ProducerID");

            migrationBuilder.AddForeignKey(
                name: "FK_actors_movies_MoviesMovieID",
                table: "actors",
                column: "MoviesMovieID",
                principalTable: "movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_actors_movies_MoviesMovieID",
                table: "actors");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropIndex(
                name: "IX_actors_MoviesMovieID",
                table: "actors");

            migrationBuilder.DropColumn(
                name: "MoviesMovieID",
                table: "actors");
        }
    }
}
