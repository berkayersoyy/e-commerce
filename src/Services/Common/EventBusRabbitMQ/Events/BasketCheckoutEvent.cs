using EventBusRabbitMQ.Events.Abstractions;

namespace EventBusRabbitMQ.Events
{
    public class BasketCheckoutEvent:IEvent
    {
        public string Email { get; set; }
        public decimal TotalPrice { get; set; }

        //Billing Adress
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        //Payment
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public int PaymentMethod { get; set; }
    }
}