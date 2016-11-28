using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Service
{
    /// <summary>
    /// 商品业务类
    /// </summary>
    public class GoodsService
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private EShopDbContext db = new EShopDbContext();

        /// <summary>
        /// 添加一个商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<bool> createGoods(Goods goods)
        {
            try
            {
                db.Goods.Add(goods);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 删除一个商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<bool> delete(string id)
        {
            try
            {
                Goods goods = await db.Goods.FindAsync(id);
                db.Goods.Remove(goods);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return false;
            }
            return true;
        }

    }
}