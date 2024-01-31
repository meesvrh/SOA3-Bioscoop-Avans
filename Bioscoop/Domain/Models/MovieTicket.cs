using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MovieTicket
    {
        private int rowNr;
        private int seatNr;
        private Boolean isPremium;
        private MovieScreening movieScreening;

        public MovieTicket(MovieScreening movieScreening, Boolean isPremiumReservation, int seatRow, int seatNr)
        {
            this.isPremium = isPremiumReservation;
            this.rowNr = seatRow;
            this.seatNr = seatNr;
            this.movieScreening = movieScreening;
        }

        public Boolean isPremiumTicket()
        {
            return isPremium;
        }

        public double getPrice()
        {
            return 0.2;
        }

        public string toString()
        {
            return "Ticket |-| Seat: r" + rowNr + " nr" + seatNr + " - Premium: " + isPremium;
        }
    }
}
