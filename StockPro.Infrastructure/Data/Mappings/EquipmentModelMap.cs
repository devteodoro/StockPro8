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
                .ToTable("Client");

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
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(x => x.Brand)
                .HasColumnName("Brand")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired(false);

            builder
                .Property(x => x.EquipmentType)
                .HasColumnName("EquipmentType")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired(false);

            builder
                .Property(x => x.Weight)
                .HasColumnName("Weight")
                .HasColumnType("REAL")
                .IsRequired(false);

            builder
                .Property(x => x.OperatingVoltage)
                .HasColumnName("OperatingVoltage")
                .HasColumnType("VARCHAR")
                .HasMaxLength(10)
                .IsRequired(false);

            builder
                .Property(x => x.OperatingFrequency)
                .HasColumnName("OperatingFrequency")
                .HasColumnType("VARCHAR")
                .HasMaxLength(10)
                .IsRequired(false);

            builder
                .Property(x => x.Material)
                .HasColumnName("Material")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired(false);

            builder
                .Property(x => x.EstimatedLifespan)
                .HasColumnName("EstimatedLifespan")
                .HasColumnType("REAL")
                .IsRequired(false);

            builder
                .Property(x => x.RecommendedMaintenanceInterval)
                .HasColumnName("RecommendedMaintenanceInterval")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired(false);

            builder
                .Property(x => x.TechnicalDocumentation)
                .HasColumnName("TechnicalDocumentation")
                .HasColumnType("VARCHAR")
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
