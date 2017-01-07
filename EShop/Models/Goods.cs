using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    /// <summary>
    /// 商品实体类
    /// </summary>
    [Table("Goods")]
    public class Goods
    {
        [Key]
        public string id { get; set; }

        [Required(AllowEmptyStrings =false)]
        [Display(Name ="名称")]
        [MaxLength(25)]
        public string name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "图片")]
        public string image { get; set; }

        [Display(Name = "原价")]
        [DefaultValue(0.00)]
        public double costPrice { get; set; }

        [Required]
        [Display(Name = "价格")]
        [DefaultValue(0.00)]
        public double price { get; set; }

        [Required(AllowEmptyStrings =false)]
        public int catId { get; set; }

        [Required(AllowEmptyStrings =false)]
        [Column(TypeName = "varchar")]
        [MaxLength(128)]
        public string detailId { get; set; }

        [NotMapped]
        public string detail { get; set; }

        public static implicit operator List<object>(Goods v)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 商品数据数据实体
    /// </summary>
    public class GoodsData
    {
        public Goods goods { get; set; }
        public List<Album> albums { get; set; }
    }
}