using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CinnamonCinemas.Model;

namespace CinnamonCinemas.Model
{
    public class Cinema
    {
        private readonly string _cinemaName = "Cinnamon Cinemas Movie Theatre";
        private readonly string[] _seats = { "A1", "A2", "A3", "A4", "A5", "B1", "B2", "B3", "B4", "B5", "C1", "C2", "C3", "C4", "C5" };
        private List<Showtime> _showTimeList;
        /// <summary>
        /// Constructor
        /// </summary>
        public Cinema()
        {
            this._showTimeList = new List<Showtime>();
        }

        /// <summary>
        /// The showtime
        /// </summary>
        public  List<Showtime> ShowTimeList
        {
            get => this._showTimeList;
            set => this._showTimeList = value;
        }

        /// <summary>
        /// The seats
        /// </summary>
        public string[] Seats
        {
            get => this._seats;
        }

        /// <summary>
        /// The name of the cinema
        /// </summary>
        public string CinemaName
        {
            get => this._cinemaName;
        }

        /// <summary>
        /// Number of the seats
        /// </summary>
        public int SeatsNumber
        {
            get => this._seats.Length;
        }
        /// <summary>
        /// Return a list of all movies
        /// </summary>
        /// <returns></returns>
        public List<string> AllMovie()
        {
            List<string> allMovies = new List<string>();
            foreach (Showtime showTime in this._showTimeList)
            {
                allMovies.Add(showTime.Movie);
            }
            return allMovies;
        }
        /// <summary>
        /// Return a string to rapresents all the show times
        /// </summary>
        /// <returns></returns>
        public string ShowTimeListToString()
        {
            string showTimeListToString = "";

            foreach (Showtime showTime in ShowTimeList)
            {
                showTimeListToString += $"{showTime.ToString()}\n";
            }
            return showTimeListToString;
        }
    }
}
