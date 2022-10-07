using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CinnamonCinemas.Model;
using CinnamonCinemas.Persistence;

namespace CinnamonCinemas.Function
{
    public class Availability
    {
        /// <summary>
        /// Check if a specific seat is allocated or not for a specific show time
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="datetime">The date and time of the movie</param>
        /// <param name="seats">the seats to cheack</param>
        public bool AreSpecificSeatsAvailableForMovie(string movie, DateTime datetime, string[] seats)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Given a movie, returns seats available for date and time
        /// </summary>
        /// <param name="movie">the movie</param>
        /// <param name="booking">the booking</param>
        public System.Collections.Generic.Dictionary<System.DateTime, string> AllAvailabilityForMovie(string movie, Booking booking)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Check if are there a specific number of seats available
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="dateTime">The date and time of the movie</param>
        /// <param name="numberOfSeats">The number of the seats</param>
        public bool EnoughSeatsAvailable(string movie, DateTime dateTime, int numberOfSeats)
        {
            throw new System.NotImplementedException();
        }
    }
}