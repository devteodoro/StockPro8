using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Enums;
using StockPro.Domain.Models;


namespace StockPro.Infrastructure.Data.Mappings
{
    public class EquipamentMap : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            // Tabela
            builder
                .ToTable("User");

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
                .Property(x => x.TAG)
                .HasColumnName("TAG")
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.SerialNumber)
                .HasColumnName("SerialNumber")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(x => x.Status)
                .IsRequired()
                .HasConversion(
                   v => (int)v,
                   v => (StatusAssets)v
               );

            //RELACIONAMENTOS
            builder
                .HasOne(e => e.EquipmentModel)
                .WithMany(em => em.Equipments)
                .HasForeignKey(a => a.EquipmentModelId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder
                .HasOne(e => e.Local)
                .WithMany(l => l.Equipments)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasMany(e => e.ServiceRequests)
                .WithOne(sr => sr.Equipment)
                .HasForeignKey(sr => sr.EquipamentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
