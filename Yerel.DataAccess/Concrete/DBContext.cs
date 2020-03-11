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
        public DbSet<DataTemp> DataTemps { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsersMap());
            modelBuilder.Configurations.Add(new DataTempsMap());
        }
    }
}

