using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblCountOnlineMap : EntityTypeConfiguration<tblCountOnline>
    {
        public tblCountOnlineMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblCountOnline");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Online).HasColumnName("Online");
            this.Property(t => t.Sum).HasColumnName("Sum");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
        }
    }
}
