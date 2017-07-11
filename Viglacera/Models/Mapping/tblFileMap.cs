using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblFileMap : EntityTypeConfiguration<tblFile>
    {
        public tblFileMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(70);

            this.Property(t => t.Title)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(250);

            this.Property(t => t.Keywork)
                .HasMaxLength(250);

            this.Property(t => t.File)
                .HasMaxLength(250);

            this.Property(t => t.Image)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("tblFiles");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Keywork).HasColumnName("Keywork");
            this.Property(t => t.File).HasColumnName("File");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Cate).HasColumnName("Cate");
            this.Property(t => t.idp).HasColumnName("idp");
            this.Property(t => t.idg).HasColumnName("idg");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.idUser).HasColumnName("idUser");
        }
    }
}
