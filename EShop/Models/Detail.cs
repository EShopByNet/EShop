using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    [Table("Detail")]
    public class Detail
    {

        [Key]
        public string id { get; set; }

        [Display(Name ="描述")]
        [Column(TypeName = "text")]
        public string descript { get; set; }

        public string pics { get; set; }


    }
}