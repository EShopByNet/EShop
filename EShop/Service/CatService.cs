using EShop.Models;
using System;
using System.Collections.Generic;
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
        public async Task<Cat> create(Cat cat)
        {
            // TODO 添加商品分类信息方法
            return null;
        }

        /// <summary>
        /// 获取商品的所有分类
        /// </summary>
        /// <returns></returns>
        public async Task<Cat> findAll()
        {
            // TODO 分类获取方法
            return null;
        }

        /// <summary>
        /// 删除一个分类信息
        /// </summary>
        /// <param name="id">分类id</param>
        /// <returns></returns>
        public async Task<bool> delete(string id)
        {
            // TODO 商品分类信息删除方法
            return true;
        }

        /// <summary>
        /// 更新商品分类信息
        /// </summary>
        /// <param name="cat">商品分类信息对象</param>
        /// <returns></returns>
        public async Task<Cat> update(Cat cat)
        {
            // TODO 商品分类信息更新方法
            return null;
        }

        /// <summary>
        /// 商品分类查询商品信息
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public async Task<List<Goods>> search(string keyWords)
        {
            // TODO 商品分类查询商品方法
            return null;
        }

    }
}