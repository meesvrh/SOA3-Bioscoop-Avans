using System;
using System.Text.Json;
using static Domain.Enums;

namespace Domain.Models
{
    public class Order
    {
        private int orderNr;
        private Boolean isStudentOrder;
        private List<MovieTicket>? movieTickets;

        public Order(int orderNr, Boolean isStudentOrder)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
        }

        public int getOrderNr()
        {
            return this.orderNr;
        }

        public void addSeatReservation(MovieTicket movieTicket)
        {
            if (this.movieTickets == null)
            {
                this.movieTickets = new List<MovieTicket>();
            }

            this.movieTickets.Add(movieTicket);
        }

        public void addSeatReservations(List<MovieTicket> movieTickets)
        {
            if (this.movieTickets == null)
            {
                this.movieTickets = new List<MovieTicket>();
            }

            this.movieTickets.AddRange(movieTickets);
        }

        public double calculatePrice()
        {
            var totalPrice = 0.0;

            if (this.movieTickets != null)
            {
                for (global::System.Int32 i = 0; i < this.movieTickets.Count; i++)
                {
                    if (i % 2 != 0)
                    {
                        // Elk 2e ticket is gratis voor studenten (elke dag van de week) of als het een voorstelling betreft op een doordeweekse dag (ma/di/wo/do) voor iedereen. 
                    }
                }
            }

            return totalPrice;
        }

        public void export(TicketExportFormat exportFormat)
        {
            var order = new
            {
                orderNr = this.orderNr,
                isStudentOrder = this.isStudentOrder,
            };

            if (exportFormat == TicketExportFormat.JSON)
            {
                string file = "C:\\Dev\\SOA3-Avans\\order.json";
                string json = JsonSerializer.Serialize(order);
                File.WriteAllText(file, json);
            }
            else
            {
                Console.WriteLine(order.ToString());
            }

        }
    }
}