using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Models;

namespace StockPro.Infrastructure.Data.Mappings
{
    public class WorkHoursMap : IEntityTypeConfiguration<WorkHours>
    {
        public void Configure(EntityTypeBuilder<WorkHours> builder)
        {
            // Tabela
            builder
                .ToTable("WorkHours");

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
                .Property(p => p.StartDate)
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder
                .Property(p => p.EndDate)
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder
                .Property(p => p.RealStartDate)
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder
                .Property(p => p.RealEndDate)
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            //RELACIONAMENTOS
            builder
                .HasOne(wh => wh.ServiceOrderTechnical)
                .WithMany(sot => sot.WorkHours)
                .HasForeignKey(wh => wh.ServiceOrderTechnicalId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

        }
    }
}
