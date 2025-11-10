using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using _1_praktiskais.Models;

namespace _1_praktiskais.Data;

public partial class Praktiskais1Context : DbContext
{
    public Praktiskais1Context()
    {
    }

    public Praktiskais1Context(DbContextOptions<Praktiskais1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Bmi> Bmis { get; set; }

    public virtual DbSet<Hobiji> Hobijis { get; set; }

    public virtual DbSet<Lietotaj> Lietotajs { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Skaitliskidati> Skaitliskidatis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-31FTSSL\\SQLEXPRESS;Database=praktiskais_1;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bmi>(entity =>
        {
            entity.ToTable("bmi");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Augums)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("augums");
            entity.Property(e => e.Svars)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("svars");
        });

        modelBuilder.Entity<Hobiji>(entity =>
        {
            entity.ToTable("hobiji");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Hobijs)
                .HasMaxLength(50)
                .HasColumnName("hobijs");
            entity.Property(e => e.Skola)
                .HasMaxLength(50)
                .HasColumnName("skola");
        });

        modelBuilder.Entity<Lietotaj>(entity =>
        {
            entity.ToTable("lietotajs");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Uzvards)
                .HasMaxLength(50)
                .HasColumnName("uzvards");
            entity.Property(e => e.Vards)
                .HasMaxLength(50)
                .HasColumnName("vards");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.ToTable("login");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Epasts)
                .HasMaxLength(50)
                .HasColumnName("epasts");
            entity.Property(e => e.Parole)
                .HasMaxLength(50)
                .HasColumnName("parole");
        });

        modelBuilder.Entity<Skaitliskidati>(entity =>
        {
            entity.ToTable("skaitliskidati");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Perskods)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("perskods");
            entity.Property(e => e.Telefons)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("telefons");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
