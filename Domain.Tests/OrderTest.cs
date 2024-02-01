namespace Domain.Tests
{
    public class OrderTest
    {
        private Movie movie;
        
        private MovieScreening screeningWeek;
        private MovieScreening screeningWeekend;

        private MovieTicket normalTicketWeek1;
        private MovieTicket normalStudentTicketWeek1;
        private MovieTicket premiumTicketWeek1;
        private MovieTicket premiumStudentTicketWeek1;
        
        private MovieTicket normalTicketWeekend1;
        private MovieTicket normalStudentTicketWeekend1;
        private MovieTicket premiumTicketWeekend1;
        private MovieTicket premiumStudentTicketWeekend1;
        
        private readonly double premiumExtraStudent = 2.0;
        private readonly double premiumExtraNormal = 3.0;

        public OrderTest()
        {
            movie = new("The Matrix");
            
            // Screening & tickets for in the week.
            screeningWeek = new(movie, new DateTime(2024, 1, 30), 10.0);
            normalTicketWeek1 = new(screeningWeek, false, false, 1, 1);
            normalStudentTicketWeek1 = new(screeningWeek, false, true, 1, 2);
            premiumTicketWeek1 = new(screeningWeek, true, false, 1, 3);
            premiumStudentTicketWeek1 = new(screeningWeek, true, true, 1, 4);

            // Screening & tickets for in the weekend.
            screeningWeekend = new(movie, new DateTime(2024, 2, 3), 10.0);
            normalTicketWeekend1 = new(screeningWeekend, false, false, 1, 1);
            normalStudentTicketWeekend1 = new(screeningWeekend, false, true, 1, 2);
            premiumTicketWeekend1 = new(screeningWeekend, true, false, 1, 3);
            premiumStudentTicketWeekend1 = new(screeningWeekend, true, true, 1, 4);
        }

        private Boolean isDayOfTheWeek()
        {
            var date = DateTime.Now;
            return date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Tuesday || date.DayOfWeek == DayOfWeek.Wednesday || date.DayOfWeek == DayOfWeek.Thursday || date.DayOfWeek == DayOfWeek.Friday;
        }

        [Fact]
        public void NormalMovieTicketPriceShouldBeDefaultSeatPrice()
        {
            // Arrange
            Order order1 = new(1);
            order1.addSeatReservation(normalTicketWeek1);

            Order order2 = new(2);
            order2.addSeatReservation(normalStudentTicketWeek1);

            // Act
            var price1 = order1.calculatePrice();
            var price2 = order2.calculatePrice();
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(screeningWeek.PricePerSeat, price1);
                Assert.Equal(screeningWeek.PricePerSeat, price2);
            });
        }

        [Fact]
        public void PremiumMovieTicketPriceShouldBeDefaultSeatPricePlusPremiumPrice()
        {
            // Arrange
            Order order1 = new(1);
            order1.addSeatReservation(premiumTicketWeek1);

            Order order2 = new(2);
            order2.addSeatReservation(premiumStudentTicketWeek1);

            // Act
            var price1 = order1.calculatePrice();
            var price2 = order2.calculatePrice();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(screeningWeek.PricePerSeat + premiumExtraNormal, price1);
                Assert.Equal(screeningWeek.PricePerSeat + premiumExtraStudent, price2);
            });
        }

        [Fact]
        public void EverySecondTicketShouldBeFreeForStudentsOrIfScreeningIsAtWeekday()
        {   
            Order orderStudent = new(1);
            orderStudent.addSeatReservation(premiumStudentTicketWeek1);
            orderStudent.addSeatReservation(normalStudentTicketWeekend1);

            Order orderNonStudentInWeek = new(2);
            orderNonStudentInWeek.addSeatReservation(normalTicketWeek1);
            orderNonStudentInWeek.addSeatReservation(premiumTicketWeek1);

            // Act
            var priceStudent = orderStudent.calculatePrice();
            var priceNonStudentInWeek = orderNonStudentInWeek.calculatePrice();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(screeningWeek.PricePerSeat + premiumExtraStudent, priceStudent);
                Assert.Equal(screeningWeek.PricePerSeat, priceNonStudentInWeek);
            });
        }

        [Fact]
        public void TenPercentDiscountOnTicketPriceIfMovieIsInWeekendForNonStudentAndOrderHasSixOrMoreTicketsNoMatterPremium()
        {
            // Arrange
            Order order = new(1);
            order.addSeatReservation(premiumTicketWeekend1); // 11.7
            order.addSeatReservation(normalTicketWeekend1); // 9
            order.addSeatReservation(normalStudentTicketWeekend1); // 10
            order.addSeatReservation(premiumStudentTicketWeekend1); // Free (2nd ticket)
            order.addSeatReservation(normalTicketWeek1); // 10
            order.addSeatReservation(premiumTicketWeek1); // Free (Free 2nd ticket)
            
            // Act
            var price = order.calculatePrice();

            // Assert
            Assert.Equal(40.7, price);
        }
    }
}