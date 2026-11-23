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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> S)
        {
            S.ToTable("Students");
            S.Property(s => s.FullName).IsRequired().HasMaxLength(100);
            S.Property(s => s.EmailAddress).IsRequired().HasMaxLength(100);
            S.Property(s => s.DateOfBirth).IsRequired().HasColumnType("datetime2");
            S.HasMany(s => s.EnrolledCourses)
             .WithOne(e => e.Student)
             .HasForeignKey(e => e.StudentId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
