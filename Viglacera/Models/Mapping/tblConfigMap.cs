using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblConfigMap : EntityTypeConfiguration<tblConfig>
    {
        public tblConfigMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(500);

            this.Property(t => t.Logo)
                .HasMaxLength(200);

            this.Property(t => t.Favicon)
                .HasMaxLength(200);

            this.Property(t => t.Name)
                .HasMaxLength(500);

            this.Property(t => t.Address1)
                .HasMaxLength(500);
            this.Property(t => t.Address2)
             .HasMaxLength(500);

            this.Property(t => t.Mobile1)
                .HasMaxLength(500);

            this.Property(t => t.Mobile2)
                .HasMaxLength(50);

            this.Property(t => t.Hotline1)
                .HasMaxLength(500);

            this.Property(t => t.Hotline2)
                .HasMaxLength(50);
            this.Property(t => t.PbxDen)
               .HasMaxLength(50);
            this.Property(t => t.PbxGua)
                           .HasMaxLength(50);
            this.Property(t => t.PbxSell)
                           .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Slogan)
                .HasMaxLength(200);

            this.Property(t => t.Authorship)
                .HasMaxLength(500);

            this.Property(t => t.FanpageFacebook)
                .HasMaxLength(500);

            this.Property(t => t.FanpageGoogle)
                .HasMaxLength(300);

            this.Property(t => t.FanpageYoutube)
                .HasMaxLength(300);

            this.Property(t => t.AppFacebook)
                .HasMaxLength(300);

            this.Property(t => t.Analytics)
                .HasMaxLength(300);

            this.Property(t => t.GoogleMaster)
                .HasMaxLength(300);

            this.Property(t => t.GeoMeta)
                .HasMaxLength(500);

            this.Property(t => t.DMCA)
                .HasMaxLength(300);

            this.Property(t => t.CodeChat)
                .HasMaxLength(500);

            this.Property(t => t.BCT)
                .HasMaxLength(300);

            this.Property(t => t.BNI)
                .HasMaxLength(300);

            this.Property(t => t.SKH)
                .HasMaxLength(300);

            this.Property(t => t.UserEmail)
                .HasMaxLength(50);

            this.Property(t => t.PassEmail)
                .HasMaxLength(200);

            this.Property(t => t.Host)
                .HasMaxLength(200);

            this.Property(t => t.Color)
                .HasMaxLength(50);
            this.Property(t => t.TitleSale)
              .HasMaxLength(50);
            this.Property(t => t.ImageSale)
                .HasMaxLength(50);
            this.Property(t => t.TimeWork)
            .HasMaxLength(50);
            // Table & Column Mappings
            this.ToTable("tblConfig");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Keywords).HasColumnName("Keywords");
            this.Property(t => t.Logo).HasColumnName("Logo");
            this.Property(t => t.Favicon).HasColumnName("Favicon");
            this.Property(t => t.Popup).HasColumnName("Popup");
            this.Property(t => t.PopupSupport).HasColumnName("PopupSupport");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.Mobile1).HasColumnName("Mobile1");
            this.Property(t => t.Mobile2).HasColumnName("Mobile2");
            this.Property(t => t.Hotline1).HasColumnName("Hotline1");
            this.Property(t => t.Hotline2).HasColumnName("Hotline2");
            this.Property(t => t.PbxSell).HasColumnName("PbxSell");
            this.Property(t => t.PbxGua).HasColumnName("PbxGua");
            this.Property(t => t.PbxDen).HasColumnName("PbxDen");

            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Slogan).HasColumnName("Slogan");
            this.Property(t => t.Authorship).HasColumnName("Authorship");
            this.Property(t => t.FanpageFacebook).HasColumnName("FanpageFacebook");
            this.Property(t => t.FanpageGoogle).HasColumnName("FanpageGoogle");
            this.Property(t => t.FanpageYoutube).HasColumnName("FanpageYoutube");
            this.Property(t => t.AppFacebook).HasColumnName("AppFacebook");
            this.Property(t => t.Analytics).HasColumnName("Analytics");
            this.Property(t => t.GoogleMaster).HasColumnName("GoogleMaster");
            this.Property(t => t.GeoMeta).HasColumnName("GeoMeta");
            this.Property(t => t.DMCA).HasColumnName("DMCA");
            this.Property(t => t.CodeChat).HasColumnName("CodeChat");
            this.Property(t => t.BCT).HasColumnName("BCT");
            this.Property(t => t.BNI).HasColumnName("BNI");
            this.Property(t => t.SKH).HasColumnName("SKH");
            this.Property(t => t.Coppy).HasColumnName("Coppy");
            this.Property(t => t.Social).HasColumnName("Social");
            this.Property(t => t.UserEmail).HasColumnName("UserEmail");
            this.Property(t => t.PassEmail).HasColumnName("PassEmail");
            this.Property(t => t.Host).HasColumnName("Host");
            this.Property(t => t.Port).HasColumnName("Port");
            this.Property(t => t.Color).HasColumnName("Color");
            this.Property(t => t.Timeout).HasColumnName("Timeout");
            this.Property(t => t.Language).HasColumnName("Language");
            this.Property(t => t.TitleSale).HasColumnName("TitleSale");
            this.Property(t => t.StartDateSale).HasColumnName("StartDateSale");
            this.Property(t => t.EndDateSale).HasColumnName("EndDateSale");
            this.Property(t => t.EndDateSale).HasColumnName("EndDateSale");
            this.Property(t => t.ImageSale).HasColumnName("ImageSale");
            this.Property(t => t.TimeWork).HasColumnName("TimeWork");
        }
    }
}
