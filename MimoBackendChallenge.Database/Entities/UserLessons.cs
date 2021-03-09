using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MimoBackendChallenge.Database.Entities
{
    public class UserLessons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
        public int LessonId { get; set; }
        [ForeignKey("LessonId")]
        public virtual Lessons Lesson { get; set; }
        public DateTime LessonStartTime { get; set; }
        public DateTime? LessonSolvedTime { get; set; }
    }
}
