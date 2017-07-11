using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblIntroductionMap : EntityTypeConfiguration<tblIntroduction>
    {
        public tblIntroductionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblIntroduction");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.iView).HasColumnName("iView");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
        }
    }
}
