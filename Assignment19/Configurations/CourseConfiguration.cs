using Assignment19.Enums;
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
            C.HasOne(c => c.Instructor)
                .WithMany(i => i.CoursesInstructed)
                .HasForeignKey(c => c.InstructorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            C.HasOne(c => c.Category)
                .WithMany(cat => cat.Courses)
                .HasForeignKey(c => c.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            C.HasData(
                new Course
                {
                    Id = 1,
                    Title = "Introduction to Programming",
                    Description = "Learn the basics of programming using C#.",
                    Price = 99.99m,
                    Level = CourseLevelEnum.Beginner,
                    IsPublished = false,
                    PublishingDate = null,
                    InstructorId = 1,
                    CategoryId = 1
                },
                new Course
                {
                    Id = 2,
                    Title = "Advanced Web Development",
                    Description = "Master advanced web development techniques using ASP.NET Core.",
                    Price = 199.99m,
                    Level = CourseLevelEnum.Advanced,
                    IsPublished = false,
                    PublishingDate = null,
                    InstructorId = 2,
                    CategoryId = 2
                },
                new Course
                {
                    Id = 3,
                    Title = "Mobile Development",
                    Price = 200.00m,
                    Level = CourseLevelEnum.Beginner,
                    IsPublished = true,
                    PublishingDate = new DateTime(2025, 1, 15),
                    InstructorId = 1,
                    CategoryId = 3
                },
                new Course
                {
                    Id = 4,
                    Title = "Intro To Data Science",
                    Price = 150.00m,
                    Level = CourseLevelEnum.Beginner,
                    IsPublished = false,
                    PublishingDate = null,
                    InstructorId = 2,
                    CategoryId = 4
                }
            );
        }
    }
}
