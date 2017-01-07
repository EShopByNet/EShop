using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    /// <summary>
    /// 商品分类实体
    /// </summary>
    [Table("Cat")]
    public class Cat
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int parentId { get; set; }

        [Required]
        [Display(Name ="名称")]
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string name { get; set; }

        [Display(Name ="是否显示")]
        public bool isShow { get; set; }

        [Display(Name ="是否删除")]
        public bool isDelete { get; set; }

        public static implicit operator List<object>(Cat v)
        {
            throw new NotImplementedException();
        }

    }
}