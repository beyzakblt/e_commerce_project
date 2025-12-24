using Microsoft.EntityFrameworkCore;

namespace e_commerce_project.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // 🔹 KULLANICILAR TABLOSU
    public DbSet<Kullanıcılar> Kullanıcılars { get; set; }

    // 🔹 YONETICI TABLOSU
    public DbSet<Yonetici> Yoneticilers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kullanıcılar>(entity =>
        {
            entity.ToTable("Kullanıcılar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pass");
            entity.Property(e => e.Users)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("users");
        });

        modelBuilder.Entity<Yonetici>(entity =>
        {
            entity.ToTable("Yonetici");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Durum).HasColumnName("durum");
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pass");
            entity.Property(e => e.Statu).HasColumnName("statu");
            entity.Property(e => e.Users)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
