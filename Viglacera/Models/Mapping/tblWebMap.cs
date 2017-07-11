using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblWebMap : EntityTypeConfiguration<tblWeb>
    {
        public tblWebMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Url)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblWeb");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.Ord).HasColumnName("Ord");
        }
    }
}
