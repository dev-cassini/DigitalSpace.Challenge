﻿// <auto-generated />
using System;
using DigitalSpace.Challenge.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DigitalSpace.Challenge.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ChallengeDbContext))]
    partial class ChallengeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DigitalSpace.Challenge.Domain.Entities.Forecourt", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Forecourts", (string)null);
                });

            modelBuilder.Entity("DigitalSpace.Challenge.Domain.Entities.Lane", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ForecourtId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ForecourtId");

                    b.ToTable("Lanes", (string)null);
                });

            modelBuilder.Entity("DigitalSpace.Challenge.Domain.Entities.Pump", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LaneId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LaneId");

                    b.ToTable("Pumps", (string)null);
                });

            modelBuilder.Entity("DigitalSpace.Challenge.Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DateTimeCompleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateTimeCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DateTimeFilling")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ForecourtId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PumpId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ForecourtId");

                    b.HasIndex("PumpId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("DigitalSpace.Challenge.Domain.Entities.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("FuelLevel")
                        .HasColumnType("integer");

                    b.Property<int>("FuelType")
                        .HasColumnType("integer");

                    b.Property<int>("TankCapacity")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Vehicles", (string)null);

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DigitalSpace.Challenge.Domain.Entities.Vehicles.Car", b =>
                {
                    b.HasBaseType("DigitalSpace.Challenge.Domain.Entities.Vehicles.Vehicle");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("DigitalSpace.Challenge.Domain.Entities.Vehicles.Hgv", b =>
                {
                    b.HasBaseType("DigitalSpace.Challenge.Domain.Entities.Vehicles.Vehicle");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("DigitalSpace.Challenge.Domain.Entities.Vehicles.Van", b =>
                {
                    b.HasBaseType("DigitalSpace.Challenge.Domain.Entities.Vehicles.Vehicle");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("DigitalSpace.Challenge.Domain.Entities.Lane", b =>
                {
                    b.HasOne("DigitalSpace.Challenge.Domain.Entities.Forecourt", "Forecourt")
                        .WithMany("Lanes")
                        .HasForeignKey("ForecourtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Forecourt");
                });

            modelBuilder.Entity("DigitalSpace.Challenge.Domain.Entities.Pump", b =>
                {
                    b.HasOne("DigitalSpace.Challenge.Domain.Entities.Lane", "Lane")
                        .WithMany("Pumps")
                        .HasForeignKey("LaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lane");
                });

            modelBuilder.Entity("DigitalSpace.Challenge.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("DigitalSpace.Challenge.Domain.Entities.Forecourt", null)
                        .WithMany("Transactions")
                        .HasForeignKey("ForecourtId");

                    b.HasOne("DigitalSpace.Challenge.Domain.Entities.Pump", null)
                        .WithMany()
                        .HasForeignKey("PumpId");

                    b.HasOne("DigitalSpace.Challenge.Domain.Entities.Vehicles.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DigitalSpace.Challenge.Domain.Entities.Forecourt", b =>
                {
                    b.Navigation("Lanes");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("DigitalSpace.Challenge.Domain.Entities.Lane", b =>
                {
                    b.Navigation("Pumps");
                });
#pragma warning restore 612, 618
        }
    }
}
