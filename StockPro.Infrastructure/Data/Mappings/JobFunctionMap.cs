using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Models;

namespace StockPro.Infrastructure.Data.Mappings
{
    public class JobFunctionMap : IEntityTypeConfiguration<JobFunction>
    {
        public void Configure(EntityTypeBuilder<JobFunction> builder)
        {
            // Tabela
            builder
                .ToTable("JobFunction");

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
                .IsRequired(false)
                .HasColumnName("Description")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder
                .Property(x => x.HourlyRate)
                .IsRequired(false)
                .HasColumnName("HourlyRate")
                .HasColumnType("decimal(18,2)")
                .HasMaxLength(15);

            //RELACIONAMENTOS
            builder
                .HasOne(j => j.Technical)
                .WithOne(t => t.Function)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder
                .HasMany(j => j.ServiceOrderTechnicals)
                .WithOne(sot => sot.Function)
                .HasForeignKey(sot => sot.FunctionId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
