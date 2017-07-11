using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblRegisterMap : EntityTypeConfiguration<tblRegister>
    {
        public tblRegisterMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(200);

            this.Property(t => t.Mobile)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblRegister");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
