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
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder
                .Property(p => p.CreatedDate)
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder
                .Property(x => x.Code)
                .HasColumnName("Code")
                .HasMaxLength(20);

            builder
                .Property(x => x.Description)
                .HasColumnName("Description")
                .HasMaxLength(500);

            builder
                .Property(x => x.ZipCode)
                .HasColumnName("ZipCode")
                .HasMaxLength(14);

            builder
                .Property(x => x.State)
                .HasColumnName("State")
                .HasMaxLength(50);

            builder
                .Property(x => x.City)
                .HasColumnName("City")
                .HasMaxLength(50);

            builder
                .Property(x => x.Address)
                .HasColumnName("Address")
                .HasMaxLength(500);

            builder
                .Property(x => x.Number)
                .HasColumnName("Number")
                .HasMaxLength(10);

            builder
                .Property(x => x.Complement)
                .HasColumnName("Complement")
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
