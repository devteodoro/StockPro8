using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Models;

namespace StockPro.Infrastructure.Data.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // Tabela
            builder
                .ToTable("Address");

            // Chave Primária
            builder
                .HasKey(x => x.Id);

            // Identity
            builder
                .Property(u => u.Id)
                .UseIdentityColumn();

            // Propriedades
            builder
                .Property(p => p.CreatedDate)
                .HasColumnType("timestamp without time zone").IsRequired();

            builder
                .Property(x => x.ZipCode)
                .HasMaxLength(9);

            builder
                .Property(x => x.Country)
                .HasMaxLength(255);

            builder
                .Property(x => x.State)
                .HasMaxLength(255);

            builder
                .Property(x => x.City)
                .HasMaxLength(255);

            builder
                .Property(x => x.Street)
                .HasMaxLength(255);

            builder
                .Property(x => x.Number);

            builder
                .Property(x => x.Complement)
                .HasMaxLength(255);

            //RELACIONAMENTOS
            builder
                .HasOne(a => a.Client)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
