using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageBoard.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "用户名")]
        [Required(ErrorMessage = "必填")]
        public string Username { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "必填")]
        public string Password { get; set; }

        [Display(Name = "性别")]
        [Required]
        public string Sex { get; set; }

        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "必填")]
        public string Email { get; set; }

        [Display(Name = "注册时间")]
        [Required]
        public DateTime CreateTime { get; set; }
        
    }
}