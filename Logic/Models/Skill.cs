using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        [Required]
        [MaxLength(50)]
        public string SkillName { get; set; }
        [Required]
        public virtual User User { get; set; }
        [ForeignKey("User")]
        [Required]
        public virtual int UserId { get; set; }
    }
}
