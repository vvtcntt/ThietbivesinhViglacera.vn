using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblBankMap : EntityTypeConfiguration<tblBank>
    {
        public tblBankMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(200);

            this.Property(t => t.Address)
                .HasMaxLength(500);

            this.Property(t => t.NameBank)
                .HasMaxLength(200);

            this.Property(t => t.NumberBank)
                .HasMaxLength(100);

            this.Property(t => t.Images)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblBanks");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.NameBank).HasColumnName("NameBank");
            this.Property(t => t.NumberBank).HasColumnName("NumberBank");
            this.Property(t => t.Images).HasColumnName("Images");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Ord).HasColumnName("Ord");
        }
    }
}
