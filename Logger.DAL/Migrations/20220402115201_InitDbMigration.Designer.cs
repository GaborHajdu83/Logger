﻿// <auto-generated />
using System;
using Logger.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Logger.DAL.Migrations
{
    [DbContext(typeof(LoggerDbContext))]
    [Migration("20220402115201_InitDbMigration")]
    partial class InitDbMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Logger.Entities.Log.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LogLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LogLevel");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Message");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("smalldatetime")
                        .HasColumnName("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("Logs", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
