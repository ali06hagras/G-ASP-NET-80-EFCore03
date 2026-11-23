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
            I.HasData(
                new Instructor
                {
                    Id = 1,
                    FullName = "Dr. Tariq Mansour",
                    EmailAddress = "tariq.mansour@example.edu",
                    ShortBio = "Senior software engineer with 12 years of experience in .NET and distributed systems.",
                    DateOfJoin = new DateTime(2019, 9, 1)
                },
                new Instructor
                {
                    Id = 2,
                    FullName = "Nadia El-Sayed",
                    EmailAddress = "nadia.elsayed@example.edu",
                    ShortBio = null,
                    DateOfJoin = new DateTime(2022, 2, 15)
                });
        }
    }
}
