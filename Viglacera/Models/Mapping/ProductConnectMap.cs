using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class ProductConnectMap : EntityTypeConfiguration<ProductConnect>
    {
        public ProductConnectMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.idpd)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ProductConnect");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idSyn).HasColumnName("idSyn");
            this.Property(t => t.idpd).HasColumnName("idpd");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.Parameter).HasColumnName("Parameter");
        }
    }
}
