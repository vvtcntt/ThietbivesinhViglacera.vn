using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblConnectCriteriaMap : EntityTypeConfiguration<tblConnectCriteria>
    {
        public tblConnectCriteriaMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblConnectCriteria");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idCre).HasColumnName("idCre");
            this.Property(t => t.idpd).HasColumnName("idpd");
        }
    }
}
