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
    [Table("Cart")]
    public class Cart
    {

        [Key]
        public string id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(128)]
        public string goodsId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(128)]
        public string userId { get; set; }

        [Required]
        [Display(Name ="数量")]
        public int number { get; set; }

        [Required]
        [Display(Name ="单价")]
        public double price { get; set; }

    }
}