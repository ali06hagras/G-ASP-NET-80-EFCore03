using Assignment19.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment19.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> C)
        {
            C.ToTable("Courses", table =>
            {
                table.HasCheckConstraint(
                    "CK_Courses_PublishingDate",
                    "([IsPublished] = 0 AND [PublishingDate] IS NULL) OR " +
                    "([IsPublished] = 1 AND [PublishingDate] IS NOT NULL)"
                );
            });
            C.Property(c => c.Title).IsRequired().HasMaxLength(200);
            C.Property(c => c.Description).IsRequired(false).HasMaxLength(500);
            C.Property(c => c.Price).IsRequired().HasPrecision(18, 2);
            C.Property(c => c.Level).HasConversion<string>().HasMaxLength(50).IsRequired();
            C.Property(c => c.IsPublished).IsRequired();
            C.Property(c => c.PublishingDate).IsRequired(false);
            C.HasMany(c => c.EnrolledStudents)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
