using MimoBackendChallenge.Database.Enums;

namespace MimoBackendChallenge.BL.Models
{
    public class ObjectiveModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ObjectiveType ObjectiveType { get; set; }
        public string Condition { get; set; }
    }
}
