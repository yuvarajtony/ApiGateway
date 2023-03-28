using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace audit_service.Entities;

public partial class AuditServiceContext : DbContext
{
    public AuditServiceContext()
    {
    }

    public AuditServiceContext(DbContextOptions<AuditServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BloodGroupTable> BloodGroupTables { get; set; }

    public virtual DbSet<BloodPressureDiastolicTable> BloodPressureDiastolicTables { get; set; }

    public virtual DbSet<BloodPressureSystolicTable> BloodPressureSystolicTables { get; set; }

    public virtual DbSet<BodyTemperature> BodyTemperatures { get; set; }

    public virtual DbSet<HeightTable> HeightTables { get; set; }

    public virtual DbSet<RespirationTable> RespirationTables { get; set; }

    public virtual DbSet<WeightTable> WeightTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=tcp:poseidonserver.database.windows.net,1433;initial catalog=Audit_Service;persist security info=false;user id=poseidon;password=Program@123;multipleactiveresultsets=false;encrypt=true;trustservercertificate=false;connection timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BloodGroupTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__blood_gr__3213E83F4C683078");

            entity.ToTable("blood_group_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Value)
                .IsUnicode(false)
                .HasColumnName("value");
        });

        modelBuilder.Entity<BloodPressureDiastolicTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__blood_pr__3213E83F6098F66D");

            entity.ToTable("blood_pressure_diastolic_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<BloodPressureSystolicTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__blood_pr__3213E83F417F4977");

            entity.ToTable("blood_pressure_systolic_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<BodyTemperature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__body_tem__3213E83F7407742F");

            entity.ToTable("body_temperature");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<HeightTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__height_t__3213E83F54D0E838");

            entity.ToTable("height_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<RespirationTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__respirat__3213E83F6B6ACE8F");

            entity.ToTable("respiration_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<WeightTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__weight_t__3213E83F0440E92F");

            entity.ToTable("weight_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
