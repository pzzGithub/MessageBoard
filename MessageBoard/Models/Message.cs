using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageBoard.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public string MessageContent { get; set; }

        public int LastMessageId { get; set; }

        public int UserId { get; set; }

        public int TopicId { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual User User { get; set; }

        public virtual Topic Topic { get; set; }
       
    }
}