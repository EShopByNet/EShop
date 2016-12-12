using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int GoodsId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="创建时间")]
        public DateTime CreateDate { get; set; }

        public static implicit operator List<object>(Order v)
        {
            throw new NotImplementedException();
        }
    }
}