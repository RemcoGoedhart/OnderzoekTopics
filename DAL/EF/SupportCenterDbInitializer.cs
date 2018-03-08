using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SC.BL.Domain;

namespace SC.DAL.EF
{
    internal class SupportCenterDbInitializer : DropCreateDatabaseIfModelChanges<SupportCenterDbContext>
    {
        protected override void Seed(SupportCenterDbContext context)
        {
            #region Ticket 1
            var t1 = new Ticket()
            {
                AccountId = 1,
                Text = "Help, kan niet meer aanmelden",
                DateOpened = DateTime.Now.AddHours(-3194),
                State = TicketState.Open,
                Responses = new List<TicketResponse>()
            };
            context.Tickets.Add(t1);

            var t1r1 = new TicketResponse()
            {
                Ticket = t1,
                Text = "Ai, je account was geblokkeerd",
                Date = DateTime.Now.AddHours(-3192),
                IsClientResponse = false
            };
            t1.Responses.Add(t1r1);

            var t1r2 = new TicketResponse()
            {
                Ticket = t1,
                Text = "Account terug in orde en nieuw paswoord ingesteld",
                Date = DateTime.Now.AddHours(-3191),
                IsClientResponse = false
            };
            t1.Responses.Add(t1r2);

            var t1r3 = new TicketResponse()
            {
                Ticket = t1,
                Text = "Yihaa, alles werkt terug",
                Date = DateTime.Now.AddHours(-3188),
                IsClientResponse = true
            };
            t1.Responses.Add(t1r3);
            t1.State = TicketState.Closed;
            #endregion

            #region Ticket 2
            // Create second ticket with one response
            var t2 = new Ticket()
            {
                AccountId = 1,
                Text = "Kan niet meer surfen",
                DateOpened = DateTime.Now.AddHours(-50),
                State = TicketState.Open,
                Responses = new List<TicketResponse>()
            };
            context.Tickets.Add(t2);

            var t2r1 = new TicketResponse()
            {
                Ticket = t2,
                Text = "Ga naar zee, daar is er genoeg water en zijn er golven",
                Date = DateTime.Now.AddHours(-48),
                IsClientResponse = false
            };
            t2.Responses.Add(t2r1);
            t2.State = TicketState.Answered;
            #endregion

            #region Ticket 3
            var ht1 = new HardwareTicket()
            {
                AccountId = 2,
                Text = "Oeps, blue screen bij het aankoppelen aan een beamer",
                DateOpened = DateTime.Now.AddHours(-24.6),
                State = TicketState.Open,
                DeviceName = "PC-123456"
            };
            context.Tickets.Add(ht1);

            #endregion

            context.SaveChanges();

        }
    }
}
