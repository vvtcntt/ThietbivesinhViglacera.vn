using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblManufactureMap : EntityTypeConfiguration<tblManufacture>
    {
        public tblManufactureMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Tag)
                .HasMaxLength(50);

            this.Property(t => t.Images)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblManufactures");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Tag).HasColumnName("Tag");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Images).HasColumnName("Images");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Priority).HasColumnName("Priority");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.idUser).HasColumnName("idUser");
        }
    }
}
