using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPro.Infrastructure.Data.Mappings
{
    public class ServiceOrderTechnicalMap : IEntityTypeConfiguration<ServiceOrderTechnical>
    {
        public void Configure(EntityTypeBuilder<ServiceOrderTechnical> builder)
        {
            // Tabela
            builder
                .ToTable("ServiceOrderTechnicals");

            // Chave Primária
            builder
                .HasKey(x => x.Id);

            // Identity
            builder
                .Property(u => u.Id)
                .UseIdentityColumn();
      
            //RELACIONAMENTOS
            builder
                .HasOne(sot => sot.ServiceOrder)
                .WithMany(so => so.ServiceOrderTechnicals)
                .HasForeignKey(sot => sot.ServiceOrderId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasOne(sot => sot.Technical)
                .WithMany(tec => tec.ServiceOrderTechnicals)
                .HasForeignKey(sot => sot.TechnicalId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasOne(sot => sot.Function)
                .WithMany(jb => jb.ServiceOrderTechnicals)
                .HasForeignKey(sot => sot.FunctionId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasMany(sot => sot.WorkHours)
                .WithOne(wh => wh.ServiceOrderTechnical)
                .HasForeignKey(wh => wh.ServiceOrderTechnicalId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
