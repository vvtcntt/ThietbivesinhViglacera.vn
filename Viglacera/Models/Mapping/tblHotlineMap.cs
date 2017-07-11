using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblHotlineMap : EntityTypeConfiguration<tblHotline>
    {
        public tblHotlineMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Mobile)
                .HasMaxLength(100);

            this.Property(t => t.Hotline)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblHotline");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Hotline).HasColumnName("Hotline");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
