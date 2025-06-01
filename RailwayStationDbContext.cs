using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Rail.Data.Models;

public partial class RailwayStationDbContext : DbContext
{
    public RailwayStationDbContext()
    {
    }

    public RailwayStationDbContext(DbContextOptions<RailwayStationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=STUDENT14;Initial Catalog=RailwayStationDB;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83FFD4A6D6E");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("position");
            entity.Property(e => e.TrainId).HasColumnName("train_id");

            entity.HasOne(d => d.Train).WithMany(p => p.Employees)
                .HasForeignKey(d => d.TrainId)
                .HasConstraintName("FK__Employees__train__44FF419A");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Routes__3213E83F17E0E51E");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArrivalStation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("arrival_station");
            entity.Property(e => e.ArrivalTime)
                .HasColumnType("datetime")
                .HasColumnName("arrival_time");
            entity.Property(e => e.DepartureStation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("departure_station");
            entity.Property(e => e.DepartureTime)
                .HasColumnType("datetime")
                .HasColumnName("departure_time");
            entity.Property(e => e.TrainId).HasColumnName("train_id");

            entity.HasOne(d => d.Train).WithMany(p => p.Routes)
                .HasForeignKey(d => d.TrainId)
                .HasConstraintName("FK__Routes__train_id__3A81B327");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tickets__3213E83FF0D6AC84");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PassengerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("passenger_name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.RounteId).HasColumnName("rounte_id");
            entity.Property(e => e.SeatNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("seat_number");
            entity.Property(e => e.TrainId).HasColumnName("train_id");

            entity.HasOne(d => d.Rounte).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.RounteId)
                .HasConstraintName("FK__Tickets__rounte___4222D4EF");

            entity.HasOne(d => d.Train).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TrainId)
                .HasConstraintName("FK__Tickets__train_i__412EB0B6");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tracks__3213E83F83D2419B");

            entity.HasIndex(e => e.TrackNumber, "UQ__Tracks__1C93872813DCB949").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("station_name");
            entity.Property(e => e.TrackNumber).HasColumnName("track_number");
            entity.Property(e => e.TrainId).HasColumnName("train_id");

            entity.HasOne(d => d.Train).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.TrainId)
                .HasConstraintName("FK__Tracks__train_id__3E52440B");
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trains__3213E83F99873281");

            entity.HasIndex(e => e.TrainNumber, "UQ__Trains__55C242D1F49E9675").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.TrainNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("train_number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
