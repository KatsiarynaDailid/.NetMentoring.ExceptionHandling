using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTask1.Exceptions
{
    [Serializable]
    public class EmptyLineException : Exception
    {
        public EmptyLineException() { }

        public EmptyLineException(string message) : base(message) { }

        public EmptyLineException(string message, Exception inner) : base(message, inner) { }

        protected EmptyLineException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override string Message
        {
            get
            {
                return "Entered line cannot be processed as it is empty.";
            }
        }
    }
}
