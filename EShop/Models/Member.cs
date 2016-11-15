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
        public string id { get; set; }

        [Required]
        public string nick_name { get; set; }

        public string name { get; set; }

        public string sex { get; set; }

        public int age { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        public string address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string e_mail { get; set; }

        public string password { get; set; }

        public string salt { get; set; }

        public string old_password { get; set; }


    }
}