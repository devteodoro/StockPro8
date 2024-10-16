﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Models;

namespace StockPro.Infrastructure.Data.Mappings
{
    public class TechnicalMap : IEntityTypeConfiguration<Technical>
    {
        public void Configure(EntityTypeBuilder<Technical> builder)
        {
            // Tabela
            builder
                .ToTable("Technical");

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
                .Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(14);

            builder
                .Property(x => x.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(15);

            builder
                .Property(x => x.Email)
                .IsRequired(false)
                .HasMaxLength(160);

            //RELACIONAMENTOS
            builder
                .HasOne(t => t.Function)
                .WithOne(f => f.Technical)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
