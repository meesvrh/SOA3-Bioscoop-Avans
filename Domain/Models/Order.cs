using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Domain.Enums;

namespace Domain.Models
{
    public class Order
    {
        private int orderNr;
        private List<MovieTicket>? movieTickets;

        public Order(int orderNr)
        {
            this.orderNr = orderNr;
        }

        public int getOrderNr()
        {
            return orderNr;
        }

        public void addSeatReservation(MovieTicket movieTicket)
        {
            if (movieTickets == null)
            {
                movieTickets = new List<MovieTicket>();
            }

            movieTickets.Add(movieTicket);
        }

        public double calculatePrice()
        {
            var totalPrice = 0.0;

            if (movieTickets == null) return totalPrice;

            for (int i = 0; i < movieTickets.Count; i++)
            {
                var movieTicket = movieTickets[i];

                // Each 2nd ticket will be free if the order is for students or its a day of the week.
                if ((i % 2 != 0) && (movieTicket.IsStudent || isDayOfTheWeek(movieTicket.MovieScreening.DateAndTime))) continue;

                var seatPrice = movieTicket.MovieScreening.PricePerSeat;

                // Premium price on top of the seatPrice according to being a student or not.
                if (movieTicket.IsPremium)
                {
                    seatPrice = movieTicket.IsStudent ? (seatPrice + 2.0) : (seatPrice + 3.0);
                }

                // 10% discount on the seatPrice if the movie is in the weekend, and the ticket is not for a student, and the order has 6 or more tickets.
                if (!isDayOfTheWeek(movieTicket.MovieScreening.DateAndTime) && !movieTicket.IsStudent && movieTickets.Count >= 6) 
                {
                    seatPrice *= 0.9;
                }

                totalPrice += seatPrice;
            }

            return totalPrice;
        }

        public void export(TicketExportFormat exportFormat)
        {
            var export = new
            {
                orderNr = this.orderNr,
                totalPrice = calculatePrice(),
                tickets = movieTickets,
            };

            string dir = "C:\\Dev\\Bioscoop\\";

            string file = (dir + "order-" + orderNr) + (exportFormat == TicketExportFormat.JSON ? ".json" : ".txt");
            string json = JsonConvert.SerializeObject(export, Formatting.Indented);
            File.WriteAllText(file, json);
        }
        
        private Boolean isDayOfTheWeek(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Tuesday || date.DayOfWeek == DayOfWeek.Wednesday || date.DayOfWeek == DayOfWeek.Thursday || date.DayOfWeek == DayOfWeek.Friday;
        }
    }
}