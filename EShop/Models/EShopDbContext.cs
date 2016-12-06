using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    /*
     * 创建Controller之前要先注释掉这句，否则会报错如下
     * Using the same DbCompiledModel to create contexts against different types 
     * of database servers is not supported. Instead, create a separate 
     * DbCompiledModel for each type of server being used.
     */
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class EShopDbContext : DbContext
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
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public EShopDbContext() : base("EShopDbContext")
        {
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
