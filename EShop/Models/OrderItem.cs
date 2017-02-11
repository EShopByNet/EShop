using System;
using System.Collections.Generic;
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

        public string goodsId { get; set; }

    }
}