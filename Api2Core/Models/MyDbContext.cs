using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api2Core.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RevisionApi> RevisionApis { get; set; }

    public virtual DbSet<StudentDb> StudentDbs { get; set; }

    public virtual DbSet<TblDepartment> TblDepartments { get; set; }

    public virtual DbSet<TblapiEmployee> TblapiEmployees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//    => optionsBuilder.UseSqlServer("Server=FARJAN\\SQLEXPRESS02;Database=MyDb;Trusted_Connection=True;TrustServerCertificate=True;");
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RevisionApi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Revision__3213E83FE6841D4E");

            entity.ToTable("RevisionApi");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<StudentDb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentD__3213E83F073168A5");

            entity.ToTable("StudentDb");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FatherName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StudentGender)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__tblDepar__B2079BEDD6CF865B");

            entity.ToTable("tblDepartment");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblapiEmployee>(entity =>
        {
            entity.HasKey(e => e.Empid).HasName("PK__tblapiEm__AF4CE8655C153AE7");

            entity.ToTable("tblapiEmployee");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmpName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("empName");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
