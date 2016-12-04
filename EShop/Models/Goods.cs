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

        [Required(AllowEmptyStrings =false)]
        [Display(Name ="名称")]
        [MaxLength(25)]
        public string Nane { get; set; }

        [Required(AllowEmptyStrings =false)]
        public int CatId{ get; set; }

        [Required(AllowEmptyStrings =false)]
        public string DetailId { get; set; }

        public static implicit operator List<object>(Goods v)
        {
            throw new NotImplementedException();
        }
    }
}