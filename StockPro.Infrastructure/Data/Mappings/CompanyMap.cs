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
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder
                .Property(p => p.CreatedDate)
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder
                .Property(x => x.CNPJ)
                .IsRequired()
                .HasColumnName("CNPJ")
                .HasColumnType("VARCHAR")
                .HasMaxLength(18);

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150);

            builder
                .Property(x => x.Site)
                .HasColumnName("Site")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150);

            builder
                .Property(x => x.ZipCode)
                .HasColumnName("ZipCode")
                .HasColumnType("VARCHAR")
                .HasMaxLength(10);

            builder
                .Property(x => x.State)
                .HasColumnName("State")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder
                .Property(x => x.City)
                .HasColumnName("City")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder
                .Property(x => x.Address)
                .HasColumnName("Address")
                .HasColumnType("VARCHAR")
                .HasMaxLength(500);

            builder
                .Property(x => x.Number)
                .HasColumnName("Number")
                .HasColumnType("VARCHAR")
                .HasMaxLength(10);

            builder
                .Property(x => x.Complement)
                .HasColumnName("complement")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder
                .Property(x => x.ImageBase64)
                .HasColumnName("ImageBase64")
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
