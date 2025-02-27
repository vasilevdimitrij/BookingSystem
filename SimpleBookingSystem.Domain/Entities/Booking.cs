namespace SimpleBookingSystem.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int Quantity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
