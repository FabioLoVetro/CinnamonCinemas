using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinnamonCinemas.Model
{
    public class Ticket
    {
        private string _movie;
        private DateOnly _date;
        private TimeOnly _time;
        private string _seat;
        private DateTime _dateTime;

        /// <summary>
        /// The movie
        /// </summary>
        public string Movie
        {
            get => this._movie;
            set => this._movie = value;
        }
        /// <summary>
        /// The time
        /// </summary>
        public TimeOnly Time
        {
            get => this._time;
            set => this._time = value;
        }

        /// <summary>
        /// The date
        /// </summary>
        public DateOnly Date
        {
            get => this._date;
            set => this._date = value;
        }

        /// <summary>
        /// The date time
        /// </summary>
        public DateTime DateTime()
        {
            return new DateTime(this._date.Year, this._date.Month, this._date.Day,
                                this._time.Hour, this._time.Minute, this._time.Second);
        }

        /// <summary>
        /// The seat
        /// </summary>
        public string Seat
        {
            get => this._seat;
            set => this._seat = value;
        }
    }
}