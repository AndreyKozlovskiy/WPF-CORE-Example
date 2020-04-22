using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic.Models
{
    public class Resume
    {
        public Resume()
        {
            Skills = new List<Skill>();
        }

        [Key]
        public virtual int ResumeId { get; set; }
        [MaxLength(300)]
        public virtual string ShortDescription { get; set; }
        [Required]
        [MaxLength(2000)]
        public virtual string FullDescription { get; set; }
        [Required]
        public virtual User User { get; set; }
        [ForeignKey("User")]
        public virtual int UserId { get; set; }
        public virtual List<Skill> Skills { get; set; }
    }
}
