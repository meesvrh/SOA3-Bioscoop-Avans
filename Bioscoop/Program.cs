using Domain.Models;
using static Domain.Enums;

Movie movie = new("The Matrix");

MovieScreening screening = new(movie, DateTime.Now, 10.0);

MovieTicket premiumTicket1 = new(screening, true, false, 1, 1);
MovieTicket premiumTicket2 = new(screening, true, false, 1, 2);
MovieTicket premiumTicket3 = new(screening, true, true, 1, 3);
MovieTicket normalTicket1 = new(screening, false, true, 1, 4);
MovieTicket normalTicket2 = new(screening, false, true, 1, 5);
MovieTicket normalTicket3 = new(screening, false, true, 1, 6);

Order order = new(1);

// FLAW: the order of the tickets will decide the free tickets, with this case the end-user could get all premium tickets for free.
order.addSeatReservation(premiumTicket1);
order.addSeatReservation(normalTicket1);
order.addSeatReservation(premiumTicket2);
order.addSeatReservation(normalTicket2);
order.addSeatReservation(premiumTicket3);
order.addSeatReservation(normalTicket3);

//order.export(TicketExportFormat.PLAINTEXT);
order.export(TicketExportFormat.JSON);

Console.WriteLine("Price: " + order.calculatePrice());
    
Thread.Sleep(100000);