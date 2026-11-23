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
            C.HasMany(c => c.Courses)
                .WithOne(cc => cc.Category)
                .HasForeignKey(cc => cc.CategoryId);
            C.HasMany(c => c.SubCategories)
                .WithOne(c => c.ParentCategory)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            C.Property(c => c.ParentCategoryId).IsRequired(false);
        }
    }
}
