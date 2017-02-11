using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public string id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(128)]
        public string userId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(128)]
        public string goodsId { get; set; }

        [Required]
        [Display(Name ="数量")]
        public int number { get; set; }

        [Required]
        [Display(Name ="单价")]
        public double price { get; set; }

        [Required]
        [DefaultValue(OrderState.NotPaid)]
        public OrderState orderState { get; set; }

        [Display(Name = "收货人")]
        public string consigneeName { get; set; }

        [Display(Name = "收货地址")]
        public string consigneeAddress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "联系电话")]
        public string consigneePhone { get; set; }

        [Display(Name = "留言")]
        public string message { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="创建时间")]
        public DateTime createDate { get; set; }

        public static implicit operator List<object>(Order v)
        {
            throw new NotImplementedException();
        }
    }

    public enum OrderState
    {
        Canceled,
        NotPaid,
        Paid,
        Sending,
        Received,
        Completed,
        Commented,
        Invalid,
        Accounted,
        Ineffective

    }

}