using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageBoard.Models
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        public int UserId { get; set; }

        public int MessageId { get; set; }

        public string ReplyContent { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual User User { get; set; }

        public virtual Message Message { get; set; }
    }
}