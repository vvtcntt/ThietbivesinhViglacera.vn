using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblOrderDetailMap : EntityTypeConfiguration<tblOrderDetail>
    {
        public tblOrderDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("tblOrderDetail");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idOrder).HasColumnName("idOrder");
            this.Property(t => t.idProduct).HasColumnName("idProduct");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Quantily).HasColumnName("Quantily");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.SumPrice).HasColumnName("SumPrice");
        }
    }
}
