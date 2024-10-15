using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Models;

namespace StockPro.Infrastructure.Data.Mappings
{
    public class DepositMap : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            // Tabela
            builder.ToTable("Deposit");

            // Chave Primária
            builder
                .HasKey(x => x.Id);

            // Identity
            builder
                .Property(u => u.Id)
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            builder
                .Property(x => x.Code)
                .HasMaxLength(20);

            builder
                .Property(x => x.Description)
                .HasMaxLength(500);

            builder
                .Property(x => x.ZipCode)
                .HasMaxLength(14);

            builder
                .Property(x => x.State)
                .HasMaxLength(50);

            builder
                .Property(x => x.City)
                .HasMaxLength(50);

            builder
                .Property(x => x.Address)
                .HasMaxLength(500);

            builder
                .Property(x => x.Number)
                .HasMaxLength(10);

            builder
                .Property(x => x.Complement)
                .HasMaxLength(100);

            //RELACIONAMENTOS
            builder
                .HasOne(d => d.WorkCenter)
                .WithMany(wc => wc.Deposits)
                .HasForeignKey(a => a.WorkcenterId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
