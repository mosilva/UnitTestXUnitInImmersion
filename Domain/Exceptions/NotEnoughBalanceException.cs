namespace Domain.Exceptions
{
    public class NotEnoughBalanceException : ArgumentException
    {
        public NotEnoughBalanceException() { }

        public NotEnoughBalanceException(string message)
            : base(message) { }

        public NotEnoughBalanceException(string message, Exception inner)
            : base(message, inner) { }

        public NotEnoughBalanceException(string? message, string? paramName)
            : base(message, paramName) { }

    }
}
