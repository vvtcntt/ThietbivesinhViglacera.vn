using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblGroupCriteriaMap : EntityTypeConfiguration<tblGroupCriteria>
    {
        public tblGroupCriteriaMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblGroupCriteria");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idCri).HasColumnName("idCri");
            this.Property(t => t.idCate).HasColumnName("idCate");
        }
    }
}
