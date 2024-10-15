using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Enums;
using StockPro.Domain.Models;

namespace StockPro.Infrastructure.Data.Mappings
{
    public class ServiceRequestMap : IEntityTypeConfiguration<ServiceRequest>
    {
        public void Configure(EntityTypeBuilder<ServiceRequest> builder)
        {
            // Tabela
            builder
                .ToTable("ServiceRequest");

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
                .Property(p => p.DateOccurrence)
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder
                .Property(x => x.RegisteredAsset)
                .IsRequired();

            builder
                .Property(x => x.InactiveAsset)
                .IsRequired();

            builder
                .Property(x => x.LocalNotRegistered)
                .HasMaxLength(255)
                .IsRequired(false);

            builder
                .Property(x => x.EquipmentNotRegistered)
                .HasMaxLength(255)
                .IsRequired(false);

            builder
                .Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder
                .Property(x => x.Criticality)
                .IsRequired()
                .HasConversion(
                   v => (int)v,
                   v => (Criticality)v);

            builder
                .Property(x => x.Status)
                .IsRequired()
                .HasConversion(
                   v => (int)v,
                   v => (StatusServiceRequest)v);

            //RELACIONAMENTOS
            builder
                .HasOne(sr => sr.Local)
                .WithMany(l => l.ServiceRequests)
                .HasForeignKey(sr => sr.LocalId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasOne(sr => sr.Equipment)
                .WithMany(e => e.ServiceRequests)
                .HasForeignKey(sr => sr.EquipamentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasOne(sr => sr.Client)
                .WithMany(c => c.ServiceRequests)
                .HasForeignKey(sr => sr.ClientId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasOne(sr => sr.Requester)
                .WithMany(r => r.ServiceRequests)
                .HasForeignKey(sr => sr.RequesterId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);


            builder
                .HasOne(sr => sr.ServiceOrder)
                .WithOne(so => so.ServiceRequest)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
