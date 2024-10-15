using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Models;

namespace StockPro.Infrastructure.Data.Mappings
{
    public class EquipmentModelMap : IEntityTypeConfiguration<EquipmentModel>
    {
        public void Configure(EntityTypeBuilder<EquipmentModel> builder)
        {
            // Tabela
            builder
                .ToTable("EquipmentModel");

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
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(x => x.Brand)
                .HasMaxLength(100)
                .IsRequired(false);

            builder
                .Property(x => x.EquipmentType)
                .HasMaxLength(100)
                .IsRequired(false);

            builder
                .Property(x => x.Weight)
                .IsRequired(false);

            builder
                .Property(x => x.OperatingVoltage)
                .HasMaxLength(10)
                .IsRequired(false);

            builder
                .Property(x => x.OperatingFrequency)
                .HasMaxLength(10)
                .IsRequired(false);

            builder
                .Property(x => x.Material)
                .HasMaxLength(100)
                .IsRequired(false);

            builder
                .Property(x => x.EstimatedLifespan)
                .IsRequired(false);

            builder
                .Property(x => x.RecommendedMaintenanceInterval)
                .HasMaxLength(100)
                .IsRequired(false);

            builder
                .Property(x => x.TechnicalDocumentation)
                .HasMaxLength(500)
                .IsRequired(false);

            //RELACIONAMENTOS
            builder
                .HasMany(em => em.Equipments)
                .WithOne(e => e.EquipmentModel)
                .HasForeignKey(e => e.EquipmentModelId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
