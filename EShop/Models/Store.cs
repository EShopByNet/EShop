using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    [Table("store")]
    public class Store
    {

        [Key]
        public string id { get; set; }
        [Required]
        [Display(Name ="店铺名称")]
        [MaxLength(15)]
        public string name { get; set; }
        public string logo { get; set; }
        [Required]
        public string userId { get; set; }
        public int storeLv { get; set; }
        public int isDisable { get; set; }
        [Display(Name ="营业执照")]
        public string bussinessLicense { get; set; }
        [Display(Name ="联系电话")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
        [Display(Name ="通讯地址")]
        public string address { get; set; }
        [Display(Name ="描述")]
        public string descript { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        [Display(Name ="创建日期")]
        public DateTime createTime { get; set; }

    }
}