using EShop.Models;
using System;
using System.Collections.Generic;
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
            // TODO 创建店铺
            return false;
        }

        /// <summary>
        /// 删除一个店铺
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> delete(string id)
        {
            // TODO 删除一个店铺
            return false;
        }

        /// <summary>
        /// 更新店铺
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task<bool> update(Store store)
        {
            // TODO 更新一个店铺
            return false;
        }

        /// <summary>
        /// 获取所有店铺
        /// </summary>
        /// <returns></returns>
        public async Task<List<Store>> findAll()
        {
            // TODO 查询所有店铺
            return null;
        }


    }
}