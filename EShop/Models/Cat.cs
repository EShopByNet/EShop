using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    /// <summary>
    /// 商品分类实体
    /// </summary>
    public class Cat
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int parent_id { get; set; }

        [Required]
        public string name { get; set; }

        public bool isShow { get; set; }

        public bool isDelete { get; set; }

    }
}