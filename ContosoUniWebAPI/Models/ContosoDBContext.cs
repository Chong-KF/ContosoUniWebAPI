using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ContosoUniWebAPI.Models
{
    public partial class ContosoDBContext : DbContext
    {
        public ContosoDBContext()
        {
        }

        public ContosoDBContext(DbContextOptions<ContosoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer("Name=ContosoDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("Enrollment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseID);

                entity.Property(e => e.Grade)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    //.HasDefaultValueSql("('A, B, C, D, F')")
                    .IsFixedLength(true);

                entity.Property(e => e.StudentID);

                //entity.HasOne(d => d.CourseFkNavigation)
                //    .WithMany(p => p.Enrollments)
                //    .HasForeignKey(d => d.CourseID)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Enrollment_Course");

                //entity.HasOne(d => d.StudentFkNavigation)
                //    .WithMany(p => p.Enrollments)
                //    .HasForeignKey(d => d.StudentID)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Enrollment_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnrollmentDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
