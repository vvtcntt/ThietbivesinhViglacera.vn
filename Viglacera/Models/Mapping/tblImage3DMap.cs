using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblImage3DMap : EntityTypeConfiguration<tblImage3D>
    {
        public tblImage3DMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Images)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblImage3D");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idProduct).HasColumnName("idProduct");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Images).HasColumnName("Images");
        }
    }
}
