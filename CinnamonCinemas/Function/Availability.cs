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
        /// <param name="seats">The seats to cheack</param>
        /// <param name="booking">The booking</param>
        public bool AreSpecificSeatsAvailableForMovie(string movie, DateTime datetime, string[] seats, Booking booking)
        {
            if (this.AllAvailabilityForMovie(movie, booking) == null) { return false; }

            string[] seatsArray = this.AllAvailabilityForMovie(movie, booking)[datetime].Trim().Split(' ');

            if (seats.Except(seatsArray).Count() == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Given a movie, returns seats available for date and time.
        /// null, if the movie is not valid
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="booking">The booking</param>
        public Dictionary<DateTime, string> AllAvailabilityForMovie(string movie, Booking booking)
        {
            if (this.SeatsAllocatedForMovie(movie, booking)==null) { return null; }

            Dictionary<DateTime, string> result = new Dictionary<DateTime, string>();

            foreach (DateTime datetime in this.SeatsAllocatedForMovie(movie, booking).Keys)
            {
                string[] allSeats = booking.Seats;
                string[] seatsAllocated = this.SeatsAllocatedForMovie(movie, booking)[datetime].Trim().Split(' ');
                result.Add(datetime, string.Join(' ', allSeats.Except(seatsAllocated)).Trim());
            }
            return result;
        }

        /// <summary>
        /// Check if is there a specific number of seats available
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="dateTime">The date and time of the movie</param>
        /// <param name="numberOfSeats">The number of the seats</param>
        /// <param name="booking">The booking</param>
        public bool EnoughSeatsAvailable(string movie, DateTime dateTime, int numberOfSeats, Booking booking)
        {
            if (this.AllAvailabilityForMovie(movie, booking) == null) return false;
            string[] seatsArray = this.AllAvailabilityForMovie(movie, booking)[dateTime].Trim().Split(' ');
            if (seatsArray.Length == 1 && seatsArray[0] == "") return false;
            return (seatsArray.Length >= numberOfSeats);
        }

        /// <summary>
        /// Given a movie, returns seats allocated for date and time
        /// null, if the movie is not valid
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="booking">The booking</param>
        public Dictionary<DateTime, string> SeatsAllocatedForMovie(string movie, Booking booking)
        {
            if (!this.IsMovieAvailable(movie, booking)) { return null; }

            Dictionary<DateTime, string> result = new Dictionary<DateTime, string>();

            foreach (Showtime showTime in booking.ShowTimeList)
                if (showTime.Movie == movie)
                    foreach (DateTime dateTime in showTime.Dates)
                        result.Add(dateTime, "");
            
            foreach (Ticket t in booking.TicketList)
            {
                if (t.Movie == movie)
                {
                    if (result.ContainsKey(t.DateTime))
                        result[t.DateTime] = string.Join(' ',result[t.DateTime], t.Seat).Trim();
                    else
                        result.Add(t.DateTime, t.Seat);
                }
            }
            
            return result;
        }

        /// <summary>
        /// Given a movie and a datetime, check if the movie is available
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="booking">The booking</param>
        public bool IsMovieAvailable(string movie, Booking booking)
        {
            foreach (Showtime showtime in booking.ShowTimeList)
            {
                if (showtime.Movie == movie)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Return a string that rapresents all the availability and all the seats allocated
        /// </summary>
        /// <returns></returns>
        public string ToString(string movie, Booking booking)
        {
            string allocatedSeats = $"Seats sold for: {movie}\n";
            foreach (DateTime datetime in this.SeatsAllocatedForMovie(movie, booking).Keys.ToList())
            {
                allocatedSeats += $" - {datetime.ToString("yyyy-MM-dd HH:mm")}";
                allocatedSeats += $" - {this.SeatsAllocatedForMovie(movie, booking)[datetime]}\n";
            }
            return allocatedSeats;
        }
    }
}