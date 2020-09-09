using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Message
    {
        [Key]
        public virtual int MessageId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [MaxLength(300)]
        public virtual string Text { get; set; }
        public virtual DateTime When { get; set; }
        [Required]
        [ForeignKey("User")]
        public virtual int UserId { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}