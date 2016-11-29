using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    /// <summary>
    /// 商品实体类
    /// </summary>
    public class Goods
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Nane { get; set; }

        [Required]
        public int CatId{ get; set; }

        public string DetailId { get; set; }

        public static implicit operator List<object>(Goods v)
        {
            throw new NotImplementedException();
        }
    }
}