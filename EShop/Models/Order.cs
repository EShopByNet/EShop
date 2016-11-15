using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    public class Order
    {
        [Key]
        public string id { get; set; }

        [Required]
        public int user_id { get; set; }

        [Required]
        public int goods_id { get; set; }

        [Required]
        public DateTime create_date { get; set; }
    }
}