using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinnamonCinemas.Model;
using CinnamonCinemas.Persistence;

namespace CinnamonCinemas.Function
{
    public class BuyTickets
    {
        Availability availability;
        /// <summary>
        /// The constructor
        /// </summary>
        public BuyTickets()
        {
            this.availability = new Availability();
        }

        /// <summary>
        /// Buy a random number of seats (from 1 to 3)
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="dateTime">The date and time of the movie</param>
        /// <param name="booking">The booking</param>
        public bool BuyRandomNumberOfSeats(string movie, DateTime dateTime, Booking booking)
        {
            Random random = new Random();
            // creates a number between 1 and 3
            int randomNumber = random.Next(1, 4);
            return this.BuyANumberOfSeats(movie, dateTime, randomNumber, booking);
        }

        /// <summary>
        /// Buy a number of seats specified by user
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="dateTime">The date and time of the movie</param>
        /// <param name="numberOfSeats">The number of the seats</param>
        /// <param name="booking">The booking</param>
        public bool BuyANumberOfSeats(string movie, DateTime dateTime, int numberOfSeats, Booking booking)
        {
            if (!availability.EnoughSeatsAvailable(movie, dateTime, numberOfSeats, booking))
                { return false; }

            string[] seats = availability.AllAvailabilityForMovie(movie, booking)[dateTime].Split(' ');

            for (int i =0;i<numberOfSeats;i++)
            {
                booking.TicketList.Add(new Ticket(movie, dateTime, seats[i]));
            }
            return true;
        }

        /// <summary>
        /// Buy the specified seats by user
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="dateTime">The date and time of the movie</param>
        /// <param name="seats">The seats to buy</param>
        /// <param name="booking">The booking</param>
        public bool BuySpecificSeats(string movie, DateTime dateTime, string[] seats, Booking booking)
        {
            if(!availability.AreSpecificSeatsAvailableForMovie(movie,dateTime,seats,booking)) return false;

            for (int i = 0; i < seats.Length; i++)
            {
                booking.TicketList.Add(new Ticket(movie, dateTime, seats[i]));
            }
            return true;
        }
    }
}
