using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MovieScreening
    {
        private DateTime dateAndTime;
        private double pricePerSeat;
        private List<MovieTicket>? movieTickets;
        private Movie movie;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            this.movie = movie;
            this.dateAndTime = dateAndTime;
            this.pricePerSeat = pricePerSeat;
        }

        public double getPricePerSeat()
        {
            return this.pricePerSeat;
        }

        public string toString()
        {
            return "MovieScreening: " + this.dateAndTime + " - " + this.pricePerSeat;
        }
    }
}
