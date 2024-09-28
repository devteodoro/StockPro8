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
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder
                .Property(x => x.ZipCode)
                .HasColumnName("ZipCode")
                .HasColumnType("VARCHAR")
                .HasMaxLength(9);

            builder
                .Property(x => x.Country)
                .HasColumnName("State")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(x => x.State)
                .HasColumnName("State")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(x => x.City)
                .HasColumnName("City")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(x => x.Street)
                .HasColumnName("Street")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(x => x.Number)
                .HasColumnName("Number")
                .HasColumnType("INT");

            builder
                .Property(x => x.Complement)
                .HasColumnName("Complement")
                .HasColumnType("VARCHAR")
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
