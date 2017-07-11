using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblProductSynMap : EntityTypeConfiguration<tblProductSyn>
    {
        public tblProductSynMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.CodeSyn)
                .HasMaxLength(300);

            this.Property(t => t.Name)
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            this.Property(t => t.ImageLinkThumb)
                .HasMaxLength(255);

            this.Property(t => t.ImageLinkDetail)
                .HasMaxLength(200);

            this.Property(t => t.Warranty)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            this.Property(t => t.Access)
                .HasMaxLength(50);

            this.Property(t => t.Sale)
                .HasMaxLength(500);

            this.Property(t => t.Tag)
                .HasMaxLength(500);

            this.Property(t => t.Title)
                .HasMaxLength(200);

            this.Property(t => t.Keyword)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("tblProductSyn");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.CodeSyn).HasColumnName("CodeSyn");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Info).HasColumnName("Info");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.Parameter).HasColumnName("Parameter");
            this.Property(t => t.ImageLinkThumb).HasColumnName("ImageLinkThumb");
            this.Property(t => t.ImageLinkDetail).HasColumnName("ImageLinkDetail");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.PriceSale).HasColumnName("PriceSale");
            this.Property(t => t.Vat).HasColumnName("Vat");
            this.Property(t => t.Warranty).HasColumnName("Warranty");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Transport).HasColumnName("Transport");
            this.Property(t => t.Access).HasColumnName("Access");
            this.Property(t => t.Sale).HasColumnName("Sale");
            this.Property(t => t.Ord).HasColumnName("Ord");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.New).HasColumnName("New");
            this.Property(t => t.ViewHomes).HasColumnName("ViewHomes");
            this.Property(t => t.Visit).HasColumnName("Visit");
            this.Property(t => t.Tag).HasColumnName("Tag");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Keyword).HasColumnName("Keyword");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.idUser).HasColumnName("idUser");
        }
    }
}
