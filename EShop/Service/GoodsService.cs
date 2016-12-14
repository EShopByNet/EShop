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
    /// 商品业务类
    /// </summary>
    public class GoodsService
    {
        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private EShopDbContext db = new EShopDbContext();

        /// <summary>
        /// 添加一个商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public async Task<bool> createGoods(Goods goods)
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
        public async Task<bool> delete(string id)
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

        /// <summary>
        /// 保存一个商品的编辑
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public async Task<Goods> update(Goods goods)
        {
            try
            {
                db.Entry(goods).State = EntityState.Modified;
                int x = await db.SaveChangesAsync();
                return await db.Goods.FindAsync(x);
            }
            catch (Exception e)
            {
                logger.Error("商品更新出错：" + e.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询一个商品的信息信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Goods> findOne(string id)
        {
            Goods goods = await db.Goods.FindAsync(id);
            return goods;
        }

        /// <summary>
        /// 查询商品的所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<Goods>> findAll()
        {
            List<Goods> goods = await db.Goods.ToListAsync();
            return goods;
        }

        /// <summary>
        /// 分页查询商品数据
        /// </summary>
        /// <param name="pageSize">默认页面大小为20</param>
        /// <param name="pageNo">默认页面为第一页</param>
        /// <returns></returns>
        public async Task<List<Goods>> findByPage(int pageSize, int pageNo)
        {
            if (pageNo <= 0)
            {
                pageNo = Constants.PAGE_NO;
            }
            if (pageSize <= 0)
            {
                pageSize = Constants.PAGE_SIZE;
            }
            List<Goods> goods = await db.Goods.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
            return goods;
        }

        /// <summary>
        /// 商品的条件搜索
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public async Task<List<Goods>> search(string keyWords)
        {
            if (!string.IsNullOrWhiteSpace(keyWords) || !string.IsNullOrEmpty(keyWords))
            {
                List<Goods> goods = await db.Goods.Where(n => n.DetailId.Contains(keyWords)).Where(n => n.Name.Contains(keyWords)).ToListAsync();
                return goods;
            }
            else
            {
                return await findByPage(Constants.PAGE_SIZE, Constants.PAGE_NO);
            }
        }

    }
}