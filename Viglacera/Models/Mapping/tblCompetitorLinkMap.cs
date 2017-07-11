using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblCompetitorLinkMap : EntityTypeConfiguration<tblCompetitorLink>
    {
        public tblCompetitorLinkMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblCompetitorLink");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idHomes).HasColumnName("idHomes");
            this.Property(t => t.idCompetitor).HasColumnName("idCompetitor");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
