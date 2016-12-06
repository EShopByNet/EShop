using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    /// <summary>
    /// 购物车实体
    /// </summary>
    [Table("cart")]
    public class Cart
    {

        [Key]
        public string Id { get; set; }

        [Required]
        public string GoodsId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Display(Name ="数量")]
        public int Number { get; set; }

        [Required]
        [Display(Name ="单价")]
        public double Price { get; set; }

    }
}