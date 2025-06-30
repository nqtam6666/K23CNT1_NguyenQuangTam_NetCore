using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenQuangTam_2310900093.Models;

public partial class NguyenQuangTam2310900093Context : DbContext
{
    public NguyenQuangTam2310900093Context()
    {
    }

    public NguyenQuangTam2310900093Context(DbContextOptions<NguyenQuangTam2310900093Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NqtEmployee> NqtEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-ON17EUQ\\NQTAM1;Database=NguyenQuangTam_2310900093;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NqtEmployee>(entity =>
        {
            entity.HasKey(e => e.NqtEmpId);

            entity.ToTable("NqtEmployee");

            entity.Property(e => e.NqtEmpId).HasColumnName("nqtEmpId");
            entity.Property(e => e.NqtEmpLevel)
                .HasMaxLength(250)
                .HasColumnName("nqtEmpLevel");
            entity.Property(e => e.NqtEmpName)
                .HasMaxLength(250)
                .HasColumnName("nqtEmpName");
            entity.Property(e => e.NqtEmpStartDate).HasColumnName("nqtEmpStartDate");
            entity.Property(e => e.NqtEmpStatus).HasColumnName("nqtEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
