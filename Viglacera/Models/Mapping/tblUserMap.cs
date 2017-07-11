using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Viglacera.Models.Mapping
{
    public class tblUserMap : EntityTypeConfiguration<tblUser>
    {
        public tblUserMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.FullName)
                .HasMaxLength(100);

            this.Property(t => t.UserName)
                .HasMaxLength(200);

            this.Property(t => t.Email)
                .HasMaxLength(500);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("tblUser");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.idModule).HasColumnName("idModule");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.idUser).HasColumnName("idUser");
        }
    }
}
