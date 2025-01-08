﻿// <auto-generated />
using HotelAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelAPI.Migrations
{
    [DbContext(typeof(HotelDb))]
    partial class HotelDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("HotelAPI.Models.Client", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("HotelAPI.Models.Room", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("clientId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("price")
                        .HasColumnType("TEXT");

                    b.Property<int>("type")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("clientId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelAPI.Models.Room", b =>
                {
                    b.HasOne("HotelAPI.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("clientId");

                    b.Navigation("client");
                });
#pragma warning restore 612, 618
        }
    }
}