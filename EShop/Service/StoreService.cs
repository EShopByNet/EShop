using EShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EShop.Service
{
    /// <summary>
    /// 店铺service
    /// </summary>
    public class StoreService
    {

        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private EShopDbContext db = new EShopDbContext();

        /// <summary>
        /// 创建一个店铺
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task<bool> create(Store store)
        {
            try
            {
                db.Store.Add(store);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Error("创建店铺错误：" + e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 删除一个店铺
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> delete(string id)
        {
            try
            {
                Store store = await db.Store.FindAsync(id);
                db.Store.Remove(store);
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
        /// 更新店铺
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task<Store> update(Store store)
        {
            try
            {
                db.Entry(store).State = EntityState.Modified;
                int x = await db.SaveChangesAsync();
                return await db.Store.FindAsync(x);
            }
            catch (Exception e)
            {
                logger.Error("店铺更新出错：" + e.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取所有店铺
        /// </summary>
        /// <returns></returns>
        public async Task<List<Store>> findAll()
        {
            List<Store> store = await db.Store.ToListAsync();
            return store;
        }


    }
}