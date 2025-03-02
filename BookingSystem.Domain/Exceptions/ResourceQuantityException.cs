namespace BookingSystem.Domain.Exceptions
{
    public class ResourceQuantityException : Exception
    {
        public ResourceQuantityException(string message) : base(message) { }
    }
}
