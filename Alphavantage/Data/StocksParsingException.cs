using System;
using System.Runtime.Serialization;

namespace Alphavantage
{
    [Serializable]
    internal class StocksParsingException : Exception
    {
        public StocksParsingException()
        {
        }

        public StocksParsingException(string message) : base(message)
        {
        }

        public StocksParsingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StocksParsingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}