using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblBaogiaMap : EntityTypeConfiguration<tblBaogia>
    {
        public tblBaogiaMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            this.Property(t => t.Tag)
                .HasMaxLength(100);

            this.Property(t => t.Title)
                .HasMaxLength(100);

            this.Property(t => t.Keyword)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("tblBaogia");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.Tag).HasColumnName("Tag");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Keyword).HasColumnName("Keyword");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
        }
    }
}
