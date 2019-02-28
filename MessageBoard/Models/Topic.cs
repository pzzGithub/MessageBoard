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

        [Display(Name = "留言主题名")]
        [Required(ErrorMessage = "必填")]
        public string TopicTitle { get; set; }

        public string TopicDescription { get; set; }

        public int UserId { get; set; }

        [Display(Name = "添加时间")]
        [Required]
        public DateTime CreateTime { get; set; }

        public virtual User User { get; set; }
    }
}