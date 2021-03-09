namespace MimoBackendChallenge.BL.Models
{
    public class UserLessonsModel : UserLessonsBaseModel
    {
        public int Id { get; set; }
        public virtual UserModel User { get; set; }
        public virtual LessonModel Lesson { get; set; }
    }
}
