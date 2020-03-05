using System.Data.Entity.ModelConfiguration;
using Yerel.Entities;

namespace Yerel.DataAccess.Concrete.Mapping
{
    public class ProductsMap : EntityTypeConfiguration<Product>
    {
        public ProductsMap()
        {
            HasKey(t => t.Id);
            //properties
            ToTable("production.products");
            Property(t => t.Id).HasColumnName("product_id");
            Property(t => t.Brand).HasColumnName("brand_id");
            Property(t => t.Name).HasColumnName("product_name");
            Property(t => t.Category).HasColumnName("category_id");
            Property(t => t.Year).HasColumnName("model_year");
            Property(t => t.Price).HasColumnName("list_price");

        }
    }
}
