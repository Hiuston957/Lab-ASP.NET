﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("Data.Entities.AlbumEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Data_wydania")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Notowanie")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Zespol")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("albums");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Nazwa = "Nazwa"
                        },
                        new
                        {
                            Id = 6,
                            Nazwa = "Nazwa2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}