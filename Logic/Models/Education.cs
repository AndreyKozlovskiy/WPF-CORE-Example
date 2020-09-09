using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EducationName { get; set; }
        [Required]
        public string OrghanisationName { get; set; }
        [Required]
        [ForeignKey("User")]
        public virtual int UserId { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}
