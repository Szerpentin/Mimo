using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MimoBackendChallenge.BL.IServices;
using MimoBackendChallenge.BL.Models;
using MimoBackendChallenge.BL.Services;
using MimoBackendChallenge.Database.Enums;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimoBackendChallenge.UnitTests.BLTests
{
    [TestClass]
    public class ObjectiveEvaluatorTests
    {
        [TestMethod]
        public async Task GetAllObjectivesProgressByUser_UserSolvedTwoLessons_OneChapterObjectiveAchieved_AND_TwoLessonsObjectiveAtchived()
        {
            Mock<IUserLessonsService> userLessonsService = new Mock<IUserLessonsService>();
            Mock<IObjectivesService> objectivesService = new Mock<IObjectivesService>();
            Mock<IChaptersService> chaptersService = new Mock<IChaptersService>();
            Mock<ICoursesService> coursesService = new Mock<ICoursesService>();
            Mock<IMapper> mapper = new Mock<IMapper>();

            userLessonsService.Setup(s => s.ByUserId(It.IsAny<int>())).Returns(Task.FromResult(new List<UserLessonsModel>
            {
                new UserLessonsModel { Id = 1, LessonId = 1, UserId = 1 },
                new UserLessonsModel { Id = 2, LessonId = 2, UserId = 1 },
            }));

            var objectiveModels = new List<ObjectiveModel>
            {
                new ObjectiveModel{ Id = 1, ObjectiveType = ObjectiveType.LessonCount, Condition = "2", Title ="2 lessons"},
                new ObjectiveModel{ Id = 2, ObjectiveType = ObjectiveType.LessonCount, Condition = "10", Title ="10 lessons"},
                new ObjectiveModel{ Id = 3, ObjectiveType = ObjectiveType.ChapterCount, Condition = "1", Title ="1 chapter"},
            };

            objectivesService.Setup(s => s.GetAllAsync()).Returns(Task.FromResult(objectiveModels));

            chaptersService.Setup(s => s.GetAllAsync()).Returns(Task.FromResult(new List<ChapterModel>
            {
                new ChapterModel{ Lessons = new List<LessonModel> { new LessonModel{ Id = 1 }, new LessonModel{ Id = 2 } }, Id = 1 },
            }));
            // Real mapper should be used, not mocked
            mapper.Setup(s => s.Map<ObjectiveProgressModel>(objectiveModels[0])).Returns(new ObjectiveProgressModel
            {
                Id = 1,
                ObjectiveType = ObjectiveType.LessonCount,
                Condition = "2",
                Title = "2 lessons"
            });

            mapper.Setup(s => s.Map<ObjectiveProgressModel>(objectiveModels[1])).Returns(new ObjectiveProgressModel
            {
                Id = 2,
                ObjectiveType = ObjectiveType.LessonCount,
                Condition = "10",
                Title = "10 lessons",
            });

            mapper.Setup(s => s.Map<ObjectiveProgressModel>(objectiveModels[2])).Returns(new ObjectiveProgressModel
            {
                Id = 3,
                ObjectiveType = ObjectiveType.ChapterCount,
                Condition = "1",
                Title = "1 chapter"
            });

            var objectiveEvaluator = new ObjectiveEvaluator(userLessonsService.Object, objectivesService.Object, chaptersService.Object, coursesService.Object, mapper.Object);
            var results = await objectiveEvaluator.GetAllObjectivesProgressByUser(1);
            Assert.IsTrue(results.Count(c => c.IsCompleted) == 2);
        }
    }
}
