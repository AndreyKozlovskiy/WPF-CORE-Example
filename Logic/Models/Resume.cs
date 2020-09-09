using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Resume
    {
        [Key]
        public int ResumeId { get; set; }
        [MaxLength(300)]
        public string ShortDescription { get; set; }
        [Required]
        [MaxLength(2000)]
        public string FullDescription { get; set; }
        [Required]
        public virtual User User { get; set; }
        [ForeignKey("User")]
        [Required]
        public virtual int UserId { get; set; }
      
        public DateTime Date { get; set; }
    }
}