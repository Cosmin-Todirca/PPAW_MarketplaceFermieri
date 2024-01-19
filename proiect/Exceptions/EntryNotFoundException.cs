using System;

namespace Exceptions
{
    [Serializable]
    public class EntryNotFoundException : Exception
    {
        public EntryNotFoundException() { }
        public EntryNotFoundException(string message)
        : base(String.Format("An error was thrown: {0}", message))
        {

        }
    }
}
