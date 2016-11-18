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
        public string Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int GoodsId { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}