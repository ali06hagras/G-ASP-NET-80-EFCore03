using Assignment19.Models.JunctionTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment19.Configurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> E)
        {
            E.ToTable("Enrollments", table =>
            {
                table.HasCheckConstraint(
                    "CK_Enrollments_Progress",
                    "[ProgressPercentage] >= 0 AND [ProgressPercentage] <= 100"
                );
                table.HasCheckConstraint(
                    "CK_Enrollments_FinalGrade",
                    "[Status] = 'Completed' OR [FinalGrade] IS NULL"
                );
            });
            E.Property(e => e.EnrollmentDate).IsRequired().HasDefaultValueSql("GETDATE()");
            E.Property(e => e.Status).HasConversion<string>().HasMaxLength(50).IsRequired();
            E.Property(e => e.FinalGrade).IsRequired(false).HasPrecision(5, 2);
            E.HasKey(e => new { e.StudentId, e.CourseId });
            E.HasOne(e => e.Student)
              .WithMany(s => s.EnrolledCourses)
              .HasForeignKey(e => e.StudentId)
              .OnDelete(DeleteBehavior.Cascade);
            E.HasOne(e => e.Course)
              .WithMany(c => c.EnrolledStudents)
              .HasForeignKey(e => e.CourseId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
