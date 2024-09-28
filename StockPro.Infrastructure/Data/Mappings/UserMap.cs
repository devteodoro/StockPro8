using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Models;

namespace StockPro.Infrastructure.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Tabela
            builder
                .ToTable("User");

            // Chave Primária
            builder
                .HasKey(x => x.Id);

            // Identity
            builder
                .Property(u => u.Id)
                .UseIdentityColumn();

            // Propriedades
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder
                .Property(p => p.CreatedDate)
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder
                .Property(x => x.Login)
                .IsRequired()
                .HasColumnName("Login")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(160);

            builder
                .Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnName("PasswordHash")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder
                .Property(x => x.Profile)
                .IsRequired()
                .HasColumnName("Profile")
                .HasColumnType("INT");

            //RELACIONAMENTOS
            builder
                .HasOne(u => u.Preference)
                .WithOne(p => p.User)
                .HasForeignKey<UserPreference>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
