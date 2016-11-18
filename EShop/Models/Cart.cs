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
        public string Id { get; set; }

        public string GoodsId { get; set; }

        public string UserId { get; set; }

        public int Number { get; set; }

        public double Price { get; set; }

    }
}