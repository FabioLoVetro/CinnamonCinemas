using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CinnamonCinemas.Model;

namespace CinnamonCinemas.Persistence
{
    public class Booking
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Booking()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The reservations
        /// </summary>
        private List<Ticket> _ticketList
        {
            get => default;
            set
            {
            }
        }
    }
}