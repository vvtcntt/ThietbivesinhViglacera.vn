using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblGroupImageMap : EntityTypeConfiguration<tblGroupImage>
    {
        public tblGroupImageMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblGroupImage");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
        }
    }
}
