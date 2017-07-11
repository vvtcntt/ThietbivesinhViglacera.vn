using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblImageMap : EntityTypeConfiguration<tblImage>
    {
        public tblImageMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Images)
                .HasMaxLength(200);

            this.Property(t => t.Url)
                .HasMaxLength(500);

            this.Property(t => t.Color)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblImage");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idCate).HasColumnName("idCate");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Images).HasColumnName("Images");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Link).HasColumnName("Link");
            this.Property(t => t.Color).HasColumnName("Color");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.idUser).HasColumnName("idUser");
        }
    }
}
