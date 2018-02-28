using SC.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SC.BL
{
    public class TicketManager : ITicketManager
    {
        private SC.DAL.ITicketRepository repo;

        public TicketManager()
        {
            //repo = new DAL.HCTicketRepository();
            repo = new DAL.EF.TicketRepository();
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return repo.ReadTickets();
        }

        public Ticket GetTicket(int nbr)
        {
            if (nbr < 0) throw new ArgumentException("nbr moet positief zijn. Heb jij ooit al een negatief nummer gezien als key-aanduiding? :-)");
            Ticket t = repo.ReadTicket(nbr);
            return t;
        }
        
        //Toevoegen van een ticket
        public Ticket AddTicket(int accountId, string question)
        {
            Ticket t = new Ticket()
            {
                AccountId = accountId,
                Text = question,
                DateOpened = DateTime.Now,
                State = TicketState.Open,
                Responses = new List<TicketResponse>()
            };
            return this.AddTicket(t);
        }

        //HardwareTicket toevoegen
        public Ticket AddTicket(int accountId, string device, string problem)
        {
            Ticket t = new HardwareTicket()
            {
                AccountId = accountId,
                Text = problem,
                DateOpened = DateTime.Now,
                State = TicketState.Open,
                Responses = new List<TicketResponse>(),
                DeviceName = device
            };
            return this.AddTicket(t);
        }

        private Ticket AddTicket(Ticket ticket)
        {
            ValidateTicket(ticket);
            return repo.CreateTicket(ticket);
        }

        public void RemoveTicket(int nbr)
        {
            //Ev. authorizatie controleren, .... 
            repo.DeleteTicket(nbr);
        }

        public void ChangeTicket(Ticket ticket)
        {
            ValidateTicket(ticket);
            repo.UpdateTicket(ticket);
        }

        private void ValidateTicket(Ticket ticketToValidate)
        {
            Validator.ValidateObject(ticketToValidate, new ValidationContext(ticketToValidate), true);
        }

        public TicketResponse AddTicketResponse(int ticketNumber, string response, bool isClientResponse)
        {
            Ticket ticketToAddResponseTo = repo.ReadTicket(ticketNumber);
            if (ticketToAddResponseTo != null)
            {
                // Create response
                TicketResponse newTicketResponse = new TicketResponse();
                newTicketResponse.Date = DateTime.Now;
                newTicketResponse.Text = response;
                newTicketResponse.IsClientResponse = isClientResponse;
                newTicketResponse.Ticket = ticketToAddResponseTo;

                // Add response to ticket
                var responses = this.GetTicketResponses(ticketNumber);

                if (responses != null)
                    ticketToAddResponseTo.Responses = responses.ToList();
                else
                    ticketToAddResponseTo.Responses = new List<TicketResponse>();

                ticketToAddResponseTo.Responses.Add(newTicketResponse);


                // Change state of ticket
                if (isClientResponse)
                    ticketToAddResponseTo.State = TicketState.ClientAnswer;
                else
                    ticketToAddResponseTo.State = TicketState.Answered;

                // Save changes to repository
                repo.CreateTicketResponse(newTicketResponse);
                repo.UpdateTicket(ticketToAddResponseTo);

                return newTicketResponse;
            }
            else
                throw new ArgumentException(String.Format("Ticketnumber '{0}' not found",  ticketNumber));
        }

        public IEnumerable<TicketResponse> GetTicketResponses(int ticketNumber)
        {
            return repo.ReadTicketResponsesOfTicket(ticketNumber);
        }

        public void ChangeTicketStateToClosed(int nbr)
        {
            repo.UpdateTicketStateToClosed(nbr);
        }
    }
}
