using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblAgencyMap : EntityTypeConfiguration<tblAgency>
    {
        public tblAgencyMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(200);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            this.Property(t => t.Images)
                .HasMaxLength(200);

            this.Property(t => t.Address)
                .HasMaxLength(300);

            this.Property(t => t.Mobile)
                .HasMaxLength(50);

            this.Property(t => t.People)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Tabs)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("tblAgency");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idMenu).HasColumnName("idMenu");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.Images).HasColumnName("Images");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.People).HasColumnName("People");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Tag).HasColumnName("Tag");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Tabs).HasColumnName("Tabs");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.idUser).HasColumnName("idUser");
        }
    }
}
