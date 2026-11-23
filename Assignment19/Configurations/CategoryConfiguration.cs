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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> C)
        {
            C.ToTable("Categories");
            C.Property(c => c.Name).IsRequired().HasMaxLength(100);
            C.Property(c => c.Description).IsRequired(false).HasMaxLength(500);
            C.HasMany(c => c.SubCategories)
                .WithOne(c => c.ParentCategory)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            C.Property(c => c.ParentCategoryId).IsRequired(false);
            C.HasData(
                new Category { Id = 1, Name = "Programming", Description = "All programming related courses" },
                new Category { Id = 2, Name = "Web Development", Description = "Courses related to web development", ParentCategoryId = 1 },
                new Category { Id = 3, Name = "Mobile Development", Description = "Courses related to mobile development", ParentCategoryId = 1 },
                new Category { Id = 4, Name = "Data Science", Description = "Courses related to data science" }
            );
        }
    }
}
