using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MessageBoard.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        public string MessageContent { get; set; }

        public int? UserId { get; set; }

        [Required]
        public int TopicId { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        public virtual User User { get; set; }

        public virtual Topic Topic { get; set; }

    }
}