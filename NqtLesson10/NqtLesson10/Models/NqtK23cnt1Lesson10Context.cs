using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NqtLesson10.Models;

public partial class NqtK23cnt1Lesson10Context : DbContext
{
    public NqtK23cnt1Lesson10Context()
    {
    }

    public NqtK23cnt1Lesson10Context(DbContextOptions<NqtK23cnt1Lesson10Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NqtPost> NqtPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-ON17EUQ\\NQTAM1;Database=NqtK23CNT1_Lesson10;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NqtPost>(entity =>
        {
            entity.HasKey(e => e.NqtId);

            entity.ToTable("NqtPost");

            entity.Property(e => e.NqtId).HasColumnName("nqtID");
            entity.Property(e => e.NqtImage)
                .HasMaxLength(250)
                .HasColumnName("nqtImage");
            entity.Property(e => e.NqtStatus).HasColumnName("nqtStatus");
            entity.Property(e => e.NqtText)
                .HasColumnType("ntext")
                .HasColumnName("nqtText");
            entity.Property(e => e.NqtTitle)
                .HasMaxLength(250)
                .HasColumnName("nqtTitle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
