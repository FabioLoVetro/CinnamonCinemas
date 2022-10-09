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

        /// <summary>
        /// Rapresents the show time as a string
        /// </summary>
        /// <returns></returns>
        override
        public string ToString()
        {
            string showTimeMovie = $"{this._movie}";
            string showTimeDateTime = "";
            string date = "";
            
            foreach (DateTime dateTime in this._dates)
            {
                if (date != dateTime.ToString("yyyy-MM-dd"))
                {
                    date = dateTime.ToString("yyyy-MM-dd");
                    showTimeDateTime += $"\n{date}\n - {dateTime.ToString("HH:mm")}";
                }
                else
                {
                    showTimeDateTime += $" - {dateTime.ToString("HH:mm")}";
                }
            }
            return showTimeMovie + showTimeDateTime;
        }
    }
}