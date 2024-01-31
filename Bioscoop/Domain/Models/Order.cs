using System;
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

        public double calculatePrice()
        {
            return 0.2;
        }

        public void export(TicketExportFormat exportFormat)
        {

        }
    }
}