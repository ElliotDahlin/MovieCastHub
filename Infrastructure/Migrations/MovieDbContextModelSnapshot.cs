﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Movie", b =>
                {
                    b.Property<Guid>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Movie");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.UserMovie", b =>
                {
                    b.Property<Guid>("UserMovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("UserRating")
                        .HasColumnType("real");

                    b.HasKey("UserMovieId");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMovie");
                });

            modelBuilder.Entity("Domain.Models.Comedy", b =>
                {
                    b.HasBaseType("Domain.Models.Movie");

                    b.Property<bool>("FamilyFriendly")
                        .HasColumnType("bit");

                    b.Property<string>("HumorStyle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ParodyElements")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Comedy");
                });

            modelBuilder.Entity("Domain.Models.Documentary", b =>
                {
                    b.HasBaseType("Domain.Models.Movie");

                    b.Property<string>("HistoricalContext")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RealLifeContext")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Documentary");
                });

            modelBuilder.Entity("Domain.Models.Horror", b =>
                {
                    b.HasBaseType("Domain.Models.Movie");

                    b.Property<int>("GoreLevel")
                        .HasColumnType("int");

                    b.Property<int>("ScaryLevel")
                        .HasColumnType("int");

                    b.Property<bool>("SupernaturalElements")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Horror");
                });

            modelBuilder.Entity("Domain.Models.UserMovie", b =>
                {
                    b.HasOne("Domain.Models.Movie", "Movie")
                        .WithMany("UserMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("UserMovies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Movie", b =>
                {
                    b.Navigation("UserMovies");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("UserMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
