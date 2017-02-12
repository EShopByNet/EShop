using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    [Table("OrderItem")]
    public class OrderItem
    {

        [Key]
        public string id { get; set; }

        [Required]
        public string orderid { get; set; }

        [Required]
        public string goodsId { get; set; }

        [DefaultValue(1)]
        [Display(Name = "数量")]
        public int number { get; set; }

        [Required]
        [Display(Name = "价格")]
        public double price { get; set; }

    }
}