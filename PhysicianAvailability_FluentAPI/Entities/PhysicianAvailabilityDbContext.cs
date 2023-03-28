using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FluentAPI.Entities;

public partial class PhysicianAvailabilityDbContext : DbContext
{
    public PhysicianAvailabilityDbContext()
    {
    }

    public PhysicianAvailabilityDbContext(DbContextOptions<PhysicianAvailabilityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PhysicianAvailablity> PhysicianAvailablities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:poseidonserver.database.windows.net,1433;Initial Catalog=Physician_Availability_DB; User ID=poseidon;Password=Program@123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PhysicianAvailablity>(entity =>
        {
            entity.HasKey(e => e.PhysicianEmail).HasName("PK__physicia__475AE257D150BA1D");

            entity.ToTable("physician_availablity");

            entity.Property(e => e.PhysicianEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("physician_email");
            entity.Property(e => e.AvailableFrom)
                .IsUnicode(false)
                .HasColumnName("available_from");
            entity.Property(e => e.AvailableTo)
                .IsUnicode(false)
                .HasColumnName("available_to");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
