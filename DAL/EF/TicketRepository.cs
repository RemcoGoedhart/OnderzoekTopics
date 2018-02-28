using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SC.BL.Domain;

namespace SC.DAL.EF
{
    public class TicketRepository : ITicketRepository
    {
        private SupportCenterDbContext ctx;

        public TicketRepository()
        {
            ctx = new SupportCenterDbContext();
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            ctx.Tickets.Add(ticket);
            ctx.SaveChanges();
            return ticket;
        }

        public TicketResponse CreateTicketResponse(TicketResponse response)
        {
            ctx.TicketResponses.Add(response);
            ctx.SaveChanges();
            return response;
        }

        public void DeleteTicket(int nbr)
        {
            var ticket = ctx.Tickets.Find(nbr);
            ctx.Tickets.Remove(ticket);
            ctx.SaveChanges();
        }

        public Ticket ReadTicket(int nbr)
        {
            return ctx.Tickets.Find(nbr);
        }

        public IEnumerable<TicketResponse> ReadTicketResponsesOfTicket(int ticketNumber)
        {
            var responses = ctx.TicketResponses
                                .Where(r => r.Ticket.TicketNumber == ticketNumber)
                                .AsEnumerable();
            return responses;

        }

        public IEnumerable<Ticket> ReadTickets()
        {
            return ctx.Tickets.Include(t => t.Responses).AsEnumerable();
        }

        public void UpdateTicket(Ticket ticket)
        {
            ctx.SaveChanges();
        }

        public void UpdateTicketStateToClosed(int nbr)
        {
            var ticketToUpdate = ReadTicket(nbr);
            ticketToUpdate.State = TicketState.Closed;
            ctx.SaveChanges();
        }
    }
}
