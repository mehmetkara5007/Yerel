using System.Data.Entity.ModelConfiguration;
using Yerel.Entities;

namespace Yerel.DataAccess.Concrete.Mapping
{
    public class StocksMap : EntityTypeConfiguration<Stock>
    {
        public StocksMap()
        {
            HasKey(t => t.store_id);
            //properties
            ToTable("production.stocks");
            Property(t => t.store_id).HasColumnName("store_id");
            Property(t => t.product_id).HasColumnName("product_id");
            Property(t => t.quantity).HasColumnName("quantity");
        }
    }
}
