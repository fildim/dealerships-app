using Microsoft.EntityFrameworkCore;

namespace DEALERSHIPS_APP.Models;

public partial class DealershipDbContext : DbContext
{


	public DealershipDbContext(DbContextOptions<DealershipDbContext> options)
		: base(options)
	{



	}

	public virtual DbSet<Appointment> Appointments { get; set; }

	public virtual DbSet<Dealership> Dealerships { get; set; }

	public virtual DbSet<Factory> Factories { get; set; }

	public virtual DbSet<Garage> Garages { get; set; }

	public virtual DbSet<Issue> Issues { get; set; }

	public virtual DbSet<Owner> Owners { get; set; }

	public virtual DbSet<Ownership> Ownerships { get; set; }

	public virtual DbSet<OwnershipHistory> OwnershipHistories { get; set; }

	public virtual DbSet<Vehicle> Vehicles { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Appointment>(entity =>
		{
			entity.ToTable("APPOINTMENTS");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.Created)
				.HasColumnType("datetime")
				.HasColumnName("CREATED");
			entity.Property(e => e.DateOfArrival)
				.HasColumnType("datetime")
				.HasColumnName("DATE_OF_ARRIVAL");
			entity.Property(e => e.DateOfPickup)
				.HasColumnType("datetime")
				.HasColumnName("DATE_OF_PICKUP");
			entity.Property(e => e.Diagnosis)
				.HasMaxLength(500)
				.HasColumnName("DIAGNOSIS");
			entity.Property(e => e.GarageId).HasColumnName("GARAGE_ID");
			entity.Property(e => e.Mileage).HasColumnName("MILEAGE");
			entity.Property(e => e.OwnerId).HasColumnName("OWNER_ID");
			entity.Property(e => e.Updated)
				.HasColumnType("datetime")
				.HasColumnName("UPDATED");
			entity.Property(e => e.VehicleId).HasColumnName("VEHICLE_ID");

			entity.HasOne(d => d.Garage).WithMany(p => p.Appointments)
				.HasForeignKey(d => d.GarageId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_APPOINTMENTS_GARAGES");

			entity.HasOne(d => d.Owner).WithMany(p => p.Appointments)
				.HasForeignKey(d => d.OwnerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_APPOINTMENTS_OWNERS");

			entity.HasOne(d => d.Vehicle).WithMany(p => p.Appointments)
				.HasForeignKey(d => d.VehicleId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_APPOINTMENTS_VEHICLES");
		});

		modelBuilder.Entity<Dealership>(entity =>
		{
			entity.ToTable("DEALERSHIPS");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.Address)
				.HasMaxLength(50)
				.HasColumnName("ADDRESS");
			entity.Property(e => e.Created)
				.HasColumnType("datetime")
				.HasColumnName("CREATED");
			entity.Property(e => e.Name)
				.HasMaxLength(50)
				.HasColumnName("NAME");
			entity.Property(e => e.Phone)
				.HasMaxLength(50)
				.HasColumnName("PHONE");
		});

		modelBuilder.Entity<Factory>(entity =>
		{
			entity.ToTable("FACTORIES");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.Created)
				.HasColumnType("datetime")
				.HasColumnName("CREATED");
			entity.Property(e => e.Location)
				.HasMaxLength(50)
				.HasColumnName("LOCATION");
		});

		modelBuilder.Entity<Garage>(entity =>
		{
			entity.ToTable("GARAGES");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.Address)
				.HasMaxLength(50)
				.HasColumnName("ADDRESS");
			entity.Property(e => e.Created)
				.HasColumnType("datetime")
				.HasColumnName("CREATED");
			entity.Property(e => e.Name)
				.HasMaxLength(50)
				.HasColumnName("NAME");
			entity.Property(e => e.Phone)
				.HasMaxLength(50)
				.HasColumnName("PHONE");
		});

		modelBuilder.Entity<Issue>(entity =>
		{
			entity.ToTable("ISSUES");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.AppointmentId).HasColumnName("APPOINTMENT_ID");
			entity.Property(e => e.Created)
				.HasColumnType("datetime")
				.HasColumnName("CREATED");
			entity.Property(e => e.Description)
				.HasMaxLength(500)
				.HasColumnName("DESCRIPTION");

			entity.HasOne(d => d.Appointment).WithMany(p => p.Issues)
				.HasForeignKey(d => d.AppointmentId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_ISSUES_APPOINTMENTS");
		});

