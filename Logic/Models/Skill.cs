using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic.Models
{
    public class Skill
    {
        [Key]
        public virtual int SkillId { get; set; }
        [Required]
        [MaxLength(50)]
        public virtual string SkillName { get; set; }
        [Required]
        public virtual Resume Resume { get; set; }
        [ForeignKey("Resume")]
        public virtual int ResumeId { get; set; }
    }
}
