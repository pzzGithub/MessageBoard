using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageBoard.Models
{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }

        [Display(Name = "留言主题名")]
        [Required(ErrorMessage = "必填")]
        public string TopicTitle { get; set; }

        [Display(Name = "留言人")]
        [Required(ErrorMessage = "必填")]
        public int UserId { get; set; }

        [Display(Name = "添加时间")]
        [Required]
        public DateTime CreateTime { get; set; }

        public Topic(int topicId, string topicTitle, int userId, DateTime createTime)
        {
            TopicId = topicId;
            TopicTitle = topicTitle;
            UserId = userId;
            CreateTime = DateTime.Now;
        }

        public Topic()
        {
            TopicId = 0;
            TopicTitle = "";
            UserId = 0;
            CreateTime = DateTime.Now;
        }
    }
}