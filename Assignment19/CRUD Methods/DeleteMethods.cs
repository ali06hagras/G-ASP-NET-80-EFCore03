using Assignment19.Contexts;
using Assignment19.Models.JunctionTables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment19.CRUD_Methods
{
    public static class DeleteMethods
    {
        public static void Unenroll(int studentId, int courseId, OnlineLearningContext context)
        {
            var enrollment = context.Enrollments.Find(studentId, courseId);
            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }
            context.Remove(enrollment);
            context.SaveChanges();
            Console.WriteLine("Enrollment Deleted Successfully!");
        }

        public static void DeleteCategory(int categoryId , OnlineLearningContext context)
        {
            var category = context.Categories.Find(categoryId);
            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            try
            {
                context.Categories.Remove(category);
                context.SaveChanges();

                Console.WriteLine("Category deleted successfully.");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Cannot delete this category!");
                Console.WriteLine($"Database error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public static bool TryDeleteCategory(int categoryId, OnlineLearningContext context)
        {
            var category = context.Categories.Find(categoryId);
            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return false;
            }
            bool hasSubCategories = context.Categories
                                            .Any(c => c.ParentCategoryId == categoryId);

            if (hasSubCategories)
            {
                Console.WriteLine("Cannot delete this category because it has sub-categories.");
                return false;
            }

            bool hasCourses = context.Courses
                                     .Any(c => c.CategoryId == categoryId);

            if (hasCourses)
            {
                Console.WriteLine("Cannot delete this category because it has courses.");
                return false;
            }

            context.Categories.Remove(category);
            context.SaveChanges();

            Console.WriteLine("Category Deleted Successfully!");
            return true;
        }

        public static void DeleteCourse(int courseId , OnlineLearningContext context)
        {
            var course = context.Courses.Find(courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }
            int beforeCount = context.Enrollments
                                     .Count(e => e.CourseId == courseId);

            Console.WriteLine($"Enrollments before deletion: {beforeCount}");

            context.Courses.Remove(course);
            context.SaveChanges();

            // Enrollments are automatically deleted because the Course-Enrollment relationship uses DeleteBehavior.Cascade

            int afterCount = context.Enrollments
                                    .Count(e => e.CourseId == courseId);

            Console.WriteLine($"Enrollments after deletion: {afterCount}");
        }
    }
}
