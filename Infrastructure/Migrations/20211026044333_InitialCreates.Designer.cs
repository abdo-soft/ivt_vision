﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataC))]
    [Migration("20211026044333_InitialCreates")]
    partial class InitialCreates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Core.Entities.CServices", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Sname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SubServicesid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("SubServicesid");

                    b.ToTable("CServices");
                });

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Cname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            id = new Guid("d7a30043-8f04-4cb2-919d-b90fa29e9391"),
                            Cname = "Technology",
                            Description = "desc Technology",
                            ImageUrl = "avatar.jpg"
                        });
                });

            modelBuilder.Entity("Core.Entities.Partners", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("PEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PPhone")
                        .HasColumnType("int");

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("Core.Entities.SubServices", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SubDuration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubPrice")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("SubServices");
                });

            modelBuilder.Entity("Core.Entities.CServices", b =>
                {
                    b.HasOne("Core.Entities.SubServices", "SubServices")
                        .WithMany()
                        .HasForeignKey("SubServicesid");

                    b.Navigation("SubServices");
                });
#pragma warning restore 612, 618
        }
    }
}