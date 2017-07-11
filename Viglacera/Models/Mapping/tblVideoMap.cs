using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblVideoMap : EntityTypeConfiguration<tblVideo>
    {
        public tblVideoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(200);

            this.Property(t => t.Code)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("tblVideo");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.AutoPlay).HasColumnName("AutoPlay");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.idUser).HasColumnName("idUser");
        }
    }
}
