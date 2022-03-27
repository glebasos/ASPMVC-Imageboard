﻿// <auto-generated />
using System;
using System.Collections.Generic;
using MVCh.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MVCh.Migrations
{
    [DbContext(typeof(ChanDbContext))]
    [Migration("20220322153104_changedImageType")]
    partial class changedImageType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MVCh.Models.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("MVCh.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("MVCh.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<int>>("Links")
                        .HasColumnType("integer[]");

                    b.Property<int?>("PostImageId")
                        .HasColumnType("integer");

                    b.Property<string>("TextContent")
                        .HasColumnType("text");

                    b.Property<int>("ThreadId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostImageId");

                    b.HasIndex("ThreadId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MVCh.Models.Thread", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Threads");
                });

            modelBuilder.Entity("MVCh.Models.Post", b =>
                {
                    b.HasOne("MVCh.Models.Image", "PostImage")
                        .WithMany()
                        .HasForeignKey("PostImageId");

                    b.HasOne("MVCh.Models.Thread", null)
                        .WithMany("Posts")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostImage");
                });

            modelBuilder.Entity("MVCh.Models.Thread", b =>
                {
                    b.HasOne("MVCh.Models.Board", null)
                        .WithMany("Threads")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCh.Models.Board", b =>
                {
                    b.Navigation("Threads");
                });

            modelBuilder.Entity("MVCh.Models.Thread", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
