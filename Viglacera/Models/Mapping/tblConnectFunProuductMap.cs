using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblConnectFunProuductMap : EntityTypeConfiguration<tblConnectFunProuduct>
    {
        public tblConnectFunProuductMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblConnectFunProuduct");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idFunc).HasColumnName("idFunc");
            this.Property(t => t.idPro).HasColumnName("idPro");
        }
    }
}
