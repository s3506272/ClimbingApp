﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClimbingApp.Migrations
{
    [DbContext(typeof(ClimbAppContext))]
    [Migration("20200819065043_Logbook")]
    partial class Logbook
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClimbingApp.Models.AllStats", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("HangEdge")
                        .HasColumnType("int");

                    b.Property<int>("HangWeight")
                        .HasColumnType("int");

                    b.Property<int>("HighestBoulderingGrade")
                        .HasColumnType("int");

                    b.Property<int>("HighestSportGrade")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PullUps")
                        .HasColumnType("int");

                    b.Property<int>("PushUps")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("UserID1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserID");

                    b.HasIndex("UserID1");

                    b.ToTable("AllStats");
                });

            modelBuilder.Entity("ClimbingApp.Models.Boulder", b =>
                {
                    b.Property<int>("BoulderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BoulderingClimbingGrade")
                        .HasColumnType("int");

                    b.Property<int>("ConsensusGrade")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BoulderID");

                    b.ToTable("Boulders");
                });

            modelBuilder.Entity("ClimbingApp.Models.BoulderAverage", b =>
                {
                    b.Property<int>("BoulderAverageID")
                        .HasColumnType("int");

                    b.Property<int>("HangEdge")
                        .HasColumnType("int");

                    b.Property<int>("HangWeight")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PullUps")
                        .HasColumnType("int");

                    b.Property<int>("PushUps")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("BoulderAverageID");

                    b.ToTable("BoulderAverage");
                });

            modelBuilder.Entity("ClimbingApp.Models.HangEdge", b =>
                {
                    b.Property<int>("HangEdgeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NHangEdge")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("StatID")
                        .HasColumnType("int");

                    b.HasKey("HangEdgeID");

                    b.HasIndex("StatID");

                    b.ToTable("HangEdges");
                });

            modelBuilder.Entity("ClimbingApp.Models.HangWeight", b =>
                {
                    b.Property<int>("HangWeightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NHangWeight")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("StatID")
                        .HasColumnType("int");

                    b.HasKey("HangWeightID");

                    b.HasIndex("StatID");

                    b.ToTable("HangWeights");
                });

            modelBuilder.Entity("ClimbingApp.Models.Log", b =>
                {
                    b.Property<string>("LogID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BoulderID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SportID")
                        .HasColumnType("int");

                    b.Property<int?>("StatID")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LogID");

                    b.HasIndex("BoulderID");

                    b.HasIndex("SportID");

                    b.HasIndex("StatID");

                    b.HasIndex("UserID");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("ClimbingApp.Models.PullUp", b =>
                {
                    b.Property<int>("PullUpID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NPullUp")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("StatID")
                        .HasColumnType("int");

                    b.HasKey("PullUpID");

                    b.HasIndex("StatID");

                    b.ToTable("PullUps");
                });

            modelBuilder.Entity("ClimbingApp.Models.PushUp", b =>
                {
                    b.Property<int>("PushUpID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NPushUp")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("StatID")
                        .HasColumnType("int");

                    b.HasKey("PushUpID");

                    b.HasIndex("StatID");

                    b.ToTable("PushUps");
                });

            modelBuilder.Entity("ClimbingApp.Models.Sport", b =>
                {
                    b.Property<int>("SportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConsensusGrade")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SportClimbingGrade")
                        .HasColumnType("int");

                    b.HasKey("SportID");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("ClimbingApp.Models.SportAverage", b =>
                {
                    b.Property<int>("SportAverageID")
                        .HasColumnType("int");

                    b.Property<int>("HangEdge")
                        .HasColumnType("int");

                    b.Property<int>("HangWeight")
                        .HasColumnType("int");

                    b.Property<int>("PullUps")
                        .HasColumnType("int");

                    b.Property<int>("PushUps")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("SportAverageID");

                    b.ToTable("SportAverage");
                });

            modelBuilder.Entity("ClimbingApp.Models.Stat", b =>
                {
                    b.Property<int>("StatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HangEdge")
                        .HasColumnType("int");

                    b.Property<int>("HangWeight")
                        .HasColumnType("int");

                    b.Property<int>("HighestBoulderingGrade")
                        .HasColumnType("int");

                    b.Property<int>("HighestSportGrade")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PullUp")
                        .HasColumnType("int");

                    b.Property<int>("PushUp")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StatID");

                    b.HasIndex("UserID")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("ClimbingApp.Models.User", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ApeIndex")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClimbingApp.Models.AllStats", b =>
                {
                    b.HasOne("ClimbingApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID1");
                });

            modelBuilder.Entity("ClimbingApp.Models.HangEdge", b =>
                {
                    b.HasOne("ClimbingApp.Models.Stat", "Stat")
                        .WithMany("UserHangEdges")
                        .HasForeignKey("StatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClimbingApp.Models.HangWeight", b =>
                {
                    b.HasOne("ClimbingApp.Models.Stat", "Stat")
                        .WithMany("UserHangWeights")
                        .HasForeignKey("StatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClimbingApp.Models.Log", b =>
                {
                    b.HasOne("ClimbingApp.Models.Boulder", "Boulder")
                        .WithMany("Logs")
                        .HasForeignKey("BoulderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClimbingApp.Models.Sport", "Sport")
                        .WithMany("Logs")
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClimbingApp.Models.Stat", "Stat")
                        .WithMany()
                        .HasForeignKey("StatID");

                    b.HasOne("ClimbingApp.Models.User", "User")
                        .WithMany("Logs")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("ClimbingApp.Models.PullUp", b =>
                {
                    b.HasOne("ClimbingApp.Models.Stat", "Stat")
                        .WithMany("UserPullUPs")
                        .HasForeignKey("StatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClimbingApp.Models.PushUp", b =>
                {
                    b.HasOne("ClimbingApp.Models.Stat", "Stat")
                        .WithMany("UserPushUps")
                        .HasForeignKey("StatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClimbingApp.Models.Stat", b =>
                {
                    b.HasOne("ClimbingApp.Models.User", "User")
                        .WithOne("Stat")
                        .HasForeignKey("ClimbingApp.Models.Stat", "UserID");
                });
#pragma warning restore 612, 618
        }
    }
}