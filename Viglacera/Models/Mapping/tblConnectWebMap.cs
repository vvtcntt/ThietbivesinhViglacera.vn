using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblConnectWebMap : EntityTypeConfiguration<tblConnectWeb>
    {
        public tblConnectWebMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblConnectWebs");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idWeb).HasColumnName("idWeb");
            this.Property(t => t.idCate).HasColumnName("idCate");
        }
    }
}
