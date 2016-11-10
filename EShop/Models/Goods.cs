using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    /// <summary>
    /// 商品实体类
    /// </summary>
    public class Goods
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string name { get; set; }
    }
}