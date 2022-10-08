using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CinnamonCinemas.Model;

namespace CinnamonCinemas.Persistence
{
    public class Booking
    {
        private readonly List<Showtime> _showTimeList;
        private readonly string[] _seats;
        private List<Ticket> _ticketList;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cinema">The cinema</param>
        public Booking(Cinema cinema)
        {
            this._showTimeList = cinema.ShowTimeList;
            this._seats = cinema.Seats;
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

        /// <summary>
        /// The seats of the cinema
        /// </summary>
        public string[] Seats
        {
            get => this._seats;
        }

        /// <summary>
        /// The show time list
        /// </summary>
        public List<Showtime> ShowTimeList
        {
            get => this._showTimeList;
        }
    }
}