using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class WorkExperience
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string WorkName { get; set; }
        [Required]
        public string OrghanizationName { get; set; }
        [Required]
        [ForeignKey("User")]
        public virtual int UserId { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}
