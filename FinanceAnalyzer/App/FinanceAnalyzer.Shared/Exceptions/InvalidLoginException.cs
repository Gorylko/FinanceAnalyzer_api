namespace FinanceAnalyzer.Shared.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class InvalidLoginException : Exception
    {
        public InvalidLoginException(string message)
            : base(message)
        {
        }

        public InvalidLoginException()
        {
        }

        public InvalidLoginException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public InvalidLoginException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
