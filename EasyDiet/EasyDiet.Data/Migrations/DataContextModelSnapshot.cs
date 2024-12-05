﻿// <auto-generated />
using System;
using EasyDiet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyDiet.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EasyDiet.Core.Models.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("EasyDiet.Core.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CoachId")
                        .HasColumnType("int");

                    b.Property<int>("MyDiet")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EasyDiet.Core.Models.Diet", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"), 1L, 1);

                    b.Property<int>("Coach")
                        .HasColumnType("int");

                    b.Property<int?>("CoachId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Code");

                    b.HasIndex("CoachId");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("EasyDiet.Core.Models.Weight", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("CurrentWeight")
                        .HasColumnType("float");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Date");

                    b.HasIndex("CustomerId");

                    b.ToTable("Weight");
                });

            modelBuilder.Entity("EasyDiet.Core.Models.Customer", b =>
                {
                    b.HasOne("EasyDiet.Core.Models.Coach", null)
                        .WithMany("MyCustomers")
                        .HasForeignKey("CoachId");
                });

            modelBuilder.Entity("EasyDiet.Core.Models.Diet", b =>
                {
                    b.HasOne("EasyDiet.Core.Models.Coach", null)
                        .WithMany("MyDiets")
                        .HasForeignKey("CoachId");
                });

            modelBuilder.Entity("EasyDiet.Core.Models.Weight", b =>
                {
                    b.HasOne("EasyDiet.Core.Models.Customer", null)
                        .WithMany("MyWeigths")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("EasyDiet.Core.Models.Coach", b =>
                {
                    b.Navigation("MyCustomers");

                    b.Navigation("MyDiets");
                });

            modelBuilder.Entity("EasyDiet.Core.Models.Customer", b =>
                {
                    b.Navigation("MyWeigths");
                });
#pragma warning restore 612, 618
        }
    }
}
