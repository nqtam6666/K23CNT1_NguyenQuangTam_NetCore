using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NqtLesson09.Models;

public partial class NqtBookStoreBookStoreContext : DbContext
{
    public NqtBookStoreBookStoreContext()
    {
    }

    public NqtBookStoreBookStoreContext(DbContextOptions<NqtBookStoreBookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NqtAccount> NqtAccounts { get; set; }

    public virtual DbSet<NqtBook> NqtBooks { get; set; }

    public virtual DbSet<NqtCategory> NqtCategories { get; set; }

    public virtual DbSet<NqtOrderBook> NqtOrderBooks { get; set; }

    public virtual DbSet<NqtOrderDetail> NqtOrderDetails { get; set; }

    public virtual DbSet<NqtPublisher> NqtPublishers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-ON17EUQ\\NQTAM1;Database=NqtBookStoreBookStore;uid=sa;pwd=1234$;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NqtAccount>(entity =>
        {
            entity.HasKey(e => e.NqtAccountId).HasName("PK__NqtAccou__927AD1E3AD56FACC");

            entity.ToTable("NqtAccount");

            entity.Property(e => e.NqtAccountId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.NqtAddress).HasMaxLength(512);
            entity.Property(e => e.NqtEmail)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.NqtFullName).HasMaxLength(100);
            entity.Property(e => e.NqtPassword)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NqtPhone)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.NqtPicture)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.NqtUsername)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NqtBook>(entity =>
        {
            entity.HasKey(e => e.NqtBookId).HasName("PK__NqtBook__0EFD448FE7AF2424");

            entity.ToTable("NqtBook");

            entity.Property(e => e.NqtBookId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NqtAuthor).HasMaxLength(100);
            entity.Property(e => e.NqtDescription).HasColumnType("ntext");
            entity.Property(e => e.NqtPicture).HasMaxLength(100);
            entity.Property(e => e.NqtTitle).HasMaxLength(200);

            entity.HasOne(d => d.NqtCategory).WithMany(p => p.NqtBooks)
                .HasForeignKey(d => d.NqtCategoryId)
                .HasConstraintName("FK__NqtBook__NqtCate__3C69FB99");

            entity.HasOne(d => d.NqtPublisher).WithMany(p => p.NqtBooks)
                .HasForeignKey(d => d.NqtPublisherId)
                .HasConstraintName("FK__NqtBook__NqtPubl__3B75D760");
        });

        modelBuilder.Entity<NqtCategory>(entity =>
        {
            entity.HasKey(e => e.NqtCategoryId).HasName("PK__NqtCateg__4673C9D620D19ECB");

            entity.ToTable("NqtCategory");

            entity.Property(e => e.NqtCategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<NqtOrderBook>(entity =>
        {
            entity.HasKey(e => e.NqtOrderId).HasName("PK__NqtOrder__60FE11DED2191D57");

            entity.ToTable("NqtOrderBook");

            entity.Property(e => e.NqtOrderId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.NqtAccountId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.NqtNote).HasMaxLength(512);
            entity.Property(e => e.NqtOrderDate).HasColumnType("datetime");
            entity.Property(e => e.NqtOrderReceive).HasColumnType("datetime");
            entity.Property(e => e.NqtReceiveAddress).HasMaxLength(512);
            entity.Property(e => e.NqtReceivePhone)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.NqtStatus)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.HasOne(d => d.NqtAccount).WithMany(p => p.NqtOrderBooks)
                .HasForeignKey(d => d.NqtAccountId)
                .HasConstraintName("FK__NqtOrderB__NqtAc__412EB0B6");
        });

        modelBuilder.Entity<NqtOrderDetail>(entity =>
        {
            entity.HasKey(e => e.NqtOrderDetailId).HasName("PK__NqtOrder__52DA30969C38C00E");

            entity.ToTable("NqtOrderDetail");

            entity.Property(e => e.NqtBookId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NqtOrderId)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.NqtTotalMoney).HasComputedColumnSql("([NqtQuantity]*[NqtPrice])", false);

            entity.HasOne(d => d.NqtBook).WithMany(p => p.NqtOrderDetails)
                .HasForeignKey(d => d.NqtBookId)
                .HasConstraintName("FK__NqtOrderD__NqtBo__44FF419A");

            entity.HasOne(d => d.NqtOrder).WithMany(p => p.NqtOrderDetails)
                .HasForeignKey(d => d.NqtOrderId)
                .HasConstraintName("FK__NqtOrderD__NqtOr__440B1D61");
        });

        modelBuilder.Entity<NqtPublisher>(entity =>
        {
            entity.HasKey(e => e.NqtPublisherId).HasName("PK__NqtPubli__BBB842FC22B188F7");

            entity.ToTable("NqtPublisher");

            entity.Property(e => e.NqtAddress).HasMaxLength(200);
            entity.Property(e => e.NqtPhone)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NqtPublisherName).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
