using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinnamonCinemas.Model
{
    public class Showtime
    {
        private string _movie;
        private List<DateTime> _dates;

        /// <summary>
        /// Constructor
        /// </summary>
        public Showtime()
        {
            this._dates = new List<DateTime>();
        }

        /// <summary>
        /// date and time of the show
        /// </summary>
        public List<DateTime> Dates
        {
            get => this._dates;
            set => this._dates = value;
        }

        /// <summary>
        /// the movie
        /// </summary>
        public string Movie
        {
            get => this._movie;
            set => this._movie = value;
        }
    }
}