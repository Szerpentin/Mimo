using AutoMapper;
using MimoBackendChallenge.BL.IServices;
using MimoBackendChallenge.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimoBackendChallenge.BL.Services
{
    public class ObjectiveEvaluator : IObjectiveEvaluator
    {
        private readonly IUserLessonsService userLessonsService;
        private readonly IObjectivesService objectivesService;
        private readonly IChaptersService chaptersService;
        private readonly ICoursesService coursesService;
        private readonly IMapper mapper;
        public ObjectiveEvaluator(IUserLessonsService userLessonsService,
            IObjectivesService objectivesService,
            IChaptersService chaptersService,
            ICoursesService coursesService,
            IMapper mapper)
        {
            this.userLessonsService = userLessonsService;
            this.objectivesService = objectivesService;

            this.chaptersService = chaptersService;
            this.coursesService = coursesService;
            this.mapper = mapper;
        }
        public async Task<List<ObjectiveProgressModel>> GetAllObjectivesProgressByUser(int userId)
        {
            var finishedLessons = await userLessonsService.ByUserId(userId);
            var objectives = await objectivesService.GetAllAsync();

            var progresses = new List<ObjectiveProgressModel>();
            foreach (var objectiveModel in objectives)
            {
                progresses.Add(await ByObjectiveModel(objectiveModel, finishedLessons));
            }
            return progresses;
        }

        private async Task<ObjectiveProgressModel> ByObjectiveModel(ObjectiveModel objectiveModel, List<UserLessonsModel> finishedLessons)
        {
            var objectiveProgressModel = mapper.Map<ObjectiveProgressModel>(objectiveModel);
            var condition = Convert.ToInt32(objectiveProgressModel.Condition);
            var isAchieved = false;
            switch (objectiveModel.ObjectiveType)
            {
                case Database.Enums.ObjectiveType.LessonCount:
                    // The condition here is the number of finished lessons needed to achieve the objective
                    isAchieved = condition <= finishedLessons.Count;
                    objectiveProgressModel.Progress = isAchieved ? condition : finishedLessons.Count;
                    objectiveProgressModel.IsCompleted = isAchieved;

                    break;
                case Database.Enums.ObjectiveType.ChapterCount:

                    var finishedChaptersCount = (await GetFinishedChaptersByLessons(finishedLessons)).Count();
                    // The condition here is the number of finished courses needed to achieve the objective
                    isAchieved = condition <= finishedChaptersCount;
                    objectiveProgressModel.Progress = isAchieved ? condition : finishedChaptersCount;
                    objectiveProgressModel.IsCompleted = isAchieved;

                    break;
                case Database.Enums.ObjectiveType.SpecificCourse:
                    // The condition here is the ID of the course we check against
                    var courses = await coursesService.GetByIdAsync(condition);
                    var finishedChapters = await GetFinishedChaptersByLessons(finishedLessons);

                    if (courses.Chapters != null && courses.Chapters.Count > 0)
                    {
                        isAchieved = courses.Chapters.Select(s => s.Id).Intersect(finishedChapters.Select(s => s.Id)).Count() == courses.Chapters.Count();
                    }
                   
                    objectiveProgressModel.Progress = isAchieved ? 1 : 0;
                    objectiveProgressModel.IsCompleted = isAchieved;

                    break;
                default:
                    throw new ArgumentException($"Unknown objective type: {objectiveModel.ObjectiveType.ToString()}");
            }

            return objectiveProgressModel;
        }

        private async Task<List<ChapterModel>> GetFinishedChaptersByLessons(List<UserLessonsModel> finishedLessons)
        {
            var chapters = await chaptersService.GetAllAsync();
            var finishedChapters = new List<ChapterModel>();

            foreach (var chapter in chapters)
            {
                if (chapter.Lessons.Count > 0 && GetIfChapterIsFinished(chapter, finishedLessons)) finishedChapters.Add(chapter);
            }

            return finishedChapters;
        }

        private bool GetIfChapterIsFinished(ChapterModel chapterModel, List<UserLessonsModel> finishedLessons)
        {
            return chapterModel.Lessons.Select(s => s.Id).Intersect(finishedLessons.Select(s => s.Id)).Count() == chapterModel.Lessons.Count;
        }

        private bool GetICourseIsFinished(CourseModel courseModel, List<ChapterModel> finishedChapters)
        {
            return courseModel.Chapters.Select(s => s.Id).Intersect(finishedChapters.Select(s => s.Id)).Count() == courseModel.Chapters.Count;
        }
    }
}
