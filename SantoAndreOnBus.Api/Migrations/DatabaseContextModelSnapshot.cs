﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SantoAndreOnBus.Api.Infrastructure;

#nullable disable

namespace SantoAndreOnBus.Api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.16");

            modelBuilder.Entity("SantoAndreOnBus.Api.Companies.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Companies.Prefix", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Identification")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Prefixes");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Lines.InterestPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LineId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LineId");

                    b.ToTable("InterestPoints");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Lines.Line", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Departures")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Fromwards")
                        .HasColumnType("TEXT");

                    b.Property<string>("Letter")
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.Property<int>("PeakHeadway")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PrefixId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Towards")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PrefixId");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Lines.LineVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LineId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LineId");

                    b.HasIndex("VehicleId");

                    b.ToTable("LineVehicles");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Lines.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LineId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LineId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Vehicles.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Companies.Prefix", b =>
                {
                    b.HasOne("SantoAndreOnBus.Api.Companies.Company", "Company")
                        .WithMany("Prefixes")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Lines.InterestPoint", b =>
                {
                    b.HasOne("SantoAndreOnBus.Api.Lines.Line", "Line")
                        .WithMany("InterestPoints")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Line");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Lines.Line", b =>
                {
                    b.HasOne("SantoAndreOnBus.Api.Companies.Company", "Company")
                        .WithMany("Lines")
                        .HasForeignKey("CompanyId");

                    b.HasOne("SantoAndreOnBus.Api.Companies.Prefix", null)
                        .WithMany("Lines")
                        .HasForeignKey("PrefixId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Lines.LineVehicle", b =>
                {
                    b.HasOne("SantoAndreOnBus.Api.Lines.Line", "Line")
                        .WithMany("LineVehicles")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SantoAndreOnBus.Api.Vehicles.Vehicle", "Vehicle")
                        .WithMany("LineVehicles")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Line");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Lines.Place", b =>
                {
                    b.HasOne("SantoAndreOnBus.Api.Lines.Line", "Line")
                        .WithMany("Places")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Line");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Companies.Company", b =>
                {
                    b.Navigation("Lines");

                    b.Navigation("Prefixes");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Companies.Prefix", b =>
                {
                    b.Navigation("Lines");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Lines.Line", b =>
                {
                    b.Navigation("InterestPoints");

                    b.Navigation("LineVehicles");

                    b.Navigation("Places");
                });

            modelBuilder.Entity("SantoAndreOnBus.Api.Vehicles.Vehicle", b =>
                {
                    b.Navigation("LineVehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
