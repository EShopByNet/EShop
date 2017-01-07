using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    [Table("Member")]
    public class Member
    {
        [Key]
        public string id { get; set; }

        [Required(AllowEmptyStrings =false)]
        [MaxLength(15)]
        [Display(Name ="昵称")]
        public string nickName { get; set; }

        [Display(Name ="姓名")]
        public string name { get; set; }

        [Display(Name ="性别")]
        public string sex { get; set; }

        [Display(Name ="年龄")]
        public int age { get; set; }

        [Display(Name ="电话号码")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        [Display(Name ="地址")]
        public string address { get; set; }

        [Display(Name ="电子邮件")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(AllowEmptyStrings =false)]
        [Display(Name ="密码")]
        public string password { get; set; }

        [Required]
        public string salt { get; set; }

        public string oldPassword { get; set; }


    }
    
    /// <summary>
    /// 用户注册实体
    /// </summary>
    public class RegisterViewModel
    {
        [Display(Name ="用户名")]
        [Required]
        [MaxLength(15)]
        public string UserName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name ="电话")]
        public string Phone { get; set; }

        [Display(Name ="电子邮件")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string email { get; set; }

        [Required]
        [Display(Name ="密码")]
        public string Password { get; set; }

        [Display(Name ="确认密码")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// 忘记密码实体类
    /// </summary>
    public class ForgetPassowrd
    {
        [Required(AllowEmptyStrings =false)]
        [Display(Name ="电话")]
        public string Phone { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name ="用户名")]
        [Required]
        [MaxLength(15)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings =false)]
        [Display(Name ="密码")]
        public string Password { get; set; }

        [Required]
        [Display(Name ="记住我")]
        public bool RememberMe { get; set; }
    }

}