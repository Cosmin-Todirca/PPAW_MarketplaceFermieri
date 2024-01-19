using NLog;
using System;

namespace Exceptions
{
    [Serializable]
    public class EntryNotFoundException : Exception
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();
        public EntryNotFoundException() { }
        public EntryNotFoundException(string message)
        : base(String.Format("An error was thrown: {0}", message))
        {
            logger.Error(message);
        }
    }
}
