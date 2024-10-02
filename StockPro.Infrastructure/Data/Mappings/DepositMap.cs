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
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder
                .Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("VARCHAR")
                .HasMaxLength(500);

            builder
                .Property(x => x.ZipCode)
                .HasColumnName("ZipCode")
                .HasColumnType("VARCHAR")
                .HasMaxLength(14);

            builder
                .Property(x => x.State)
                .HasColumnName("State")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder
                .Property(x => x.City)
                .HasColumnName("City")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder
                .Property(x => x.Address)
                .HasColumnName("Address")
                .HasColumnType("VARCHAR")
                .HasMaxLength(500);

            builder
                .Property(x => x.Number)
                .HasColumnName("Number")
                .HasColumnType("VARCHAR")
                .HasMaxLength(10);

            builder
                .Property(x => x.Complement)
                .HasColumnName("Complement")
                .HasColumnType("NVARCHAR")
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
