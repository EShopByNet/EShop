using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class Member
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string NickName { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public int Age { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string OldPassword { get; set; }


    }
    
    /// <summary>
    /// 用户注册实体
    /// </summary>
    public class RegisterViewModel
    {
        public string UserName { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// 忘记密码实体类
    /// </summary>
    public class forgetPassowrd
    {
        public string Phone { get; set; }
    }

    public class loginViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string RememberMe { get; set; }
    }

}