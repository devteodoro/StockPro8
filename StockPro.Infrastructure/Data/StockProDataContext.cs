using Microsoft.EntityFrameworkCore;
using StockPro.Domain.Models;
using StockPro.Infrastructure.Data.Mappings;

namespace StockPro.Infrastructure.Data
{
    public class StockProDataContext : DbContext
    {
        public StockProDataContext(DbContextOptions<StockProDataContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Client> Clients { get; set; }

        //public DbSet<JobFunction> Functions { get; set; }

        //public DbSet<EquipmentModel> EquipmentModels { get; set; }

        //public DbSet<Equipment> Equipments { get; set; }

        //public DbSet<Local> Locals { get; set; }

        //public DbSet<ServiceRequest> ServiceRequests { get; set; }

        //public DbSet<ServiceOrder> ServiceOrders { get; set; }

        //public DbSet<Technical> Technicals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new ContactMap());

            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockProDataContext).Assembly);
        }
    }
}
