using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblGroupAgencyMap : EntityTypeConfiguration<tblGroupAgency>
    {
        public tblGroupAgencyMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Level)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblGroupAgency");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Tag).HasColumnName("Tag");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Level).HasColumnName("Level");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.idUser).HasColumnName("idUser");
        }
    }
}
