﻿// <auto-generated />
using System;
using GolfApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GolfApp.Migrations
{
    [DbContext(typeof(CourseContext))]
    partial class CourseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GolfApp.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateFounded")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Par")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("LocationId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("GolfApp.Models.Golfer", b =>
                {
                    b.Property<int>("GolferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("GolferId");

                    b.ToTable("Golfer");
                });

            modelBuilder.Entity("GolfApp.Models.Hole", b =>
                {
                    b.Property<int>("HoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Num")
                        .HasColumnType("int");

                    b.Property<int>("Par")
                        .HasColumnType("int");

                    b.Property<int?>("RoundId")
                        .HasColumnType("int");

                    b.HasKey("HoleId");

                    b.HasIndex("CourseId");

                    b.HasIndex("RoundId");

                    b.ToTable("Hole");
                });

            modelBuilder.Entity("GolfApp.Models.HoleScore", b =>
                {
                    b.Property<int>("HoleScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HoleId")
                        .HasColumnType("int");

                    b.Property<int?>("RoundId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("HoleScoreId");

                    b.HasIndex("HoleId");

                    b.HasIndex("RoundId");

                    b.ToTable("HoleScore");
                });

            modelBuilder.Entity("GolfApp.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("GolfApp.Models.Round", b =>
                {
                    b.Property<int>("RoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePlayed")
                        .HasColumnType("datetime2");

                    b.Property<int>("GolferId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("RoundId");

                    b.HasIndex("CourseId");

                    b.HasIndex("GolferId");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("GolfApp.Models.Course", b =>
                {
                    b.HasOne("GolfApp.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("GolfApp.Models.Hole", b =>
                {
                    b.HasOne("GolfApp.Models.Course", "Course")
                        .WithMany("Holes")
                        .HasForeignKey("CourseId");

                    b.HasOne("GolfApp.Models.Round", null)
                        .WithMany("HolesPlayed")
                        .HasForeignKey("RoundId");
                });

            modelBuilder.Entity("GolfApp.Models.HoleScore", b =>
                {
                    b.HasOne("GolfApp.Models.Hole", "Hole")
                        .WithMany()
                        .HasForeignKey("HoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GolfApp.Models.Round", null)
                        .WithMany("ScoresOfHoles")
                        .HasForeignKey("RoundId");
                });

            modelBuilder.Entity("GolfApp.Models.Round", b =>
                {
                    b.HasOne("GolfApp.Models.Course", "CoursePlayed")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GolfApp.Models.Golfer", "Golfer")
                        .WithMany("RoundsPlayed")
                        .HasForeignKey("GolferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
