using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MaratonValto.Models;

public partial class MaratonContext : DbContext
{
    public MaratonContext()
    {
    }

    public MaratonContext(DbContextOptions<MaratonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Eredmenyek> Eredmenyeks { get; set; }

    public virtual DbSet<Futok> Futoks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=maraton;user=root;password=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Eredmenyek>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("eredmenyek");

            entity.HasIndex(e => e.Futo, "fk_futo_id");

            entity.Property(e => e.Futo)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("futo");
            entity.Property(e => e.Ido)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("ido");
            entity.Property(e => e.Kor)
                .HasColumnType("int(11)")
                .HasColumnName("kor");

            entity.HasOne(d => d.FutoNavigation).WithMany()
                .HasForeignKey(d => d.Futo)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_futo_id");
        });

        modelBuilder.Entity<Futok>(entity =>
        {
            entity.HasKey(e => e.Fid).HasName("PRIMARY");

            entity.ToTable("futok");

            entity.Property(e => e.Fid)
                .HasColumnType("int(11)")
                .HasColumnName("fid");
            entity.Property(e => e.Csapat)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("csapat");
            entity.Property(e => e.Ffi)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("ffi");
            entity.Property(e => e.Fnev)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("fnev");
            entity.Property(e => e.Szulev)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("szulev");
            entity.Property(e => e.Szulho)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("szulho");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
