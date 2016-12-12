using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace EShop.Models
{

    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    /*
     * 创建Controller之前要先注释掉这句，否则会报错如下
     * Using the same DbCompiledModel to create contexts against different types 
     * of database servers is not supported. Instead, create a separate 
     * DbCompiledModel for each type of server being used.
     */
    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class EShopDbContext : IdentityDbContext<ApplicationUser>
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //移除Entity Framework建表时在表名后提交"s"的规约,使得表名可以通过[Table]注解来指定
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public EShopDbContext() : base("EShopDbContext")
        {
        }

        public static EShopDbContext Create()
        {
            return new EShopDbContext();
        }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<Cat> Cat { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Detail> Detail { get; set; }

        public DbSet<Member> Member { get; set; }

        public DbSet<Store> Store { get; set; }

    }
}
