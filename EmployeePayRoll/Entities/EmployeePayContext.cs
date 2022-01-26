using System;
using EmployeePayRoll.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeePayRoll.Entities
{
    public partial class EmployeePayContext : DbContext
    {
        public EmployeePayContext()
        {
        }

        public EmployeePayContext(DbContextOptions<EmployeePayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeductionType> DeductionType { get; set; }
        public virtual DbSet<Dependent> Dependent { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlHelper.GetConnection());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeductionType>(entity =>
            {
                entity.Property(e => e.DeductionAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DeductionCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DeductionName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dependent>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.DeductionType)
                    .WithMany(p => p.Dependent)
                    .HasForeignKey(d => d.DeductionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Dependent__Deduc__7C4F7684");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Dependent)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Dependent__Emplo__7B5B524B");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PayPerPeriod).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.DeductionType)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DeductionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Deduct__787EE5A0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
