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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> I)
        {
            I.ToTable("Instructors");
            I.Property(i=> i.FullName).IsRequired().HasMaxLength(100);
            I.Property(i=> i.EmailAddress).IsRequired().HasMaxLength(100);
            I.Property(i=> i.ShortBio).IsRequired(false).HasMaxLength(250);
            I.Property(i => i.DateOfJoin).HasDefaultValueSql("GETDATE()");
            I.HasMany(i => i.CoursesInstructed).WithOne(ci => ci.Instructor).HasForeignKey(ci => ci.InstructorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
