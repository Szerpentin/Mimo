using Microsoft.EntityFrameworkCore;
using MimoBackendChallenge.Database.Entities;
using System;

using System.Collections.Generic;

namespace MimoBackendChallenge.Database
{
    public class MimoContext : DbContext
    {
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Achievements> Achievements { get; set; }
        public DbSet<Chapters> Chapters { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
        public DbSet<UserLessons> UserLessons { get; set; }
        public DbSet<Objectives> Objectives { get; set; }

        public MimoContext(DbContextOptions<MimoContext> dbContextOptions) : base(dbContextOptions)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
        }

        void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>().HasData(
                new Courses { Id = -1, Title = "Swift" },
                new Courses { Id = -2, Title = "Javascript" },
                new Courses { Id = -3, Title = "C#" }
                );

            modelBuilder.Entity<Chapters>().HasData(
                new Chapters { Id = -1, CourseId = -1, Title = "Swift First", OrderIndex = 0 },
                new Chapters { Id = -2, CourseId = -1, Title = "Swift Second", OrderIndex = 1 },
                new Chapters { Id = -3, CourseId = -1, Title = "Swift Third", OrderIndex = 2 },
                new Chapters { Id = -4, CourseId = -2, Title = "Javascript First", OrderIndex = 0 },
                new Chapters { Id = -5, CourseId = -2, Title = "Javascript Second", OrderIndex = 1 },
                new Chapters { Id = -6, CourseId = -3, Title = "C# First", OrderIndex = 0 }
                );

            modelBuilder.Entity<Lessons>().HasData(
                new Lessons { Id = -1, ChapterId = -1, OrderIndex = 0, Title = "Swift First Chapter One" },
                new Lessons { Id = -2, ChapterId = -1, OrderIndex = 0, Title = "Swift First Chapter Two" },
                new Lessons { Id = -3, ChapterId = -2, OrderIndex = 0, Title = "Swift Second Chapter One" },
                new Lessons { Id = -4, ChapterId = -2, OrderIndex = 0, Title = "Swift Second Chapter Two" },
                new Lessons { Id = -5, ChapterId = -3, OrderIndex = 0, Title = "Swift Third Chapter One" },
                new Lessons { Id = -6, ChapterId = -4, OrderIndex = 0, Title = "Javascript First Chapter One" },
                new Lessons { Id = -7, ChapterId = -5, OrderIndex = 0, Title = "Javascript Second Chapter One" },
                new Lessons { Id = -8, ChapterId = -6, OrderIndex = 0, Title = "C# First Chapter One" }
                );

            modelBuilder.Entity<Users>().HasData(
                new Users { Id = -1, UserName = "MimoUser1" },
                new Users { Id = -2, UserName = "MimoUser2" }
                );

            modelBuilder.Entity<Objectives>().HasData(
                new Objectives { Id = -1, Title = "Complete 5 lessons", ObjectiveType = Enums.ObjectiveType.LessonCount, Condition = "5" },
                new Objectives { Id = -2, Title = "Complete 25 lessons", ObjectiveType = Enums.ObjectiveType.LessonCount, Condition = "25" },
                new Objectives { Id = -3, Title = "Complete 50 lessons", ObjectiveType = Enums.ObjectiveType.LessonCount, Condition = "50" },
                new Objectives { Id = -4, Title = "Complete 1 chapter", ObjectiveType = Enums.ObjectiveType.ChapterCount, Condition = "1" },
                new Objectives { Id = -5, Title = "Complete 5 chapeters", ObjectiveType = Enums.ObjectiveType.ChapterCount, Condition = "5" },
                new Objectives { Id = -6, Title = "Complete the Swift course", ObjectiveType = Enums.ObjectiveType.SpecificCourse, Condition = "-1" },
                new Objectives { Id = -7, Title = "Complete the Javascript course", ObjectiveType = Enums.ObjectiveType.SpecificCourse, Condition = "-2" },
                new Objectives { Id = -8, Title = "Complete the C# course", ObjectiveType = Enums.ObjectiveType.SpecificCourse, Condition = "-3" }
                );

            modelBuilder.Entity<UserLessons>().HasData(
               new UserLessons { Id = -1, UserId = -1, LessonId = -1, LessonSolvedTime = DateTime.UtcNow, LessonStartTime = DateTime.UtcNow.AddDays(-1) },
               new UserLessons { Id = -2, UserId = -1, LessonId = -1, LessonSolvedTime = DateTime.UtcNow, LessonStartTime = DateTime.UtcNow.AddDays(-1) },
               new UserLessons { Id = -3, UserId = -1, LessonId = -2, LessonSolvedTime = DateTime.UtcNow, LessonStartTime = DateTime.UtcNow.AddDays(-1) },
               new UserLessons { Id = -4, UserId = -2, LessonId = -3, LessonSolvedTime = DateTime.UtcNow, LessonStartTime = DateTime.UtcNow.AddDays(-1) },
               new UserLessons { Id = -5, UserId = -2, LessonId = -3, LessonSolvedTime = DateTime.UtcNow, LessonStartTime = DateTime.UtcNow.AddDays(-1) }
               );
        }


    }
}