		modelBuilder.Entity<Owner>(entity =>
		{
			entity.ToTable("OWNERS");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.Created)
				.HasColumnType("datetime")
				.HasColumnName("CREATED");
			entity.Property(e => e.Firstname)
				.HasMaxLength(50)
				.HasColumnName("FIRSTNAME");
			entity.Property(e => e.Lastname)
				.HasMaxLength(50)
				.HasColumnName("LASTNAME");
			entity.Property(e => e.Phone)
				.HasMaxLength(50)
				.HasColumnName("PHONE");
		});

		modelBuilder.Entity<Ownership>(entity =>
		{
			entity.ToTable("OWNERSHIPS");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.Created)
				.HasColumnType("datetime")
				.HasColumnName("CREATED");
			entity.Property(e => e.OwnerId).HasColumnName("OWNER_ID");
			entity.Property(e => e.Updated)
				.HasColumnType("datetime")
				.HasColumnName("UPDATED");
			entity.Property(e => e.VehicleId).HasColumnName("VEHICLE_ID");

			entity.HasOne(d => d.Owner).WithMany(p => p.Ownerships)
				.HasForeignKey(d => d.OwnerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_OWNERSHIPS_OWNERS");

			entity.HasOne(d => d.Vehicle).WithMany(p => p.Ownerships)
				.HasForeignKey(d => d.VehicleId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_OWNERSHIPS_VEHICLES");
		});

		modelBuilder.Entity<OwnershipHistory>(entity =>
		{
			entity.ToTable("OWNERSHIP_HISTORIES");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.Created)
				.HasColumnType("datetime")
				.HasColumnName("CREATED");
			entity.Property(e => e.CurrentOwnerId).HasColumnName("CURRENT_OWNER_ID");
			entity.Property(e => e.DateOfManufacture)
				.HasColumnType("datetime")
				.HasColumnName("DATE_OF_MANUFACTURE");
			entity.Property(e => e.DateOfSale)
				.HasColumnType("datetime")
				.HasColumnName("DATE_OF_SALE");
			entity.Property(e => e.DateOfTransfer)
				.HasColumnType("datetime")
				.HasColumnName("DATE_OF_TRANSFER");
			entity.Property(e => e.DealershipId).HasColumnName("DEALERSHIP_ID");
			entity.Property(e => e.FactoryId).HasColumnName("FACTORY_ID");
			entity.Property(e => e.PreviousOwnerId).HasColumnName("PREVIOUS_OWNER_ID");
			entity.Property(e => e.Updated)
				.HasColumnType("datetime")
				.HasColumnName("UPDATED");
			entity.Property(e => e.VehicleId).HasColumnName("VEHICLE_ID");

			entity.HasOne(d => d.CurrentOwner).WithMany(p => p.OwnershipHistoryCurrentOwners)
				.HasForeignKey(d => d.CurrentOwnerId)
				.HasConstraintName("FK_OWNERSHIP_HISTORIES_CURRENT_OWNERS");

			entity.HasOne(d => d.Dealership).WithMany(p => p.OwnershipHistories)
				.HasForeignKey(d => d.DealershipId)
				.HasConstraintName("FK_OWNERSHIP_HISTORIES_DEALERSHIPS");

			entity.HasOne(d => d.Factory).WithMany(p => p.OwnershipHistories)
				.HasForeignKey(d => d.FactoryId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_OWNERSHIP_HISTORIES_FACTORIES");

			entity.HasOne(d => d.PreviousOwner).WithMany(p => p.OwnershipHistoryPreviousOwners)
				.HasForeignKey(d => d.PreviousOwnerId)
				.HasConstraintName("FK_OWNERSHIP_HISTORIES_PREVIOUS_OWNERS");

			entity.HasOne(d => d.Vehicle).WithMany(p => p.OwnershipHistories)
				.HasForeignKey(d => d.VehicleId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_OWNERSHIP_HISTORIES_VEHICLES");
		});

		modelBuilder.Entity<Vehicle>(entity =>
		{
			entity.ToTable("VEHICLES");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.Crashed).HasColumnName("CRASHED");
			entity.Property(e => e.Created)
				.HasColumnType("datetime")
				.HasColumnName("CREATED");
			entity.Property(e => e.DateOfManufacture)
				.HasColumnType("datetime")
				.HasColumnName("DATE_OF_MANUFACTURE");
			entity.Property(e => e.Mileage).HasColumnName("MILEAGE");
			entity.Property(e => e.Model)
				.HasMaxLength(50)
				.HasColumnName("MODEL");
			entity.Property(e => e.Updated)
				.HasColumnType("datetime")
				.HasColumnName("UPDATED");
			entity.Property(e => e.Vin)
				.HasMaxLength(20)
				.HasColumnName("VIN");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
