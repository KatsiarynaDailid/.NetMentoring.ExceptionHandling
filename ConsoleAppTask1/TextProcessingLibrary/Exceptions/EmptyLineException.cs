using System;
using System.Runtime.Serialization;

namespace ConsoleAppTask1.Exceptions
{
    [Serializable]
    public class EmptyLineException : Exception
    {
        public EmptyLineException() { }

        public EmptyLineException(string message) : base(message) { }

        public EmptyLineException(string message, Exception inner) : base(message, inner) { }

        protected EmptyLineException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
