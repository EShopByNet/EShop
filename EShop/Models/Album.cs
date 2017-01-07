using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    [Table("Album")]
    public class Album
    {

        [Key]
        public string id { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(128)]
        public string goodsId { get; set; }
        public string small { get; set; }
        public string big { get; set; }
        public string tiny { get; set; }
        public string thumbnail { get; set; }
        public string original { get; set; }
        public bool isDefault { get; set; }

        public static implicit operator List<object>(Album v)
        {
            throw new NotImplementedException();
        }
    }
}