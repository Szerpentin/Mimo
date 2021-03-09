namespace MimoBackendChallenge.BL.Models
{
    public class AchievementModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ObjectiveId { get; set; }
        public int UserId { get; set; }
    }
}
