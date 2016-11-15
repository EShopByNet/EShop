using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    /// <summary>
    /// 购物车实体
    /// </summary>
    public class Cart
    {

        [Key]
        public string id { get; set; }

        public string goods_id { get; set; }

        public string user_id { get; set; }

        public int number { get; set; }

        public double price { get; set; }

    }
}