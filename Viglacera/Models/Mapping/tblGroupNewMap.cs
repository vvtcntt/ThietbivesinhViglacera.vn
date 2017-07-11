using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblGroupNewMap : EntityTypeConfiguration<tblGroupNew>
    {
        public tblGroupNewMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(300);

            this.Property(t => t.Title)
                .HasMaxLength(200);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            this.Property(t => t.Keyword)
                .HasMaxLength(300);

            this.Property(t => t.Tag)
                .HasMaxLength(300);

            this.Property(t => t.Images)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("tblGroupNews");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Keyword).HasColumnName("Keyword");
            this.Property(t => t.Tag).HasColumnName("Tag");
            this.Property(t => t.Index).HasColumnName("Index");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Images).HasColumnName("Images");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.idUser).HasColumnName("idUser");
        }
    }
}
