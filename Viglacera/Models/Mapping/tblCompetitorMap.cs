using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblCompetitorMap : EntityTypeConfiguration<tblCompetitor>
    {
        public tblCompetitorMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(300);

            this.Property(t => t.Code)
                .HasMaxLength(500);

            this.Property(t => t.Website)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("tblCompetitor");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Website).HasColumnName("Website");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
        }
    }
}
