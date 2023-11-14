using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class KeeperBdContext : DbContext
{
    public KeeperBdContext()
    {
    }

    public KeeperBdContext(DbContextOptions<KeeperBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupsVisitor> GroupsVisitors { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=KeeperBD;User=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Applications", "KeeperBD");

            entity.HasIndex(e => e.EmployeeId, "Purposes_FK");

            entity.HasIndex(e => e.GroupId, "Purposes_FK_1");

            entity.Property(e => e.DateOfVisit).HasMaxLength(50);

            entity.HasOne(d => d.Employee).WithMany(p => p.Applications)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("Application_FK_1");

            entity.HasOne(d => d.Group).WithMany(p => p.Applications)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("Application_FK");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Departments", "KeeperBD");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Employees", "KeeperBD");

            entity.HasIndex(e => e.DepartmentId, "Employes_FK");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("Employes_FK");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Groups", "KeeperBD");

            entity.Property(e => e.Group1)
                .HasMaxLength(50)
                .HasColumnName("Group");
        });

        modelBuilder.Entity<GroupsVisitor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GroupsVisitors", "KeeperBD");

            entity.HasIndex(e => e.VisitorId, "GroupsVisitors_FK");

            entity.HasIndex(e => e.GroupId, "GroupsVisitors_FK_1");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GroupsVisitors_FK_1");

            entity.HasOne(d => d.Visitor).WithMany()
                .HasForeignKey(d => d.VisitorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GroupsVisitors_FK");
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Visitors", "KeeperBD");

            entity.Property(e => e.DataOfPasport).HasMaxLength(50);
            entity.Property(e => e.DateOfBirth).HasMaxLength(50);
            entity.Property(e => e.EMail)
                .HasMaxLength(50)
                .HasColumnName("E-mail");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NumberPhone).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
