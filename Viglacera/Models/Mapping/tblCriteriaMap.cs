using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblCriteriaMap : EntityTypeConfiguration<tblCriteria>
    {
        public tblCriteriaMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblCriteria");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idCate).HasColumnName("idCate");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Priority).HasColumnName("Priority");
            this.Property(t => t.Style).HasColumnName("Style");
            this.Property(t => t.Ord).HasColumnName("Ord");
        }
    }
}
