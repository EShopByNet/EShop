using System;
using System.Collections.Generic;
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
        public string Id { get; set; }

        [Required(AllowEmptyStrings =false)]
        [Display(Name ="名称")]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "图片")]
        public string Image { get; set; }

        [Display(Name = "原价")]
        public double costPrice { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "价格")]
        public double Price
        {
            get { return Price; }
            set
            {
                if (value.Equals(null))
                {
                    Price = 0.00;
                }
                else
                {
                    Price = value;
                }
            }
        }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "描述")]
        public string Detail { get; set; }

        [Required(AllowEmptyStrings =false)]
        public int CatId { get; set; }

        [Required(AllowEmptyStrings =false)]
        public string DetailId { get; set; }

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