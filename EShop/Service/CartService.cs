using EShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EShop.Service
{
    public class CartService
    {

        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private EShopDbContext db = new EShopDbContext();

        /// <summary>
        /// 获取所有购物车列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<Cart>> findAll()
        {
            return await db.Cart.ToListAsync();
        }

        /// <summary>
        /// 查询一条购物车信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Cart> findOne(string id)
        {
            return await db.Cart.FindAsync(id);
        }

    }
}