using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblConnectImageMap : EntityTypeConfiguration<tblConnectImage>
    {
        public tblConnectImageMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblConnectImages");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idImg).HasColumnName("idImg");
            this.Property(t => t.idCate).HasColumnName("idCate");
        }
    }
}
