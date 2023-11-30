using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRestAPI.Models.EF;

public partial class EmployeeDbContext : DbContext
{
    public EmployeeDbContext()
    {
    }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-NE0I5RC;database=EmployeeDB;integrated security=true;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Deptno).HasName("PK__Departme__BE2C337D44B1BC30");

            entity.ToTable("Department");

            entity.Property(e => e.Deptno)
                .ValueGeneratedNever()
                .HasColumnName("deptno");
            entity.Property(e => e.Deptemail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("deptemail");
            entity.Property(e => e.Deptlocation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deptlocation");
            entity.Property(e => e.Deptname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deptname");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empno).HasName("PK__Employee__AF4C318A89090E8F");

            entity.ToTable("Employee");

            entity.Property(e => e.Empno)
                .ValueGeneratedNever()
                .HasColumnName("empno");
            entity.Property(e => e.Deptno).HasColumnName("deptno");
            entity.Property(e => e.Empdesignation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empdesignation");
            entity.Property(e => e.Empispermenant)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("empispermenant");
            entity.Property(e => e.Empname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empname");
            entity.Property(e => e.Empsalary).HasColumnName("empsalary");

            entity.HasOne(d => d.DeptnoNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Deptno)
                .HasConstraintName("FK__Employee__deptno__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
