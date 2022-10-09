using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinnamonCinemas.Model
{
    public class Ticket
    {
        private string _movie;
        private DateTime _dateTime;
        private string _seat;

        /// <summary>
        /// The movie
        /// </summary>
        public string Movie
        {
            get => this._movie;
            set => this._movie = value;
        }


        /// <summary>
        /// The date
        /// </summary>
        public DateTime DateTime
        {
            get => this._dateTime;
            set => this._dateTime = value;
        }

        /// <summary>
        /// The seat
        /// </summary>
        public string Seat
        {
            get => this._seat;
            set => this._seat = value;
        }
        override
        public string ToString()
        {
            return $"{this._movie} {this._dateTime} {this._seat}";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="dateTime">Date and time of the movie</param>
        /// <param name="seat">seat reserved</param>
        public Ticket(string movie, DateTime dateTime, string seat)
        {
            this._movie = movie;
            this._dateTime = dateTime;
            this._seat = seat;
        }

        /// <summary>
        /// Constructor no args
        /// </summary>
        public Ticket()
        {
        }
    }
}