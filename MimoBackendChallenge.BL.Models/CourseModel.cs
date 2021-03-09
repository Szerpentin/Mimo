using System.Collections.Generic;

namespace MimoBackendChallenge.BL.Models
{
    public class CourseModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<ChapterModel> Chapters { get; set; }
    }
}
