using NLog;
using System;

namespace Exceptions
{
    [Serializable]
    public class InsufficientStockException : Exception
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();
        public InsufficientStockException() { }
        public InsufficientStockException(string message)
        : base(String.Format("An error was thrown: {0}", message))
        {
            logger.Error(message);
        }
    }
}








    