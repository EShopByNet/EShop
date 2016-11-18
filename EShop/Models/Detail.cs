using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    public class Detail
    {

        [Key]
        public string Id { get; set; }

        public string Descript { get; set; }

    }
}