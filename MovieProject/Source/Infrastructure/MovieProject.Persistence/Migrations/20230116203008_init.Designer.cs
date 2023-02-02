﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieProject.Persistence.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MovieProject.Persistence.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20230116203008_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Movie")
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ActorFilm", b =>
                {
                    b.Property<Guid>("ActorsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FilmsId")
                        .HasColumnType("uuid");

                    b.HasKey("ActorsId", "FilmsId");

                    b.HasIndex("FilmsId");

                    b.ToTable("ActorFilm", "Movie");
                });

            modelBuilder.Entity("MovieProject.Domain.Entity.Actor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NameSurname")
                        .HasColumnType("text");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Actor", "Movie");
                });

            modelBuilder.Entity("MovieProject.Domain.Entity.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CommenterName")
                        .HasColumnType("text");

                    b.Property<string>("Contents")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FilmId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Comment", "Movie");
                });

            modelBuilder.Entity("MovieProject.Domain.Entity.Film", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Director")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("text");

                    b.Property<string>("Year")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Film", "Movie");
                });

            modelBuilder.Entity("ActorFilm", b =>
                {
                    b.HasOne("MovieProject.Domain.Entity.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieProject.Domain.Entity.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieProject.Domain.Entity.Comment", b =>
                {
                    b.HasOne("MovieProject.Domain.Entity.Film", "Film")
                        .WithMany("Comments")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");
                });

            modelBuilder.Entity("MovieProject.Domain.Entity.Film", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}