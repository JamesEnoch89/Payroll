using System;
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

        public virtual DbSet<Deduction> Deduction { get; set; }
        public virtual DbSet<DeductionType> DeductionType { get; set; }
        public virtual DbSet<Dependent> Dependent { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=JENOCH03;Database=EmployeePay;User Id=sa;Password=provisionDBService;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deduction>(entity =>
            {
                entity.Property(e => e.DeductionAmount).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.DeductionType)
                    .WithMany(p => p.Deduction)
                    .HasForeignKey(d => d.DeductionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Deduction__Deduc__5DCAEF64");
            });

            modelBuilder.Entity<DeductionType>(entity =>
            {
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

                entity.HasOne(d => d.Deduction)
                    .WithMany(p => p.Dependent)
                    .HasForeignKey(d => d.DeductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Dependent__Deduc__6477ECF3");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Dependent)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Dependent__Emplo__6383C8BA");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PayPerPeriod).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Deduction)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DeductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Deduct__60A75C0F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
