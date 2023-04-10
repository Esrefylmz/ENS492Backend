using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.Entities;

public partial class Ens4912AirqualityContext : DbContext
{
    public Ens4912AirqualityContext()
    {
    }

    public Ens4912AirqualityContext(DbContextOptions<Ens4912AirqualityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanySensor> CompanySensors { get; set; }

    public virtual DbSet<CompanyUser> CompanyUsers { get; set; }

    public virtual DbSet<Home> Homes { get; set; }

    public virtual DbSet<HomeSensor> HomeSensors { get; set; }

    public virtual DbSet<HomeUser> HomeUsers { get; set; }

    public virtual DbSet<MeasurementType> MeasurementTypes { get; set; }

    public virtual DbSet<MonitorDatum> MonitorData { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<SensorDateLog> SensorDateLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingId).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "Buildings_fk0");

            entity.Property(e => e.BuildingId)
                .HasColumnType("int(12)")
                .HasColumnName("buildingID");
            entity.Property(e => e.CompanyId)
                .HasColumnType("int(12)")
                .HasColumnName("companyID");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PRIMARY");

            entity.HasIndex(e => e.Domain, "Domain").IsUnique();

            entity.Property(e => e.CompanyId)
                .HasColumnType("int(12)")
                .HasColumnName("companyID");
            entity.Property(e => e.Ssid).HasColumnName("SSID");
        });

        modelBuilder.Entity<CompanySensor>(entity =>
        {
            entity.HasKey(e => e.SoftId).HasName("PRIMARY");

            entity.Property(e => e.SoftId)
                .HasColumnType("int(12)")
                .HasColumnName("SoftID");
            entity.Property(e => e.BuildingName)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("buildingName");
            entity.Property(e => e.CompanyId)
                .HasColumnType("int(12)")
                .HasColumnName("CompanyID");
            entity.Property(e => e.LocationInfo)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("locationInfo");
            entity.Property(e => e.MacId)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("macID");
            entity.Property(e => e.RoomId)
                .HasColumnType("int(12)")
                .HasColumnName("roomID");
            entity.Property(e => e.RoomName)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("roomName");
        });

        modelBuilder.Entity<CompanyUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.HasIndex(e => e.CompanyId, "CompanyUsers_fk0");

            entity.Property(e => e.UserId)
                .HasColumnType("int(12)")
                .HasColumnName("userID");
            entity.Property(e => e.CompanyId)
                .HasColumnType("int(12)")
                .HasColumnName("companyID");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.UserType)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("userType");
            entity.Property(e => e.Usermail)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("usermail");
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("username");
        });

        modelBuilder.Entity<Home>(entity =>
        {
            entity.HasKey(e => e.HomeId).HasName("PRIMARY");
            entity.Property(e => e.HomeId)
                .HasColumnType("int(12)")
                .HasColumnName("homeID");
            entity.Property(e => e.HomeName)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("homeName");
        });

        modelBuilder.Entity<HomeSensor>(entity =>
        {
            entity.HasKey(e => e.SensorId).HasName("PRIMARY");

            entity.HasIndex(e => e.HomeId, "HomeSensors_fk0");

            entity.Property(e => e.SensorId)
                .HasColumnType("int(12)")
                .HasColumnName("sensorID");
            entity.Property(e => e.HomeId)
                .HasColumnType("int(12)")
                .HasColumnName("homeID");
            entity.Property(e => e.Location)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("location");

            entity.HasOne(d => d.Home).WithMany(p => p.HomeSensors)
                .HasForeignKey(d => d.HomeId)
                .HasConstraintName("HomeSensors_fk0");
        });

        modelBuilder.Entity<HomeUser>(entity =>
        {
            entity.HasKey(e => e.userId).HasName("PRIMARY");


            entity.Property(e => e.userId)
                .HasColumnType("int(12)")
                .HasColumnName("userID");
            entity.Property(e => e.Mail)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("usermail");
            entity.Property(e => e.HomeId)
                .HasColumnType("int(12)")
                .HasColumnName("homeID");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("username");
        });
        modelBuilder.Entity<MeasurementType>(entity =>
        {
            entity.HasKey(e => e.MeasurementTypeId).HasName("PRIMARY");

            entity.ToTable("measurement_types");

            entity.Property(e => e.MeasurementTypeId)
                .HasColumnType("smallint(5)")
                .HasColumnName("measurement_type_id");
            entity.Property(e => e.DisplayOrder)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("display_order");
            entity.Property(e => e.MaxValue)
                .HasColumnType("mediumint(6)")
                .HasColumnName("max_value");
            entity.Property(e => e.MeasurementKey)
                .HasMaxLength(16)
                .HasColumnName("measurement_key");
            entity.Property(e => e.MeasurementType1)
                .HasColumnType("text")
                .HasColumnName("measurement_type");
            entity.Property(e => e.MinValue)
                .HasColumnType("mediumint(6)")
                .HasColumnName("min_value");
            entity.Property(e => e.NormalMax)
                .HasColumnType("int(11)")
                .HasColumnName("normal_max");
            entity.Property(e => e.NormalMin)
                .HasColumnType("mediumint(9)")
                .HasColumnName("normal_min");
            entity.Property(e => e.Unit)
                .HasMaxLength(16)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<MonitorDatum>(entity =>
        {
            entity.HasKey(e => e.MeasurementId).HasName("PRIMARY");

            entity.ToTable("monitor_data");

            entity.HasIndex(e => e.MacId, "macID");

            entity.HasIndex(e => e.MeasurementTypeId, "measurement_type_id");

            entity.Property(e => e.MeasurementId)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("measurement_id");
            entity.Property(e => e.MacId)
                .HasMaxLength(50)
                .HasColumnName("macID");
            entity.Property(e => e.MeasurementTypeId)
                .HasColumnType("smallint(5)")
                .HasColumnName("measurement_type_id");
            entity.Property(e => e.MeasurementValue).HasColumnName("measurement_value");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("timestamp");

        });


        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PRIMARY");

            entity.HasIndex(e => e.BuildingId, "Rooms_fk0");

            entity.Property(e => e.RoomId)
                .HasColumnType("int(12)")
                .HasColumnName("roomID");
            entity.Property(e => e.BuildingId)
                .HasColumnType("int(12)")
                .HasColumnName("buildingID");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsFixedLength();
        });

        modelBuilder.Entity<SensorDateLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PRIMARY");

            entity.ToTable("sensorDateLog");

            entity.HasIndex(e => e.MacId, "macID");

            entity.Property(e => e.LogId)
                .HasColumnType("int(11)")
                .HasColumnName("logId");
            entity.Property(e => e.BuildingName)
                .HasMaxLength(32)
                .HasColumnName("buildingName");
            entity.Property(e => e.CompanyId)
                .HasColumnType("int(11)")
                .HasColumnName("companyId");
            entity.Property(e => e.LocationInfo)
                .HasMaxLength(50)
                .HasColumnName("locationInfo");
            entity.Property(e => e.LogDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("logDate");
            entity.Property(e => e.MacId)
                .HasMaxLength(50)
                .HasColumnName("macID");
            entity.Property(e => e.RoomName)
                .HasMaxLength(32)
                .HasColumnName("roomName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
