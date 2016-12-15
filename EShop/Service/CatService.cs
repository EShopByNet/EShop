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
    /// 分类service
    /// </summary>
    public class CatService
    {

        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private EShopDbContext db = new EShopDbContext();

        /// <summary>
        /// 添加一个商品分类信息
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public async Task<bool> create(Cat cat)
        {
            try
            {
                db.Cat.Add(cat);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.Error("创建分类错误：" + e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取商品的所有分类
        /// </summary>
        /// <returns></returns>
        public async Task<List<Cat>> findAll()
        {
            return await db.Cat.ToListAsync();
        }

        /// <summary>
        /// 查询一条分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Cat> findOne(int id)
        {
            return await db.Cat.FindAsync(id);
        }

        /// <summary>
        /// 删除一个分类信息
        /// </summary>
        /// <param name="id">分类id</param>
        /// <returns></returns>
        public async Task<bool> delete(int id)
        {
            try
            {
                Cat cat = await db.Cat.FindAsync(id);
                db.Cat.Remove(cat);
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
        /// 更新商品分类信息
        /// </summary>
        /// <param name="cat">商品分类信息对象</param>
        /// <returns></returns>
        public async Task<Cat> update(Cat cat)
        {
            try
            {
                db.Entry(cat).State = EntityState.Modified;
                int x = await db.SaveChangesAsync();
                return await db.Cat.FindAsync(x);
            }
            catch (Exception e)
            {
                logger.Error("分类更新出错：" + e.Message);
                return null;
            }
        }

        /// <summary>
        /// 商品分类查询商品信息
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public async Task<List<Goods>> search(int id)
        {
                List<Goods> goods = await db.Goods.Where(n => n.CatId.Equals(id)).ToListAsync();
                return goods;
        }

    }
}