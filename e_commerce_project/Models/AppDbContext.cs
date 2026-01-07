using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_project.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Iletisim> Iletisims { get; set; }

    public virtual DbSet<IletisimDurumLog> IletisimDurumLogs { get; set; }

    public DbSet<Musteri> Musteriler { get; set; }

    public virtual DbSet<Kullanıcılar> Kullanıcılars { get; set; }

    public virtual DbSet<Yonetici> Yoneticis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-PEPN09L\\SQLEXPRESS;Database=ILK;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Iletisim>(entity =>
        {
            entity.ToTable("Iletisim");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdSoyad)
                .HasMaxLength(50)
                .HasColumnName("adSoyad");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Mesaj)
                .HasMaxLength(150)
                .HasColumnName("mesaj");
            entity.Property(e => e.Tarih)
                .HasColumnType("datetime")
                .HasColumnName("tarih");
        });

        modelBuilder.Entity<IletisimDurumLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Iletisim__3214EC070345F39E");

            entity.ToTable("IletisimDurumLog");

            entity.Property(e => e.Tarih)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Kullanıcılar>(entity =>
        {
            entity.ToTable("Kullanıcılar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .HasColumnName("pass");
            entity.Property(e => e.Users)
                .HasMaxLength(50)
                .HasColumnName("users");
        });

        modelBuilder.Entity<Yonetici>(entity =>
        {
            entity.ToTable("Yonetici");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Pass).HasMaxLength(50);
            entity.Property(e => e.Users).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
