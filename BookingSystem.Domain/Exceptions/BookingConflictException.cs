namespace BookingSystem.Domain.Exceptions
{
    public class BookingConflictException : Exception
    {
        public BookingConflictException(string message) : base(message) { }
    }
}
