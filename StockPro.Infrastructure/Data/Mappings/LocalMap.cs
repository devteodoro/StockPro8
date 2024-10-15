using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Enums;
using StockPro.Domain.Models;
using System.Data;


namespace StockPro.Infrastructure.Data.Mappings
{
    public class LocalMap : IEntityTypeConfiguration<Local>
    {
        public void Configure(EntityTypeBuilder<Local> builder)
        {
            // Tabela
            builder
                .ToTable("Local");

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
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.TAG)
                .IsRequired()
                .HasMaxLength(15);

            builder
                .Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(255);

            builder
                .Property(x => x.Status)
                .IsRequired()
                .HasConversion(
                    v => (int)v,
                    v => (StatusAssets)v);

            //RELACIONAMENTOS
            builder
                .HasMany(l => l.Equipments)
                .WithOne(e => e.Local)
                .HasForeignKey(e => e.LocalId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder
                .HasMany(l => l.ServiceRequests)
                .WithOne(sr => sr.Local)
                .HasForeignKey(sr => sr.LocalId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
