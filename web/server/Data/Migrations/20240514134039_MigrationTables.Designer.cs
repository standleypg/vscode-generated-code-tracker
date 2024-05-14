﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server.Data;

#nullable disable

namespace server.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240514134039_MigrationTables")]
    partial class MigrationTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MainUserStats", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_ID")
                        .HasColumnOrder(0);

                    b.Property<string>("ProjectId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PROJECT_ID")
                        .HasColumnOrder(1);

                    b.Property<string>("SolutionId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SOLUTION_ID")
                        .HasColumnOrder(2);

                    b.Property<decimal>("NoOfAutoGenLines")
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("NOOF_AUTO_GEN_LINES");

                    b.HasKey("UserId", "ProjectId", "SolutionId");

                    b.HasIndex("ProjectId");

                    b.ToTable("MAIN_USER_STATS", (string)null);
                });

            modelBuilder.Entity("Project", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PROJECT_ID");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PROJECT_NAME");

                    b.HasKey("ProjectId");

                    b.ToTable("PROJECTS_LIST", (string)null);
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PROJECT_ID")
                        .HasColumnOrder(0);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_ID")
                        .HasColumnOrder(1);

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PROJECTS_USERS", (string)null);
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_ID");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PASSWORD_HASH");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PASSWORD_SALT");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("USER_EMAIL");

                    b.Property<byte[]>("UserImage")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("USER_IMAGE");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("USER_NAME");

                    b.HasKey("UserId");

                    b.ToTable("USERS", (string)null);
                });

            modelBuilder.Entity("UserRecord", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_ID")
                        .HasColumnOrder(0);

                    b.Property<string>("SolutionId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SOLUTION_ID")
                        .HasColumnOrder(1);

                    b.Property<int>("SeqNo")
                        .HasColumnType("int")
                        .HasColumnName("SEQ_NO")
                        .HasColumnOrder(2);

                    b.Property<decimal>("NoOfAutoGenLines")
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("NOOF_AUTO_GEN_LINES");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("RECORD_DATE");

                    b.HasKey("UserId", "SolutionId", "SeqNo");

                    b.ToTable("USER_RECORDS", (string)null);
                });

            modelBuilder.Entity("MainUserStats", b =>
                {
                    b.HasOne("Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.HasOne("Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserRecord", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
