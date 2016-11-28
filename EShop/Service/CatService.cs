using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Service
{
    /// <summary>
    /// 分类service
    /// </summary>
    public class CatService
    {

        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private EShopDbContext db = new EShopDbContext();

    }
}