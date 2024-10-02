
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPro.Domain.Models;

namespace StockPro.Infrastructure.Data.Mappings
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            // Tabela
            builder
                .ToTable("Contact");

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
                .Property(x => x.Email)
                .HasColumnName("FantasyName")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder
                .Property(x => x.Phone)
                .HasColumnName("CNPJ")
                .HasColumnType("VARCHAR")
                .HasMaxLength(15);

            //RELACIONAMENTOS
            builder
                .HasOne(c => c.Client)
                .WithMany(a => a.Contacts)
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
