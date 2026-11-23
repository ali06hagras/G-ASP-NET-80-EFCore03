using Assignment19.Contexts;
using Assignment19.Enums;
using Assignment19.Models;
using Assignment19.Models.JunctionTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment19.CRUD_Methods
{
    public static class CreateMethods
    {
        public static void AddNewStudent(string studentName, string studentEmail, int studentAge, OnlineLearningContext context)
        {
            context.Students.Add(new Student
            {
                FullName = studentName,
                EmailAddress = studentEmail,
                DateOfBirth = DateTime.Now.AddYears(-studentAge)
            });
            context.SaveChanges();
            Console.WriteLine("New student added successfully!");
        }

        public static void AddSeveralNewStudents(OnlineLearningContext context, params (string name, string email, int age)[] students)
        {
            foreach (var (name, email, age) in students)
            {
                context.Students.Add(new Student
                {
                    FullName = name,
                    EmailAddress = email,
                    DateOfBirth = DateTime.Now.AddYears(-age)
                });
            }
            context.SaveChanges();
            Console.WriteLine("New students added successfully!");
        }

        public static void AddNewCourse(string courseTitle, string courseDescription, decimal coursePrice, CourseLevelEnum courseLevel, bool courseIsPublished, int courseInstructorId, int courseCategoryId, OnlineLearningContext context)
        {
            if (context.Instructors.Find(courseInstructorId) == null || context.Categories.Find(courseCategoryId) == null)
            {
                Console.WriteLine("Instructor or Category not found.");
                return;
            }
            else
            {
                context.Courses.Add(new Course
                {
                    Title = courseTitle,
                    Description = courseDescription,
                    Price = coursePrice,
                    Level = courseLevel,
                    IsPublished = courseIsPublished,
                    PublishingDate = courseIsPublished ? DateTime.Now : null,
                    InstructorId = courseInstructorId,
                    CategoryId = courseCategoryId
                });
                context.SaveChanges();
                Console.WriteLine("New course added successfully!");
            }
        }

        public static void AddNewCourse(string courseTitle, decimal coursePrice, CourseLevelEnum courseLevel, bool courseIsPublished, int courseInstructorId, int courseCategoryId, OnlineLearningContext context)
        {
            if (context.Instructors.Find(courseInstructorId) == null || context.Categories.Find(courseCategoryId) == null)
            {
                Console.WriteLine("Instructor or Category not found.");
                return;
            }
            else
            {
                context.Courses.Add(new Course
                {
                    Title = courseTitle,
                    Price = coursePrice,
                    Level = courseLevel,
                    IsPublished = courseIsPublished,
                    PublishingDate = courseIsPublished ? DateTime.Now : null,
                    InstructorId = courseInstructorId,
                    CategoryId = courseCategoryId
                });
                context.SaveChanges();
                Console.WriteLine("New course added successfully!");
            }
        }

        public static void AddNewInstructor(string instructorName, string instructorEmail,DateTime instructorDateOfJoin, OnlineLearningContext context)
        {
            context.Instructors.Add(new Instructor
            {
                FullName = instructorName,
                EmailAddress = instructorEmail,
                DateOfJoin = instructorDateOfJoin
            });
            context.SaveChanges();
            Console.WriteLine("New instructor added successfully!");
        }

        public static void AddNewInstructor(string instructorName, string instructorEmail, string instructorShortBio, DateTime instructorDateOfJoin, OnlineLearningContext context)
        {
            context.Instructors.Add(new Instructor
            {
                FullName = instructorName,
                EmailAddress = instructorEmail,
                ShortBio = instructorShortBio,
                DateOfJoin = instructorDateOfJoin
            });
            context.SaveChanges();
            Console.WriteLine("New instructor added successfully!");
        }
    
        public static void EnrollStudentInCourse(int studentId, int courseId, OnlineLearningContext context)
        {
            var student = context.Students.Find(studentId);
            var course = context.Courses.Find(courseId);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }
            if (context.Enrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId))
            {
                Console.WriteLine("Student is already enrolled in this course.");
                return;
            }
            if(context.Courses.FirstOrDefault(c => c.Id == courseId).IsPublished == false)
            {
                Console.WriteLine("Cannot Enroll in an unPublished Course.");
                return;
            }
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Now,
                ProgressPercentage = 0,
                Status = EnrollmentStatusEnum.Active,
                FinalGrade = null
            };
            context.Enrollments.Add(enrollment);
            context.SaveChanges();
            Console.WriteLine($"Student {student.FullName} enrolled in course {course.Title} successfully!");
        }
    }
}