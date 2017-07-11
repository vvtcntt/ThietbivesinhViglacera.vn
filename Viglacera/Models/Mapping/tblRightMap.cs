using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblRightMap : EntityTypeConfiguration<tblRight>
    {
        public tblRightMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblRight");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idModule).HasColumnName("idModule");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.Role).HasColumnName("Role");
        }
    }
}
