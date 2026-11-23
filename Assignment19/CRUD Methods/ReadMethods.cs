using Assignment19.Contexts;
using Assignment19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment19.CRUD_Methods
{
    public static class ReadMethods
    {
        public static void GetCourseById(int courseId, OnlineLearningContext context, out Course? course)
        {
            var result = context.Courses.Find(courseId);
            if (result == null) { 
                Console.WriteLine("Course not found.");
                course = null;
            }
            else
            {
                course = result;
                Console.WriteLine("Course with ID {0} found.", courseId);
            }
        }

        public static void GetCourseByTitle(string courseTitle, OnlineLearningContext context, out Course? course)
        {
            var result = context.Courses.FirstOrDefault(c => c.Title == courseTitle);
            if (result == null)
            {
                Console.WriteLine("Course not found.");
                course = null;
            }
            else
            {
                course = result;
                Console.WriteLine("Course with title '{0}' found.", courseTitle);
            }
        }

        public static void GetCoursesByPriceRange(decimal minPrice, decimal maxPrice, OnlineLearningContext context)
        {
            var result = context.Courses.Where(c => c.Price >= minPrice && c.Price <= maxPrice).OrderByDescending(c => c.Price).ToList();
            if (result.Count == 0)
            {
                Console.WriteLine("No courses found in the specified price range.");
            }
            else
            {
                foreach (var course in result)
                {
                    int x = 1;
                    Console.WriteLine("{0}) Title: {1}, Level: {2}, Price: {3}", x, course.Title, course.Level, course.Price);
                    x++;
                }
            }
        }

        public static void GetSubCategoriesByCategoryId(int categoryId, OnlineLearningContext context)
        {
            var category = context.Categories.Find(categoryId);
            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }
            var subCategories = context.Categories.Where(c => c.ParentCategoryId == categoryId).ToList();
            Console.WriteLine($"Sub-categories of {category.Name} :");
            if (!subCategories.Any())
            {
                Console.WriteLine("No Sub-categories found.");
                return;
            }
            foreach (var subCategory in subCategories)
            {
                Console.WriteLine($"{subCategory.Id} - {subCategory.Name}");
            }
        }

        public static void GetTopLevelCategories(OnlineLearningContext context) 
        {
            var categories = context.Categories.Where(c => c.ParentCategoryId == null).ToList();
            Console.WriteLine("Top Level Categories : ");
            if(!categories.Any())
                Console.WriteLine("No Categories found.");
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Id} - {category.Name}");
            }
        }

        public static void GetCourseStudentsByCourseId(int courseId, OnlineLearningContext context)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }
            var studentIds = context.Enrollments
                                .Where(e => e.CourseId == courseId)
                                .Select(e => e.StudentId)
                                .ToList();
            Console.WriteLine($"Number of enrolled students: {studentIds.Count}");
            if (!studentIds.Any())
            {
                Console.WriteLine("No students Enrolled in this Course.");
                return;
            }
            var students = context.Students.Where(s => studentIds.Contains(s.Id)).ToList();
            Console.WriteLine("Course Roster: ");
            foreach (var student in students)
            {
                int x = 1;
                Console.WriteLine($"{x}) {student.Id} - {student.FullName}");
                x++;
            }
        }
    }
}
