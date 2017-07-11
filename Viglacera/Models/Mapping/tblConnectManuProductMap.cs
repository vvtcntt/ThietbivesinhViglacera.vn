using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblConnectManuProductMap : EntityTypeConfiguration<tblConnectManuProduct>
    {
        public tblConnectManuProductMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblConnectManuProduct");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idManu).HasColumnName("idManu");
            this.Property(t => t.idCate).HasColumnName("idCate");
        }
    }
}
