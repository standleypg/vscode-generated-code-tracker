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
    [Migration("20240514055559_MigrationTables")]
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

            modelBuilder.Entity("MainUserStat", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<string>("ProjectId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(1);

                    b.Property<string>("SolutionId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(2);

                    b.Property<decimal>("NoOfAutoGenLines")
                        .HasColumnType("numeric(18, 0)");

                    b.HasKey("UserId", "ProjectId", "SolutionId");

                    b.ToTable("MAIN_USER_STATS", (string)null);
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PROJECT_ID");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_ID");

                    b.HasKey("ProjectId", "UserId");

                    b.ToTable("PROJECTS_USERS", (string)null);
                });

            modelBuilder.Entity("ProjectsList", b =>
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

            modelBuilder.Entity("UserRecord", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_ID");

                    b.Property<string>("SolutionId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SOLUTION_ID");

                    b.Property<int>("SeqNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SEQ_NO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeqNo"));

                    b.Property<decimal>("NoOfAutoGenLines")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("NOOF_AUTO_GEN_LINES");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("RECORD_DATE");

                    b.HasKey("UserId", "SolutionId", "SeqNo");

                    b.ToTable("USER_RECORDS", (string)null);
                });

            modelBuilder.Entity("server.Models.SampleTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MyProperty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SampleTables");
                });
#pragma warning restore 612, 618
        }
    }
}