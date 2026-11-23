using Assignment19.Contexts;
using Assignment19.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Assignment19.CRUD_Methods
{
    public static class UpdateMethods
    {
        public static void ChangeCoursePrice(int courseId , decimal newPrice , OnlineLearningContext context)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }
            if (newPrice < 0)
            {
                Console.WriteLine("Course price cannot be negative.");
                return;
            }
            var oldPrice = course.Price;
            course.Price = newPrice;
            context.SaveChanges();
            Console.WriteLine($"Course Price Changed from {oldPrice} to {newPrice} Successfully!");
        }

        public static void UpdateProgress(int studentId , int courseId , int newProgressPrecentage , OnlineLearningContext context) 
        {
            if (newProgressPrecentage < 0 || newProgressPrecentage > 100)
            {
                Console.WriteLine("Progress must be between 0 and 100.");
                return;
            }
            var enrollment = context.Enrollments.Find(studentId, courseId);
            if (enrollment == null)
            {
                Console.WriteLine("Enrollment not found.");
                return;
            }
            if (enrollment.Status == EnrollmentStatusEnum.Dropped)
            {
                Console.WriteLine("Cannot update progress of a dropped enrollment.");
                return;
            }
            enrollment.ProgressPercentage = newProgressPrecentage;
            if (newProgressPrecentage == 100)
                enrollment.Status = EnrollmentStatusEnum.Completed;
            context.SaveChanges();
            Console.WriteLine("ProgressPrecentage updated Successfully!");
        }

        public static void PublishCourse(int courseId , OnlineLearningContext context)
        {
            var course = context.Courses.Find(courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }
            if (course.IsPublished)
            {
                Console.WriteLine("Course is already Published.");
                return;
            }
            course.IsPublished = true;
            course.PublishingDate = DateTime.Now;
            context.SaveChanges();
            Console.WriteLine("Course Published Successfully!");
        }
    }
}
