using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblGroupProductMap : EntityTypeConfiguration<tblGroupProduct>
    {
        public tblGroupProductMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(255);

            this.Property(t => t.Title)
                .HasMaxLength(255);

            this.Property(t => t.Note)
                .HasMaxLength(200);

            this.Property(t => t.Images)
                .HasMaxLength(300);

            this.Property(t => t.Background)
                .HasMaxLength(200);

            this.Property(t => t.iCon)
                .HasMaxLength(250);

            this.Property(t => t.Color)
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblGroupProduct");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Keyword).HasColumnName("Keyword");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Tag).HasColumnName("Tag");
            this.Property(t => t.Priority).HasColumnName("Priority");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.Images).HasColumnName("Images");
            this.Property(t => t.Background).HasColumnName("Background");
            this.Property(t => t.iCon).HasColumnName("iCon");
            this.Property(t => t.Color).HasColumnName("Color");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.idUser).HasColumnName("idUser");
        }
    }
}
