using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblCompetitorHomeMap : EntityTypeConfiguration<tblCompetitorHome>
    {
        public tblCompetitorHomeMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.CodeProduct)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("tblCompetitorHomes");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.CodeProduct).HasColumnName("CodeProduct");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.idUser).HasColumnName("idUser");
        }
    }
}
