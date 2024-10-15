using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Models;

namespace StockPro.Infrastructure.Data.Mappings
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            // Tabela
            builder
                .ToTable("Company");

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
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.CreatedDate)           
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            builder
                .Property(x => x.CNPJ)
                .HasMaxLength(18)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(x => x.Site)
                .HasMaxLength(150);

            builder
                .Property(x => x.ZipCode)
                .HasMaxLength(10);

            builder
                .Property(x => x.State)
                .HasMaxLength(50);

            builder
                .Property(x => x.City)
                .HasMaxLength(50);

            builder
                .Property(x => x.Address)
                .HasMaxLength(500);

            builder
                .Property(x => x.Number)
                .HasMaxLength(10);

            builder
                .Property(x => x.Complement)
                .HasMaxLength(100);

            builder
                .Property(x => x.ImageBase64)
                .HasColumnType("LONGBLOB");

            //Relacionamentos
            builder
                .HasMany(c => c.WorkCenters)
                .WithOne(wc => wc.Company)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            // Índice 
            builder.HasIndex(c => c.CNPJ).IsUnique();
        }
    }
}
