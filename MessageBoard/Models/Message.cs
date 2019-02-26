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

        public virtual User User { get; set; }

        public virtual Topic Topic { get; set; }

        public DateTime CreateTime { get; set; }

        public Message(int messageId, string messageContent, int lastMessageId, User user, Topic topic, DateTime createTime)
        {
            MessageId = messageId;
            MessageContent = messageContent;
            LastMessageId = lastMessageId;
            User = user;
            Topic = topic;
            CreateTime = DateTime.Now;
        }

        public Message()
        {
            CreateTime = DateTime.Now;
        }
    }
}