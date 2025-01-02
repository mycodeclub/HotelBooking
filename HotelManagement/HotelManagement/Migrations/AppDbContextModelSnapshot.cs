﻿// <auto-generated />
using System;
using HotelBookingApp.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelManagement.Models.Booking", b =>
                {
                    b.Property<int>("UniqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UniqueId"));

                    b.Property<DateTime>("ActualCheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ActualCheckOut")
                        .HasColumnType("datetime2");

                    b.Property<int>("BalanceAmt")
                        .HasColumnType("int");

                    b.Property<int>("BookingAmt")
                        .HasColumnType("int");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpectedCheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpectedCheckOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoomId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UniqueId");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HotelManagement.Models.GorvnIdType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IdType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GorvnIdTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdType = "Pan"
                        },
                        new
                        {
                            Id = 2,
                            IdType = "Aadhar"
                        },
                        new
                        {
                            Id = 3,
                            IdType = "Voter"
                        },
                        new
                        {
                            Id = 4,
                            IdType = "Other"
                        });
                });

            modelBuilder.Entity("HotelManagement.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BookingUniqueId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GovIdFilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GovnId")
                        .HasColumnType("int");

                    b.Property<string>("GovnIdNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingUniqueId");

                    b.HasIndex("GovnId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("HotelManagement.Models.Room", b =>
                {
                    b.Property<string>("RoomNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Rent")
                        .HasColumnType("int");

                    b.HasKey("RoomNumber");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomNumber = "101",
                            Rent = 1800
                        },
                        new
                        {
                            RoomNumber = "102",
                            Rent = 1800
                        },
                        new
                        {
                            RoomNumber = "103",
                            Rent = 1800
                        },
                        new
                        {
                            RoomNumber = "104",
                            Rent = 1800
                        },
                        new
                        {
                            RoomNumber = "105",
                            Rent = 1800
                        },
                        new
                        {
                            RoomNumber = "106",
                            Rent = 1800
                        },
                        new
                        {
                            RoomNumber = "107",
                            Rent = 1800
                        },
                        new
                        {
                            RoomNumber = "108",
                            Rent = 1800
                        },
                        new
                        {
                            RoomNumber = "109",
                            Rent = 1800
                        },
                        new
                        {
                            RoomNumber = "110",
                            Rent = 1800
                        },
                        new
                        {
                            RoomNumber = "H1",
                            Rent = 22000
                        },
                        new
                        {
                            RoomNumber = "H2",
                            Rent = 22000
                        });
                });

            modelBuilder.Entity("HotelManagement.Models.Booking", b =>
                {
                    b.HasOne("HotelManagement.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelManagement.Models.Guest", b =>
                {
                    b.HasOne("HotelManagement.Models.Booking", null)
                        .WithMany("Guests")
                        .HasForeignKey("BookingUniqueId");

                    b.HasOne("HotelManagement.Models.GorvnIdType", "GorvnIdType")
                        .WithMany()
                        .HasForeignKey("GovnId");

                    b.Navigation("GorvnIdType");
                });

            modelBuilder.Entity("HotelManagement.Models.Booking", b =>
                {
                    b.Navigation("Guests");
                });
#pragma warning restore 612, 618
        }
    }
}
