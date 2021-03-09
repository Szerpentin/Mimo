using MimoBackendChallenge.Database.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MimoBackendChallenge.Database.Entities
{
    public class Objectives
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }
        public ObjectiveType ObjectiveType { get; set; }
        [Required]
        [MaxLength(200)]
        public string Condition { get; set; }
    }
}
