﻿// <auto-generated />
using System;
using DEALERSHIPS_APP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DEALERSHIPS_APP.Migrations
{
    [DbContext(typeof(DealershipDbContext))]
    [Migration("20231224094809_final3")]
    partial class final3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATED");

                    b.Property<DateTime>("DateOfArrival")
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_OF_ARRIVAL");

                    b.Property<DateTime?>("DateOfPickup")
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_OF_PICKUP");

                    b.Property<string>("Diagnosis")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("DIAGNOSIS");

                    b.Property<int>("GarageId")
                        .HasColumnType("int")
                        .HasColumnName("GARAGE_ID");

                    b.Property<int>("Mileage")
                        .HasColumnType("int")
                        .HasColumnName("MILEAGE");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int")
                        .HasColumnName("OWNER_ID");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime")
                        .HasColumnName("UPDATED");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int")
                        .HasColumnName("VEHICLE_ID");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("VehicleId");

                    b.HasIndex("GarageId", "OwnerId", "VehicleId", "DateOfArrival")
                        .IsUnique()
                        .HasDatabaseName("UQ_APPOINTMENTS_GARAGEID_OWNERID_VEHICLEID_DATEOFARRIVAL");

                    b.ToTable("APPOINTMENTS", (string)null);
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Dealership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ADDRESS");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATED");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAME");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PHONE");

                    b.HasKey("Id");

                    b.ToTable("DEALERSHIPS", (string)null);
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Factory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATED");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LOCATION");

                    b.HasKey("Id");

                    b.ToTable("FACTORIES", (string)null);
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Garage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ADDRESS");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATED");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAME");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PHONE");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Phone" }, "UQ_GARAGES_PHONE")
                        .IsUnique();

                    b.ToTable("GARAGES", (string)null);
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int")
                        .HasColumnName("APPOINTMENT_ID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATED");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("DESCRIPTION");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AppointmentId" }, "IX_ISSUES_APPOINTMENT_ID");

                    b.ToTable("ISSUES", (string)null);
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Logincredential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATED");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PHONE");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("USER_TYPE");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Phone" }, "UQ_LOGINCREDENTIALS_PHONE")
                        .IsUnique();

                    b.ToTable("LOGINCREDENTIALS", (string)null);
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATED");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FIRSTNAME");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LASTNAME");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PHONE");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Phone" }, "UQ_OWNERS_PHONE")
                        .IsUnique();

                    b.ToTable("OWNERS", (string)null);
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Ownership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATED");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int")
                        .HasColumnName("OWNER_ID");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime")
                        .HasColumnName("UPDATED");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int")
                        .HasColumnName("VEHICLE_ID");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId")
                        .IsUnique();

                    b.HasIndex("OwnerId", "VehicleId")
                        .IsUnique()
                        .HasDatabaseName("IX_OWNERSHIPS_OWNERID_VEHICLEID")
                        .HasFilter("[OWNER_ID] IS NOT NULL");

                    b.ToTable("OWNERSHIPS", (string)null);
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.OwnershipHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATED");

                    b.Property<int?>("CurrentOwnerId")
                        .HasColumnType("int")
                        .HasColumnName("CURRENT_OWNER_ID");

                    b.Property<DateTime>("DateOfManufacture")
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_OF_MANUFACTURE");

                    b.Property<DateTime?>("DateOfSale")
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_OF_SALE");

                    b.Property<DateTime?>("DateOfTransfer")
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_OF_TRANSFER");

                    b.Property<int?>("DealershipId")
                        .HasColumnType("int")
                        .HasColumnName("DEALERSHIP_ID");

                    b.Property<int>("FactoryId")
                        .HasColumnType("int")
                        .HasColumnName("FACTORY_ID");

                    b.Property<int?>("PreviousOwnerId")
                        .HasColumnType("int")
                        .HasColumnName("PREVIOUS_OWNER_ID");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int")
                        .HasColumnName("VEHICLE_ID");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CurrentOwnerId" }, "IX_OWNERSHIP_HISTORIES_CURRENT_OWNER_ID");

                    b.HasIndex(new[] { "DealershipId" }, "IX_OWNERSHIP_HISTORIES_DEALERSHIP_ID");

                    b.HasIndex(new[] { "FactoryId" }, "IX_OWNERSHIP_HISTORIES_FACTORY_ID");

                    b.HasIndex(new[] { "PreviousOwnerId" }, "IX_OWNERSHIP_HISTORIES_PREVIOUS_OWNER_ID");

                    b.HasIndex(new[] { "VehicleId" }, "IX_OWNERSHIP_HISTORIES_VEHICLE_ID");

                    b.ToTable("OWNERSHIP_HISTORIES", (string)null);
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Crashed")
                        .HasColumnType("bit")
                        .HasColumnName("CRASHED");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATED");

                    b.Property<DateTime>("DateOfManufacture")
                        .HasColumnType("datetime")
                        .HasColumnName("DATE_OF_MANUFACTURE");

                    b.Property<int>("Mileage")
                        .HasColumnType("int")
                        .HasColumnName("MILEAGE");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MODEL");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime")
                        .HasColumnName("UPDATED");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("VIN");

                    b.HasKey("Id");

                    b.ToTable("VEHICLES", (string)null);
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Appointment", b =>
                {
                    b.HasOne("DEALERSHIPS_APP.Models.Garage", "Garage")
                        .WithMany("Appointments")
                        .HasForeignKey("GarageId")
                        .IsRequired()
                        .HasConstraintName("FK_APPOINTMENTS_GARAGES");

                    b.HasOne("DEALERSHIPS_APP.Models.Owner", "Owner")
                        .WithMany("Appointments")
                        .HasForeignKey("OwnerId")
                        .IsRequired()
                        .HasConstraintName("FK_APPOINTMENTS_OWNERS");

                    b.HasOne("DEALERSHIPS_APP.Models.Vehicle", "Vehicle")
                        .WithMany("Appointments")
                        .HasForeignKey("VehicleId")
                        .IsRequired()
                        .HasConstraintName("FK_APPOINTMENTS_VEHICLES");

                    b.Navigation("Garage");

                    b.Navigation("Owner");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Issue", b =>
                {
                    b.HasOne("DEALERSHIPS_APP.Models.Appointment", "Appointment")
                        .WithMany("Issues")
                        .HasForeignKey("AppointmentId")
                        .IsRequired()
                        .HasConstraintName("FK_ISSUES_APPOINTMENTS");

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Ownership", b =>
                {
                    b.HasOne("DEALERSHIPS_APP.Models.Owner", "Owner")
                        .WithMany("Ownerships")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("FK_OWNERSHIPS_OWNERS");

                    b.HasOne("DEALERSHIPS_APP.Models.Vehicle", "Vehicle")
                        .WithOne("Ownership")
                        .HasForeignKey("DEALERSHIPS_APP.Models.Ownership", "VehicleId")
                        .HasConstraintName("FK_VEHICLES_OWNERSHIPS");

                    b.Navigation("Owner");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.OwnershipHistory", b =>
                {
                    b.HasOne("DEALERSHIPS_APP.Models.Owner", "CurrentOwner")
                        .WithMany("OwnershipHistoryCurrentOwners")
                        .HasForeignKey("CurrentOwnerId")
                        .HasConstraintName("FK_OWNERSHIP_HISTORIES_CURRENT_OWNERS");

                    b.HasOne("DEALERSHIPS_APP.Models.Dealership", "Dealership")
                        .WithMany("OwnershipHistories")
                        .HasForeignKey("DealershipId")
                        .HasConstraintName("FK_OWNERSHIP_HISTORIES_DEALERSHIPS");

                    b.HasOne("DEALERSHIPS_APP.Models.Factory", "Factory")
                        .WithMany("OwnershipHistories")
                        .HasForeignKey("FactoryId")
                        .IsRequired()
                        .HasConstraintName("FK_OWNERSHIP_HISTORIES_FACTORIES");

                    b.HasOne("DEALERSHIPS_APP.Models.Owner", "PreviousOwner")
                        .WithMany("OwnershipHistoryPreviousOwners")
                        .HasForeignKey("PreviousOwnerId")
                        .HasConstraintName("FK_OWNERSHIP_HISTORIES_PREVIOUS_OWNERS");

                    b.HasOne("DEALERSHIPS_APP.Models.Vehicle", "Vehicle")
                        .WithMany("OwnershipHistories")
                        .HasForeignKey("VehicleId")
                        .IsRequired()
                        .HasConstraintName("FK_OWNERSHIP_HISTORIES_VEHICLES");

                    b.Navigation("CurrentOwner");

                    b.Navigation("Dealership");

                    b.Navigation("Factory");

                    b.Navigation("PreviousOwner");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Appointment", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Dealership", b =>
                {
                    b.Navigation("OwnershipHistories");
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Factory", b =>
                {
                    b.Navigation("OwnershipHistories");
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Garage", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Owner", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("OwnershipHistoryCurrentOwners");

                    b.Navigation("OwnershipHistoryPreviousOwners");

                    b.Navigation("Ownerships");
                });

            modelBuilder.Entity("DEALERSHIPS_APP.Models.Vehicle", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Ownership");

                    b.Navigation("OwnershipHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
