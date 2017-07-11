using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblOrderMap : EntityTypeConfiguration<tblOrder>
    {
        public tblOrderMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(200);

            this.Property(t => t.Mobile)
                .HasMaxLength(100);

            this.Property(t => t.Mobiles)
                .HasMaxLength(100);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Name1)
                .HasMaxLength(50);

            this.Property(t => t.Address1)
                .HasMaxLength(200);

            this.Property(t => t.Mobile1)
                .HasMaxLength(100);

            this.Property(t => t.Mobile1s)
                .HasMaxLength(100);

            this.Property(t => t.Email1)
                .HasMaxLength(50);

            this.Property(t => t.NameCP)
                .HasMaxLength(200);

            this.Property(t => t.AddressCP)
                .HasMaxLength(20);

            this.Property(t => t.MST)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblOrder");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Mobiles).HasColumnName("Mobiles");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Name1).HasColumnName("Name1");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Mobile1).HasColumnName("Mobile1");
            this.Property(t => t.Mobile1s).HasColumnName("Mobile1s");
            this.Property(t => t.Email1).HasColumnName("Email1");
            this.Property(t => t.NameCP).HasColumnName("NameCP");
            this.Property(t => t.AddressCP).HasColumnName("AddressCP");
            this.Property(t => t.MST).HasColumnName("MST");
            this.Property(t => t.TypePay).HasColumnName("TypePay");
            this.Property(t => t.TypeTransport).HasColumnName("TypeTransport");
            this.Property(t => t.Tolar).HasColumnName("Tolar");
            this.Property(t => t.DateByy).HasColumnName("DateByy");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
