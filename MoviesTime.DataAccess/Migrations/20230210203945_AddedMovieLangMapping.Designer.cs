﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesTime.DataAccess.Database;

#nullable disable

namespace MoviesTime.Contract.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230210203945_AddedMovieLangMapping")]
    partial class AddedMovieLangMapping
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoviesTime.Contract.Models.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreID"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("GenreID");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MoviesTime.Contract.Models.Languages", b =>
                {
                    b.Property<int>("LanguageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("MoviesTime.Contract.Models.MovieLanguageMapping", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LanguageID1")
                        .HasColumnType("int");

                    b.Property<int>("MovieID1")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LanguageID1");

                    b.HasIndex("MovieID1");

                    b.ToTable("MovieLanguageMapping");
                });

            modelBuilder.Entity("MoviesTime.Contract.Models.Movies", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("MovieLength")
                        .HasColumnType("time");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TheaterID")
                        .HasColumnType("int");

                    b.HasKey("MovieID");

                    b.HasIndex("TheaterID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesTime.Contract.Models.TestModel", b =>
                {
                    b.Property<int>("TestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestID");

                    b.ToTable("TestTable");
                });

            modelBuilder.Entity("MoviesTime.Contract.Models.Theater", b =>
                {
                    b.Property<int>("TheaterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TheaterID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ManagerIDUserID")
                        .HasColumnType("int");

                    b.Property<string>("TheaterContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheaterName")
                        .HasColumnType("int");

                    b.HasKey("TheaterID");

                    b.HasIndex("ManagerIDUserID");

                    b.ToTable("Theater");
                });

            modelBuilder.Entity("MoviesTime.Contract.Models.Users", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MoviesTime.Contract.Models.MovieLanguageMapping", b =>
                {
                    b.HasOne("MoviesTime.Contract.Models.Languages", "LanguageID")
                        .WithMany()
                        .HasForeignKey("LanguageID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesTime.Contract.Models.Movies", "MovieID")
                        .WithMany()
                        .HasForeignKey("MovieID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LanguageID");

                    b.Navigation("MovieID");
                });

            modelBuilder.Entity("MoviesTime.Contract.Models.Movies", b =>
                {
                    b.HasOne("MoviesTime.Contract.Models.Theater", "Theater")
                        .WithMany()
                        .HasForeignKey("TheaterID");

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("MoviesTime.Contract.Models.Theater", b =>
                {
                    b.HasOne("MoviesTime.Contract.Models.Users", "ManagerID")
                        .WithMany()
                        .HasForeignKey("ManagerIDUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManagerID");
                });
#pragma warning restore 612, 618
        }
    }
}
