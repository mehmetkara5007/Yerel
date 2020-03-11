using System.Data.Entity.ModelConfiguration;
using Yerel.Entities;

namespace Yerel.DataAccess.Concrete.Mapping
{
    public class UsersMap : EntityTypeConfiguration<User>
    {
        public UsersMap()
        {
            HasKey(t => t.Id);
            //properties
            ToTable("Users");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.Password).HasColumnName("Password");
        }
    }
}
