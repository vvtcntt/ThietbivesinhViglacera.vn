using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class HistoryViewMap : EntityTypeConfiguration<HistoryView>
    {
        public HistoryViewMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.UserName)
                .HasMaxLength(50);

            this.Property(t => t.Task)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("HistoryView");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Task).HasColumnName("Task");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
        }
    }
}
