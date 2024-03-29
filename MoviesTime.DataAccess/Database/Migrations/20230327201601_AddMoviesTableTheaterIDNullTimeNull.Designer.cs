﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesTime.DataAccess.Database;

#nullable disable

namespace MoviesTime.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230327201601_AddMoviesTableTheaterIDNullTimeNull")]
    partial class AddMoviesTableTheaterIDNullTimeNull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoviesTime.Contract.Models.Genres", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Genres");
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

            modelBuilder.Entity("MoviesTime.Contract.Models.Movies", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<TimeSpan?>("MovieLength")
                        .HasColumnType("time");

                    b.Property<string>("MovieTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TheaterID")
                        .HasColumnType("int");

                    b.HasKey("MovieID");

                    b.HasIndex("TheaterID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesTime.Contract.Models.TheaterScreen", b =>
                {
                    b.Property<int>("ScreenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScreenID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("ScreenDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScreenName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheaterID")
                        .HasColumnType("int");

                    b.HasKey("ScreenID");

                    b.HasIndex("TheaterID");

                    b.ToTable("TheaterScreens");
                });

            modelBuilder.Entity("MoviesTime.Contract.Models.Theaters", b =>
                {
                    b.Property<int>("TheaterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TheaterID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ManagerID")
                        .HasColumnType("int");

                    b.Property<string>("TheaterContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TheaterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TheaterID");

                    b.HasIndex("ManagerID");

                    b.ToTable("Theaters");
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

            modelBuilder.Entity("MoviesTime.Contract.Models.Movies", b =>
                {
                    b.HasOne("MoviesTime.Contract.Models.Theaters", "Theaters")
                        .WithMany()
                        .HasForeignKey("TheaterID");

                    b.Navigation("Theaters");
                });

            modelBuilder.Entity("MoviesTime.Contract.Models.TheaterScreen", b =>
                {
                    b.HasOne("MoviesTime.Contract.Models.Theaters", "Theaters")
                        .WithMany()
                        .HasForeignKey("TheaterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theaters");
                });

            modelBuilder.Entity("MoviesTime.Contract.Models.Theaters", b =>
                {
                    b.HasOne("MoviesTime.Contract.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("ManagerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
