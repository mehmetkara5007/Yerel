using System.Data.Entity.ModelConfiguration;
using Yerel.Entities;

namespace Yerel.DataAccess.Concrete.Mapping
{
    public class DataTempsMap : EntityTypeConfiguration<DataTemp>
    {
        public DataTempsMap()
        {
            HasKey(t => t.Id);
            //properties
            ToTable("DataTemps");
            Property(t => t.DataAws).HasColumnName("DataAws");
            Property(t => t.SaveDate).HasColumnName("SaveDate");
        }
    }
}
