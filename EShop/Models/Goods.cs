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

        [Display(Name = "备注")]
        [MaxLength(100)]
        public string remarks { get; set; }

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

        [Display(Name = "销量")]
        [DefaultValue(0)]
        public int selesCount { get; set; }

        [Display(Name = "累计评论")]
        [DefaultValue(0)]
        public int comment { get; set; }

        [Display(Name = "上月销量")]
        [DefaultValue(0)]
        public int sealCountAftermonth { get; set; }

        [Display(Name = "赞")]
        [DefaultValue(0)]
        public int praise { get; set; }

        [Display(Name = "收藏次数")]
        [DefaultValue(0)]
        public int collectCount { get; set; }

        [DefaultValue(0)]
        [Display(Name = "库存")]
        public int inventory { get; set; }

        [Display(Name = "产地")]
        public string area { get; set; }

        [Display(Name = "添加时间")]
        public string createTime { get; set; }

        [Display(Name = "发布时间")]
        public string publishTime { get; set; }

        [Display(Name = "修改时间")]
        public string modifyTime { get; set; }

        [Display(Name = "详情")]
        public string detail { get; set; }

        public static implicit operator List<object>(Goods v)
        {
            throw new NotImplementedException();
        }

        [Display(Name = "是否发布")]
        [DefaultValue(false)]
        public bool isPublish { get; set; }

        [Display(Name = "是否删除")]
        [DefaultValue(false)]
        public bool isDelete { get; set; }

    }


    /// <summary>
    /// 商品数据数据实体
    /// </summary>
    public class GoodsData
    {
        public Cat cat { get; set; }
        public Goods goods { get; set; }
        public List<Goods> goodsList { get; set; }
        public List<Album> albums { get; set; }
    }
}