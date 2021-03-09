using System.Collections.Generic;

namespace MimoBackendChallenge.BL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<AchievementModel> Achievements { get; set; }
    }
}
