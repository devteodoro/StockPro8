using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Enums;
using StockPro.Domain.Models;

namespace StockPro.Infrastructure.Data.Mappings
{
    public class ServiceOrderMap : IEntityTypeConfiguration<ServiceOrder>
    {
        public void Configure(EntityTypeBuilder<ServiceOrder> builder)
        {
            // Tabela
            builder
                .ToTable("ServiceOrder");

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
                .Property(p => p.CodeServiceOrder)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.RegisteredAsset)
                .IsRequired();

            builder
                .Property(x => x.LocalNotRegistered)
                .HasMaxLength(500)
                .IsRequired(false);

            builder
                .Property(x => x.EquipmentNotRegistered)
                .HasMaxLength(500)
                .IsRequired(false);

            builder
                .Property(x => x.ClientNotRegistered)
                .HasMaxLength(500)
                .IsRequired(false);

            builder
                .Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder
                .Property(x => x.Status)
                .IsRequired()
                .HasConversion(
                   v => (int)v,
                   v => (StatusServiceOrder)v);

            builder
                .Property(p => p.EstimatedStartDate)
                .IsRequired(false)
                .HasColumnType("timestamp without time zone");

            builder
                .Property(p => p.StartDate)
                .IsRequired(false)
                .HasColumnType("timestamp without time zone");

            builder
                .Property(p => p.EstimatedEndDate)
                .IsRequired(false)
                .HasColumnType("timestamp without time zone");

            builder
                .Property(p => p.EndDate)
                .IsRequired(false)
                .HasColumnType("timestamp without time zone");

            builder
                .Property(x => x.Criticality)
                .IsRequired()
                .HasConversion(
                   v => (int)v,
                   v => (Criticality)v);

            builder
                .Property(p => p.EstimatedValue)
                .IsRequired(false);

            builder
                .Property(x => x.Comments)
                .IsRequired(false);

            builder
                .Property(x => x.ClientFeedback)
                .IsRequired(false);

            //RELACIONAMENTOS
            builder
                .HasOne(sr => sr.Local)
                .WithMany(l => l.ServiceOrders)
                .HasForeignKey(sr => sr.LocalId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasOne(sr => sr.Equipment)
                .WithMany(e => e.ServiceOrders)
                .HasForeignKey(sr => sr.EquipamentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasOne(sr => sr.Client)
                .WithMany(c => c.ServiceOrders)
                .HasForeignKey(sr => sr.ClientId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasOne(sr => sr.ServiceRequest)
                .WithOne(r => r.ServiceOrder)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasMany(sr => sr.ServiceOrderTechnicals)
                .WithOne(sot => sot.ServiceOrder)
                .HasForeignKey(sot =>sot.ServiceOrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
