namespace MVVMLib.Exceptions
{
    public class NoValidRegistationException : Exception
    {
        public NoValidRegistationException()
        {
        }

        public NoValidRegistationException(string? message) : base(message)
        {
        }

        public NoValidRegistationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
