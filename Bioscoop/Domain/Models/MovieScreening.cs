using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MovieScreening
    {
        public Movie Movie { get; }
        public double PricePerSeat { get; }
        public DateTime DateAndTime { get; }

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            Movie = movie;
            DateAndTime = dateAndTime;
            PricePerSeat = pricePerSeat;
        }
        
        public string toString()
        {
            return "Screening |-| Date: " + DateAndTime.ToString() + " - Price per seat: " + PricePerSeat;
        }
    }
}
