using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    /// <summary>
    /// 商品分类实体
    /// </summary>
    public class Cat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ParentId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsShow { get; set; }

        public bool IsDelete { get; set; }

        public static implicit operator List<object>(Cat v)
        {
            throw new NotImplementedException();
        }

    }
}