using System.Data.Entity;
using Yerel.DataAccess.Concrete.Mapping;
using Yerel.Entities;

namespace Yerel.DataAccess.Concrete
{
    public partial class DBContext : DbContext
    {
        static DBContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DBContext>());
        }

        public DBContext()
            : base("Name=DBContext")
        {
        }
        public DbSet<Product> Prodcuts { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductsMap());
            modelBuilder.Configurations.Add(new StocksMap());
        }
    }
}

