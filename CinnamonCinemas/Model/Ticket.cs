using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinnamonCinemas.Model
{
    public class Ticket
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public Ticket()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The cinema
        /// </summary>
        private string _movie
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// The time
        /// </summary>
        private TimeOnly _time
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// The date
        /// </summary>
        private DateOnly _date
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// The seat
        /// </summary>
        private string _seat
        {
            get => default;
            set
            {
            }
        }
    }
}