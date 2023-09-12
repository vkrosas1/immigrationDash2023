﻿// <auto-generated />
using System;
using ImmigrationHack.Services.src.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImmigrationHack.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230912062854_InitialCreate_2")]
    partial class InitialCreate_2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsOptional")
                        .HasColumnType("bit");

                    b.Property<string>("IssueCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PathId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PathId");

                    b.HasIndex("UserId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.Form", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.Path", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PathId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("PathId");

                    b.ToTable("Paths");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CitizenCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.Document", b =>
                {
                    b.HasOne("ImmigrationHack.Services.src.Data.Entities.Path", null)
                        .WithMany("DocumentsRequired")
                        .HasForeignKey("PathId");

                    b.HasOne("ImmigrationHack.Services.src.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.Path", b =>
                {
                    b.HasOne("ImmigrationHack.Services.src.Data.Entities.Form", null)
                        .WithMany("PathRequired")
                        .HasForeignKey("FormId");

                    b.HasOne("ImmigrationHack.Services.src.Data.Entities.Path", null)
                        .WithMany("MinPathRequired")
                        .HasForeignKey("PathId");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.Form", b =>
                {
                    b.Navigation("PathRequired");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.Path", b =>
                {
                    b.Navigation("DocumentsRequired");

                    b.Navigation("MinPathRequired");
                });
#pragma warning restore 612, 618
        }
    }
}
