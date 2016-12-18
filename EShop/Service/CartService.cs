using EShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EShop.Service
{
    public class CarService
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

        public async Task<bool> delete(string id)
        {
            Cart cart = await db.Cart.FindAsync(id);
            db.Cart.Remove(cart);
            try
            {
                await db.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                logger.Error("删除购物车错误：" + e.Message);
                return false;
            }
        }

    }
}