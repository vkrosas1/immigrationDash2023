﻿// <auto-generated />
using System;
using ImmigrationHack.Services.src.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImmigrationHack.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.DocumentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PathId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PathId");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.Form", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DocumentTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

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

                    b.Property<Guid?>("UserPathId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("PathId");

                    b.HasIndex("UserPathId");

                    b.ToTable("Paths");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.UserAuth", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("UsersAuth");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.UserDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DocumentTypeId")
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

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDocuments");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.UserInfo", b =>
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

                    b.ToTable("UsersInfo");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.UserPath", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("UserPaths");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.DocumentType", b =>
                {
                    b.HasOne("ImmigrationHack.Services.src.Data.Entities.Path", null)
                        .WithMany("DocumentsRequired")
                        .HasForeignKey("PathId");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.Form", b =>
                {
                    b.HasOne("ImmigrationHack.Services.src.Data.Entities.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.Path", b =>
                {
                    b.HasOne("ImmigrationHack.Services.src.Data.Entities.Form", null)
                        .WithMany("Paths")
                        .HasForeignKey("FormId");

                    b.HasOne("ImmigrationHack.Services.src.Data.Entities.Path", null)
                        .WithMany("MinPathRequired")
                        .HasForeignKey("PathId");

                    b.HasOne("ImmigrationHack.Services.src.Data.Entities.UserPath", null)
                        .WithMany("AvailablePaths")
                        .HasForeignKey("UserPathId");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.UserDocument", b =>
                {
                    b.HasOne("ImmigrationHack.Services.src.Data.Entities.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImmigrationHack.Services.src.Data.Entities.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.UserPath", b =>
                {
                    b.HasOne("ImmigrationHack.Services.src.Data.Entities.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.Form", b =>
                {
                    b.Navigation("Paths");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.Path", b =>
                {
                    b.Navigation("DocumentsRequired");

                    b.Navigation("MinPathRequired");
                });

            modelBuilder.Entity("ImmigrationHack.Services.src.Data.Entities.UserPath", b =>
                {
                    b.Navigation("AvailablePaths");
                });
#pragma warning restore 612, 618
        }
    }
}
