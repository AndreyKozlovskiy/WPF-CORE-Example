using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Vacancy
    {
        [Key]
        public virtual int VacancyId { get; set; }
        [MaxLength(300)]
        public virtual string ShortDescription { get; set; }
        [Required]
        [MaxLength(2000)]
        public virtual string FullDescription { get; set; }
        [Required]
        public virtual User User { get; set; }
        [Required]
        [ForeignKey("User")]
        public virtual int UserId { get; set; }

        public DateTime Date { get; set; }

    }
}