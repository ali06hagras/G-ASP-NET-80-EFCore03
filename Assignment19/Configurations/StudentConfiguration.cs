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
            S.HasData(
                new Student
                {
                    Id = 1,
                    FullName = "Omar Hassan",
                    EmailAddress = "omar.hassan@student.edu",
                    DateOfBirth = new DateTime(2002, 4, 18)
                },
                new Student
                {
                    Id = 2,
                    FullName = "Salma Ibrahim",
                    EmailAddress = "salma.ibrahim@student.edu",
                    DateOfBirth = new DateTime(2003, 11, 7)
                },
                new Student
                {
                    Id = 3,
                    FullName = "Youssef Adel",
                    EmailAddress = "youssef.adel@student.edu",
                    DateOfBirth = new DateTime(2001, 7, 25)
                }
                );
        }
    }
}
