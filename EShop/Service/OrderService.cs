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
    /// 订单service
    /// </summary>
    public class OrderService
    {

        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private EShopDbContext db = new EShopDbContext();

        /// <summary>
        /// 创建一个新的订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order> create(Order order)
        {
            // TODO 创建订单方法
            return null;
        }

        /// <summary>
        /// 删除一个订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> delete(string id)
        {
            // 删除一个订单
            return true;
        }

        /// <summary>
        /// 更新一条订单信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<Order> update(Order order)
        {
            // TODO 更新一条订单信息
            return null;
        }

        /// <summary>
        /// 查询一条订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Goods> findOne(string id)
        {
            return await db.Goods.FindAsync(id);
        }

        /// <summary>
        /// 查询所有订单
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> findAll()
        {
            List<Order> orders = await db.Order.ToListAsync();
            return orders;
        }

        /// <summary>
        /// 分页查询商品数据
        /// </summary>
        /// <param name="pageSize">默认页面大小为20</param>
        /// <param name="pageNo">默认页面为第一页</param>
        /// <returns></returns>
        public async Task<List<Order>> findByPage(int pageSize, int pageNo)
        {
            if (pageNo <= 0)
            {
                pageNo = Constants.PAGE_NO;
            }
            if (pageSize <= 0)
            {
                pageSize = Constants.PAGE_SIZE;
            }
            return await db.Order.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        /// <summary>
        /// 查询订单信息
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public async Task<List<Order>> search(string keyWords)
        {
            if (!string.IsNullOrWhiteSpace(keyWords) || !string.IsNullOrEmpty(keyWords))
            {
                List<Order> orders = await db.Order.ToListAsync();
                return orders;
            }
            else
            {
                return await findByPage(Constants.PAGE_SIZE, Constants.PAGE_NO);
            }
        }

    }
}