using System.Collections.Generic;

namespace MimoBackendChallenge.BL.Models
{
    public class ChapterModel
    {
        public int Id { get; set; }
        public int OrderIndex { get; set; }
        public string Title { get; set; }
        public int CourseId { get; set; }
        public virtual CourseModel Course { get; set; }
        public virtual ICollection<LessonModel> Lessons { get; set; }
    }
}

