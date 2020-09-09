using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User
    {
        public User()
        {
            Vacancies = new List<Vacancy>();
            Resumes = new List<Resume>();
            Messages = new List<Message>();
            Educations = new List<Education>();
            WorkExperiences = new List<WorkExperience>();
            Educations = new List<Education>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(100)]
        public string Mail { get; set; }
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(200)]
        public string SecondName { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        public bool? IsAdmin { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
    }
}