using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblColorProductMap : EntityTypeConfiguration<tblColorProduct>
    {
        public tblColorProductMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Images)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblColorProduct");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Images).HasColumnName("Images");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Ord).HasColumnName("Ord");
        }
    }
}
