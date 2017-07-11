using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblProductSaleMap : EntityTypeConfiguration<tblProductSale>
    {
        public tblProductSaleMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            this.Property(t => t.CodeOne)
                .HasMaxLength(500);

            this.Property(t => t.CodeTrue)
                .HasMaxLength(500);

            this.Property(t => t.CodeSale)
                .HasMaxLength(500);

            this.Property(t => t.Slogan)
                .HasMaxLength(200);

            this.Property(t => t.TextRun)
                .HasMaxLength(300);

            this.Property(t => t.ImageBanner)
                .HasMaxLength(200);

            this.Property(t => t.ImageSale)
                .HasMaxLength(200);

            this.Property(t => t.ImageThumb)
                .HasMaxLength(200);

            this.Property(t => t.Tag)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("tblProductSale");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CodeOne).HasColumnName("CodeOne");
            this.Property(t => t.CodeTrue).HasColumnName("CodeTrue");
            this.Property(t => t.CodeSale).HasColumnName("CodeSale");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.Slogan).HasColumnName("Slogan");
            this.Property(t => t.TextRun).HasColumnName("TextRun");
            this.Property(t => t.StartSale).HasColumnName("StartSale");
            this.Property(t => t.StopSale).HasColumnName("StopSale");
            this.Property(t => t.ImageBanner).HasColumnName("ImageBanner");
            this.Property(t => t.ImageSale).HasColumnName("ImageSale");
            this.Property(t => t.ImageThumb).HasColumnName("ImageThumb");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Tag).HasColumnName("Tag");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.UserID).HasColumnName("UserID");
        }
    }
}
