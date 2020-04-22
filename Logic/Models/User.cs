using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Logic.Models
{
    public class User
    {
        public User()
        {
            Vacancies = new List<Vacancy>();
            Resumes = new List<Resume>();
            Messages = new List<Message>();
        }

        [Key]
        public virtual int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public virtual string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public virtual string Password { get; set; }
        [Required]
        [MaxLength(100)]
        public virtual string Mail { get; set; }
        [Required]
        [MaxLength(200)]
        public virtual string FirstName { get; set; }
        [Required]
        [MaxLength(200)]
        public string SecondName { get; set; }
        [Required]
        [MaxLength(100)]
        public virtual string City { get; set; }
        public virtual List<Vacancy> Vacancies { get; set; }
        public virtual List<Resume> Resumes { get; set; }
        public virtual List<Message> Messages { get; set; }
    }
}
