using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SC.BL.Domain;

namespace SC.DAL.EF
{
    [DbConfigurationType(typeof(SupportCenterDBConfiguration))]
    internal class SupportCenterDbContext : DbContext
    {
        public SupportCenterDbContext() : base("SC_DB_OLE")
        {
            Database.SetInitializer<SupportCenterDbContext>(new SupportCenterDbInitializer());
        }

        public DbSet<Ticket>  Tickets { get; set; }
        public DbSet<TicketResponse> TicketResponses { get; set; }
        public DbSet<HardwareTicket> HardwareTickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasKey(t => t.TicketNumber);
        }
    }
}
