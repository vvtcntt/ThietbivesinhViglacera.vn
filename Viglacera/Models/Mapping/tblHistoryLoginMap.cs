using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblHistoryLoginMap : EntityTypeConfiguration<tblHistoryLogin>
    {
        public tblHistoryLoginMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.FullName)
                .HasMaxLength(50);

            this.Property(t => t.Task)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblHistoryLogin");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.Task).HasColumnName("Task");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
