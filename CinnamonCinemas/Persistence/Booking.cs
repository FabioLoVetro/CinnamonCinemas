using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CinnamonCinemas.Model;

namespace CinnamonCinemas.Persistence
{
    public class Booking
    {
        private List<Ticket> _ticketList;
        /// <summary>
        /// Constructor
        /// </summary>
        public Booking()
        {
            this._ticketList = new List<Ticket>();
        }

        /// <summary>
        /// The reservations list
        /// </summary>
        public List<Ticket> TicketList
        {
            get => this._ticketList;
            set => this._ticketList = value;
        }
    }
}