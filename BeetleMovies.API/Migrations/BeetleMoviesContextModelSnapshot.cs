﻿// <auto-generated />
using BeetleMovies.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeetleMovies.API.Migrations
{
    [DbContext(typeof(BeetleMoviesContext))]
    partial class BeetleMoviesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("BeetleMovies.API.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Brian De Palma"
                        },
                        new
                        {
                            Id = 2,
                            Name = "John Lasseter"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Adrian Molina"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Lee Unkrich"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Brad Bird"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Peter Ramsey"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Bob Persichetti"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Rodney Rothman"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Makoto Shinkai"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Chris Sanders"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Dean DeBlois"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Angus MacLane"
                        },
                        new
                        {
                            Id = 13,
                            Name = "David Fincher"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Anthony Russo"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Joe Russo"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Antoine Fuqua"
                        });
                });

            modelBuilder.Entity("BeetleMovies.API.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Rating")
                        .HasColumnType("REAL");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Rating = 7.0999999999999996,
                            Title = "Mission Impossible",
                            Year = 1996
                        },
                        new
                        {
                            Id = 2,
                            Rating = 8.3000000000000007,
                            Title = "Toy Story",
                            Year = 1995
                        },
                        new
                        {
                            Id = 3,
                            Rating = 8.4000000000000004,
                            Title = "Coco",
                            Year = 2017
                        },
                        new
                        {
                            Id = 4,
                            Rating = 8.0999999999999996,
                            Title = "The Iron Giant",
                            Year = 1999
                        },
                        new
                        {
                            Id = 5,
                            Rating = 8.4000000000000004,
                            Title = "Spider-Man - Into the spider-verse",
                            Year = 2018
                        },
                        new
                        {
                            Id = 6,
                            Rating = 8.4000000000000004,
                            Title = "Your Name",
                            Year = 2016
                        },
                        new
                        {
                            Id = 7,
                            Rating = 8.0999999999999996,
                            Title = "How to Train Your Dragon",
                            Year = 2010
                        },
                        new
                        {
                            Id = 8,
                            Rating = 5.7000000000000002,
                            Title = "Lightyear",
                            Year = 2022
                        },
                        new
                        {
                            Id = 9,
                            Rating = 7.7999999999999998,
                            Title = "The Girl with the Dragon Tattoo",
                            Year = 2011
                        },
                        new
                        {
                            Id = 10,
                            Rating = 8.4000000000000004,
                            Title = "Avengers: Endgame",
                            Year = 2019
                        },
                        new
                        {
                            Id = 11,
                            Rating = 7.2000000000000002,
                            Title = "The Equalizer",
                            Year = 2014
                        });
                });

            modelBuilder.Entity("DirectorMovie", b =>
                {
                    b.Property<int>("DirectorsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoviesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DirectorsId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("DirectorMovie");

                    b.HasData(
                        new
                        {
                            DirectorsId = 1,
                            MoviesId = 1
                        },
                        new
                        {
                            DirectorsId = 2,
                            MoviesId = 2
                        },
                        new
                        {
                            DirectorsId = 3,
                            MoviesId = 3
                        },
                        new
                        {
                            DirectorsId = 4,
                            MoviesId = 3
                        },
                        new
                        {
                            DirectorsId = 5,
                            MoviesId = 4
                        },
                        new
                        {
                            DirectorsId = 6,
                            MoviesId = 5
                        },
                        new
                        {
                            DirectorsId = 7,
                            MoviesId = 5
                        },
                        new
                        {
                            DirectorsId = 8,
                            MoviesId = 5
                        },
                        new
                        {
                            DirectorsId = 9,
                            MoviesId = 6
                        },
                        new
                        {
                            DirectorsId = 10,
                            MoviesId = 7
                        },
                        new
                        {
                            DirectorsId = 11,
                            MoviesId = 7
                        },
                        new
                        {
                            DirectorsId = 12,
                            MoviesId = 8
                        },
                        new
                        {
                            DirectorsId = 13,
                            MoviesId = 9
                        },
                        new
                        {
                            DirectorsId = 14,
                            MoviesId = 10
                        },
                        new
                        {
                            DirectorsId = 15,
                            MoviesId = 10
                        },
                        new
                        {
                            DirectorsId = 16,
                            MoviesId = 11
                        });
                });

            modelBuilder.Entity("DirectorMovie", b =>
                {
                    b.HasOne("BeetleMovies.API.Director", null)
                        .WithMany()
                        .HasForeignKey("DirectorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeetleMovies.API.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
