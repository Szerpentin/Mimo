using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MimoBackendChallenge.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    ObjectiveType = table.Column<int>(nullable: false),
                    Condition = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderIndex = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ObjectiveId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Achievements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderIndex = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    ChapterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Chapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLessons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    LessonId = table.Column<int>(nullable: false),
                    LessonStartTime = table.Column<DateTime>(nullable: false),
                    LessonSolvedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLessons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Title" },
                values: new object[] { -1, "Swift" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Title" },
                values: new object[] { -2, "Javascript" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Title" },
                values: new object[] { -3, "C#" });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "Condition", "ObjectiveType", "Title" },
                values: new object[] { -1, "5", 0, "Complete 5 lessons" });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "Condition", "ObjectiveType", "Title" },
                values: new object[] { -2, "25", 0, "Complete 25 lessons" });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "Condition", "ObjectiveType", "Title" },
                values: new object[] { -3, "60", 0, "Complete 50 lessons" });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "Condition", "ObjectiveType", "Title" },
                values: new object[] { -4, "1", 1, "Complete 1 chapter" });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "Condition", "ObjectiveType", "Title" },
                values: new object[] { -5, "5", 1, "Complete 5 chapeters" });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "Condition", "ObjectiveType", "Title" },
                values: new object[] { -6, "-1", 2, "Complete the Swift course" });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "Condition", "ObjectiveType", "Title" },
                values: new object[] { -7, "-2", 2, "Complete the Javascript course" });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "Condition", "ObjectiveType", "Title" },
                values: new object[] { -8, "-3", 2, "Complete the C# course" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { -1, "MimoUser1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { -2, "MimoUser2" });

            migrationBuilder.InsertData(
                table: "Chapters",
                columns: new[] { "Id", "CourseId", "OrderIndex", "Title" },
                values: new object[] { -1, -1, 0, "Swift First" });

            migrationBuilder.InsertData(
                table: "Chapters",
                columns: new[] { "Id", "CourseId", "OrderIndex", "Title" },
                values: new object[] { -2, -1, 1, "Swift Second" });

            migrationBuilder.InsertData(
                table: "Chapters",
                columns: new[] { "Id", "CourseId", "OrderIndex", "Title" },
                values: new object[] { -3, -1, 2, "Swift Third" });

            migrationBuilder.InsertData(
                table: "Chapters",
                columns: new[] { "Id", "CourseId", "OrderIndex", "Title" },
                values: new object[] { -4, -2, 0, "Javascript First" });

            migrationBuilder.InsertData(
                table: "Chapters",
                columns: new[] { "Id", "CourseId", "OrderIndex", "Title" },
                values: new object[] { -5, -2, 1, "Javascript Second" });

            migrationBuilder.InsertData(
                table: "Chapters",
                columns: new[] { "Id", "CourseId", "OrderIndex", "Title" },
                values: new object[] { -6, -3, 0, "C# First" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "ChapterId", "OrderIndex", "Title" },
                values: new object[] { -1, -1, 0, "Swift First Chapter One" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "ChapterId", "OrderIndex", "Title" },
                values: new object[] { -2, -1, 0, "Swift First Chapter Two" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "ChapterId", "OrderIndex", "Title" },
                values: new object[] { -3, -2, 0, "Swift Second Chapter One" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "ChapterId", "OrderIndex", "Title" },
                values: new object[] { -4, -2, 0, "Swift Second Chapter Two" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "ChapterId", "OrderIndex", "Title" },
                values: new object[] { -5, -3, 0, "Swift Third Chapter One" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "ChapterId", "OrderIndex", "Title" },
                values: new object[] { -6, -4, 0, "Javascript First Chapter One" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "ChapterId", "OrderIndex", "Title" },
                values: new object[] { -7, -5, 0, "Javascript Second Chapter One" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "ChapterId", "OrderIndex", "Title" },
                values: new object[] { -8, -6, 0, "C# First Chapter One" });

            migrationBuilder.InsertData(
                table: "UserLessons",
                columns: new[] { "Id", "LessonId", "LessonSolvedTime", "LessonStartTime", "UserId" },
                values: new object[] { -1, -1, new DateTime(2021, 3, 9, 14, 49, 5, 639, DateTimeKind.Utc).AddTicks(4431), new DateTime(2021, 3, 8, 14, 49, 5, 639, DateTimeKind.Utc).AddTicks(5064), -1 });

            migrationBuilder.InsertData(
                table: "UserLessons",
                columns: new[] { "Id", "LessonId", "LessonSolvedTime", "LessonStartTime", "UserId" },
                values: new object[] { -2, -1, new DateTime(2021, 3, 9, 14, 49, 5, 639, DateTimeKind.Utc).AddTicks(5656), new DateTime(2021, 3, 8, 14, 49, 5, 639, DateTimeKind.Utc).AddTicks(5666), -1 });

            migrationBuilder.InsertData(
                table: "UserLessons",
                columns: new[] { "Id", "LessonId", "LessonSolvedTime", "LessonStartTime", "UserId" },
                values: new object[] { -3, -2, new DateTime(2021, 3, 9, 14, 49, 5, 639, DateTimeKind.Utc).AddTicks(5680), new DateTime(2021, 3, 8, 14, 49, 5, 639, DateTimeKind.Utc).AddTicks(5681), -1 });

            migrationBuilder.InsertData(
                table: "UserLessons",
                columns: new[] { "Id", "LessonId", "LessonSolvedTime", "LessonStartTime", "UserId" },
                values: new object[] { -4, -3, new DateTime(2021, 3, 9, 14, 49, 5, 639, DateTimeKind.Utc).AddTicks(5683), new DateTime(2021, 3, 8, 14, 49, 5, 639, DateTimeKind.Utc).AddTicks(5684), -2 });

            migrationBuilder.InsertData(
                table: "UserLessons",
                columns: new[] { "Id", "LessonId", "LessonSolvedTime", "LessonStartTime", "UserId" },
                values: new object[] { -5, -3, new DateTime(2021, 3, 9, 14, 49, 5, 639, DateTimeKind.Utc).AddTicks(5685), new DateTime(2021, 3, 8, 14, 49, 5, 639, DateTimeKind.Utc).AddTicks(5686), -2 });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_ObjectiveId",
                table: "Achievements",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_UserId",
                table: "Achievements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_CourseId",
                table: "Chapters",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ChapterId",
                table: "Lessons",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLessons_LessonId",
                table: "UserLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLessons_UserId",
                table: "UserLessons",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "UserLessons");

            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
