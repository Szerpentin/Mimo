using System;
using System.Collections.Generic;
using System.Text;

namespace MimoBackendChallenge.BL.Models
{
    public class UserLessonsBaseModel
    {
        public int UserId { get; set; }
        public int LessonId { get; set; }
        public DateTime LessonStartTime { get; set; }
        public DateTime? LessonSolvedTime { get; set; }
    }
}
