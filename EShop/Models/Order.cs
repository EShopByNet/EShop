using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public string id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(128)]
        public string uid { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(128)]
        public string userId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(128)]
        public string goodsId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="创建时间")]
        public DateTime createDate { get; set; }

        public static implicit operator List<object>(Order v)
        {
            throw new NotImplementedException();
        }
    }
}