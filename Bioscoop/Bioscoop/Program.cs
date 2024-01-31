using Domain.Models;
using static Domain.Enums;

Movie movie = new("The Matrix");

MovieScreening screening = new(movie, DateTime.Now, 10.0);

MovieTicket premiumTicket1 = new(screening, true, 1, 1);
MovieTicket premiumTicket2 = new(screening, true, 1, 2);
MovieTicket premiumTicket3 = new(screening, true, 1, 3);
MovieTicket normalTicket1 = new(screening, false, 1, 4);
MovieTicket normalTicket2 = new(screening, false, 1, 5);
MovieTicket normalTicket3 = new(screening, false, 1, 6);

Order order = new(1, false);
order.addSeatReservations(new List<MovieTicket> { premiumTicket1, premiumTicket2, premiumTicket3, normalTicket1, normalTicket2, normalTicket3 });

// order.export(TicketExportFormat.PLAINTEXT);
// order.export(TicketExportFormat.JSON);

Console.WriteLine("Price: " + order.calculatePrice());
    
Thread.Sleep(100000);