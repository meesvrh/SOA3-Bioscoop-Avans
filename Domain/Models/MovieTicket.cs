using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MovieTicket
    {
        public int RowNr { get; }
        public int SeatNr { get; }
        public Boolean IsPremium { get; }
        public Boolean IsStudent { get; }
        public MovieScreening MovieScreening { get; }

        public MovieTicket(MovieScreening movieScreening, Boolean isPremiumReservation, Boolean isStudent, int seatRow, int seatNr)
        {
            RowNr = seatRow;
            SeatNr = seatNr;
            IsPremium = isPremiumReservation;
            MovieScreening = movieScreening;
            IsStudent = isStudent;
        }

        public string toString()
        {
            return "Ticket |-| Seat: r" + RowNr + " nr" + SeatNr + " - Premium: " + IsPremium + " - Student: " + IsStudent;
        }
    }
}
