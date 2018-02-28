using SC.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.DAL
{
    public interface ITicketRepository
    {
        Ticket CreateTicket(Ticket ticket);       
        IEnumerable<Ticket> ReadTickets();

        void DeleteTicket(int nbr);

        Ticket ReadTicket(int nbr);

        void UpdateTicket(Ticket ticket);

        IEnumerable<TicketResponse> ReadTicketResponsesOfTicket(int ticketNumber);
        TicketResponse CreateTicketResponse(TicketResponse response);

        void UpdateTicketStateToClosed(int nbr);

    }
}
