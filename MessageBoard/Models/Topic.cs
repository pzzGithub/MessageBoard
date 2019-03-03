using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MessageBoard.Models
{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }

        [Required]
        public string TopicTitle { get; set; }

        [Required]
        public string TopicDescription { get; set; }

        public int? UserId { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        public virtual User User { get; set; }
    }
}