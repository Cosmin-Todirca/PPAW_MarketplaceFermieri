using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    [Serializable]
    public class EntityValidationException : Exception
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();
        public EntityValidationException() { }
        public EntityValidationException(string message)
        : base(String.Format("An error was thrown: {0}", message))
        {
            logger.Error(message);
        }
    }
}

