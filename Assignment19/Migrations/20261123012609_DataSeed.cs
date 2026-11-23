using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment19.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "All programming related courses", "Programming", null },
                    { 4, "Courses related to data science", "Data Science", null }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "DateOfJoin", "EmailAddress", "FullName", "ShortBio" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tariq.mansour@example.edu", "Dr. Tariq Mansour", "Senior software engineer with 12 years of experience in .NET and distributed systems." },
                    { 2, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "nadia.elsayed@example.edu", "Nadia El-Sayed", null }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "EmailAddress", "FullName" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.hassan@student.edu", "Omar Hassan" },
                    { 2, new DateTime(2003, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "salma.ibrahim@student.edu", "Salma Ibrahim" },
                    { 3, new DateTime(2001, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef.adel@student.edu", "Youssef Adel" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "Courses related to web development", "Web Development", 1 },
                    { 3, "Courses related to mobile development", "Mobile Development", 1 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishingDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Learn the basics of programming using C#.", 1, false, "Beginner", 99.99m, null, "Introduction to Programming" },
                    { 4, 4, null, 2, false, "Beginner", 150.00m, null, "Intro To Data Science" },
                    { 2, 2, "Master advanced web development techniques using ASP.NET Core.", 2, false, "Advanced", 199.99m, null, "Advanced Web Development" },
                    { 3, 3, null, 1, true, "Beginner", 200.00m, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Development" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "EnrollmentDate", "FinalGrade", "ProgressPercentage", "Status" },
                values: new object[,]
                {
                    { 3, 1, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.50m, 100, "Completed" },
                    { 3, 2, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 40, "Active" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
