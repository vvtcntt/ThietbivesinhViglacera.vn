using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblSupportMap : EntityTypeConfiguration<tblSupport>
    {
        public tblSupportMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Yahoo)
                .HasMaxLength(50);

            this.Property(t => t.Skyper)
                .HasMaxLength(50);

            this.Property(t => t.Mobile)
                .HasMaxLength(200);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.Mission)
                .HasMaxLength(50);

            this.Property(t => t.Images)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("tblSupport");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Yahoo).HasColumnName("Yahoo");
            this.Property(t => t.Skyper).HasColumnName("Skyper");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Mission).HasColumnName("Mission");
            this.Property(t => t.Images).HasColumnName("Images");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
        }
    }
}
