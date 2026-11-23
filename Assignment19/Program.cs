using Assignment19.Contexts;
using Assignment19.Enums;
using static Assignment19.CRUD_Methods.CreateMethods;
using static Assignment19.CRUD_Methods.DeleteMethods;
using static Assignment19.CRUD_Methods.ReadMethods;
using static Assignment19.CRUD_Methods.UpdateMethods;
namespace Assignment19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new OnlineLearningContext();

            #region Create
            Console.WriteLine("========== CREATE OPERATIONS ==========");

            AddNewStudent(
                    "Ali Ahmed",
                    "ali@example.com",
                    22,
                    context
                );

            AddSeveralNewStudents(
                    context,
                    ("Mariam Hassan", "mariam@example.com", 21),
                    ("Ahmed Mohamed", "ahmed@example.com", 23),
                    ("Sara Adel", "sara@example.com", 20)
                );

            AddNewInstructor(
                    "Mohamed Ali",
                    "mohamed@example.com",
                    DateTime.Now,
                    context
                );

            AddNewInstructor(
                    "Omar Hassan",
                    "omar@example.com",
                    "Senior .NET Developer",
                    DateTime.Now,
                    context
                );

            AddNewCourse(
                    "C# Fundamentals",
                    "Learn C# from scratch.",
                    150,
                    CourseLevelEnum.Beginner,
                    true,
                    1,
                    1,
                    context
                );

            AddNewCourse(
                    "Advanced SQL",
                    200,
                    CourseLevelEnum.Advanced,
                    false,
                    2,
                    4,
                    context
                );

            EnrollStudentInCourse(1, 3, context);
            #endregion

            #region Read
            Console.WriteLine("\n========== READ OPERATIONS ==========");

            GetCourseById(1, context, out var courseById);
            if (courseById != null)
                Console.WriteLine($"Title: {courseById.Title}");

            GetCourseByTitle(
                    "Mobile Development",
                    context,
                    out var courseByTitle
                );
            if (courseByTitle != null)
                Console.WriteLine($"Price: {courseByTitle.Price}");

            GetCoursesByPriceRange(100, 250, context);

            GetSubCategoriesByCategoryId(1, context);

            GetTopLevelCategories(context);

            GetCourseStudentsByCourseId(3, context);

            #endregion

            #region Update
            Console.WriteLine("\n========== UPDATE OPERATIONS ==========");

            ChangeCoursePrice(1, 250, context);

            UpdateProgress(1, 3, 50, context);

            PublishCourse(2, context);
            #endregion

            #region Delete
            Console.WriteLine("\n========== DELETE OPERATIONS ==========");

            Unenroll(1, 3, context);

            DeleteCategory(1, context);

            TryDeleteCategory(2, context);

            DeleteCourse(1, context);
            #endregion

            Console.WriteLine("\nAll operations finished.");
            Console.ReadKey();
        }
    }
}
