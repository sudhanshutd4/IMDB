﻿// <auto-generated />
using System;
using IMDB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IMDB.Data
{
    [DbContext(typeof(MovieDBContext))]
    [Migration("20210924093826_AddingPrimaryKeytoMappingtable")]
    partial class AddingPrimaryKeytoMappingtable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IMDB.Entities.Actors", b =>
                {
                    b.Property<int>("ActorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorID");

                    b.ToTable("actors");
                });

            modelBuilder.Entity("IMDB.Entities.Movies", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfRelease")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProducerID")
                        .HasColumnType("int");

                    b.HasKey("MovieID");

                    b.HasIndex("ProducerID");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("IMDB.Entities.MoviesActorMapping", b =>
                {
                    b.Property<int>("MappingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActorsActorID")
                        .HasColumnType("int");

                    b.Property<int?>("MoviesMovieID")
                        .HasColumnType("int");

                    b.HasKey("MappingId");

                    b.HasIndex("ActorsActorID");

                    b.HasIndex("MoviesMovieID");

                    b.ToTable("movieactorMapping");
                });

            modelBuilder.Entity("IMDB.Entities.Producers", b =>
                {
                    b.Property<int>("ProducerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProducerID");

                    b.ToTable("producers");
                });

            modelBuilder.Entity("IMDB.Entities.Movies", b =>
                {
                    b.HasOne("IMDB.Entities.Producers", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerID");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("IMDB.Entities.MoviesActorMapping", b =>
                {
                    b.HasOne("IMDB.Entities.Actors", "Actors")
                        .WithMany()
                        .HasForeignKey("ActorsActorID");

                    b.HasOne("IMDB.Entities.Movies", "Movies")
                        .WithMany()
                        .HasForeignKey("MoviesMovieID");

                    b.Navigation("Actors");

                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
