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

        public bool Add(Cart cart)
        {
            try
            {
                Goods goods = db.Goods.Find(cart.goodsId);
                cart.price = cart.number * goods.price;
                cart.id = Guid.NewGuid().ToString();
                db.Cart.Add(cart);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Error("购物车添加失败" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取所有购物车列表
        /// </summary>
        /// <returns></returns>
        public List<Cart> FindAll(string userID)
        {
            return db.Cart.Where(n=>n.userId.Equals(userID)).ToList();
        }

        /// <summary>
        /// 查询一条购物车信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Cart> FindOne(string id)
        {
            return await db.Cart.FindAsync(id);
        }

        public async Task<bool> Delete(string id)
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