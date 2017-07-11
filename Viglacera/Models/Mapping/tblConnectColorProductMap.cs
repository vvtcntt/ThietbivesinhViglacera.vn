using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblConnectColorProductMap : EntityTypeConfiguration<tblConnectColorProduct>
    {
        public tblConnectColorProductMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblConnectColorProduct");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idColor).HasColumnName("idColor");
            this.Property(t => t.idPro).HasColumnName("idPro");
        }
    }
}
