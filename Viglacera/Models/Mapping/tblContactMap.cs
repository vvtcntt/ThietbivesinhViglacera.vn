using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblContactMap : EntityTypeConfiguration<tblContact>
    {
        public tblContactMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Address)
                .HasMaxLength(200);

            this.Property(t => t.Mobile)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblContact");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.idUser).HasColumnName("idUser");
        }
    }
}
