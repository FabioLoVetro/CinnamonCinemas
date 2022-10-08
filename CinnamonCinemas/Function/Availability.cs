﻿using System;
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
            string[] seatsArray = this.AllAvailabilityForMovie(movie, booking)[datetime].Split(' ');

            Console.WriteLine(datetime+" datetime");   
            Console.WriteLine(seats.Except(seatsArray).Count());
            Console.WriteLine(string.Join(' ',seatsArray));
            Console.WriteLine(string.Join(' ',seats.Except(seatsArray)));

            if (seats.Except(seatsArray).Count() == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Given a movie, returns seats available for date and time
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="booking">The booking</param>
        public Dictionary<DateTime, string> AllAvailabilityForMovie(string movie, Booking booking)
        {
            Dictionary<DateTime, string> result = new Dictionary<DateTime, string>();
            foreach (DateTime datetime in this.SeatsAllocatedForMovie(movie, booking).Keys)
            {
                string[] allSeats = booking.Seats;
                string[] seatsAllocated = this.SeatsAllocatedForMovie(movie, booking)[datetime].Split(' ');
                result.Add(datetime, string.Join(' ', allSeats.Except(seatsAllocated)));
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
            string[] seatsArray = this.AllAvailabilityForMovie(movie, booking)[dateTime].Split(' ');
            return (seatsArray.Length >= numberOfSeats);
        }

        /// <summary>
        /// Given a movie, returns seats allocated for date and time
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="booking">The booking</param>
        private Dictionary<DateTime, string> SeatsAllocatedForMovie(string movie, Booking booking)
        {
            Dictionary<DateTime, string> result = new Dictionary<DateTime, string>();

            foreach (Ticket t in booking.TicketList)
            {
                if (t.Movie == movie)
                {
                    if (result.ContainsKey(t.DateTime()))
                        result[t.DateTime()] = string.Concat(result[t.DateTime()], $" {t.Seat}");
                    else
                        result.Add(t.DateTime(), t.Seat);
                }
            }
            return result;
        }
    }
}