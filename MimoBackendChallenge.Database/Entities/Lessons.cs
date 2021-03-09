using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MimoBackendChallenge.Database.Entities
{
    public class Lessons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderIndex { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        public int ChapterId { get; set; }
        [ForeignKey("ChapterId")]
        public virtual Chapters Chapter { get; set; }
    }
}
