﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelfServiceCheckoutApi.Models;

#nullable disable

namespace SelfServiceCheckoutApi.Migrations
{
    [DbContext(typeof(StockDbContext))]
    partial class StockDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("SelfServiceCheckoutApi.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HUF10")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HUF100")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HUF1000")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HUF10000")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HUF20")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HUF200")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HUF2000")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HUF20000")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HUF5")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HUF50")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HUF500")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HUF5000")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });
#pragma warning restore 612, 618
        }
    }
}