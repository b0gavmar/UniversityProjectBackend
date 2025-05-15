using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UniversityProjectBackend.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Database\\database.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("courses");

            entity.Property(e => e.Credits).HasColumnType("INT");
            entity.Property(e => e.DepartmentId)
                .HasColumnType("INT")
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("ID");
            entity.Property(e => e.TeacherId)
                .HasColumnType("INT")
                .HasColumnName("TeacherID");

            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("departments");

            entity.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("ID");

            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("students");

            entity.Property(e => e.Age).HasColumnType("INT");
            entity.Property(e => e.DepartmentId)
                .HasColumnType("INT")
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Enrolled)
                .HasColumnType("INT")
                .HasColumnName("Enrolled ");
            entity.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("ID");

            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("teachers");

            entity.Property(e => e.DepartmentId)
                .HasColumnType("INT")
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("ID");

            entity.HasKey(e => e.Id);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
