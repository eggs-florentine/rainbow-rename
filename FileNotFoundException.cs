using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rainbow_rename
{
    [Serializable]
    internal class FileNotFoundException : Exception
    {
        public FileNotFoundException() { }

        public FileNotFoundException(string message) 
            :base (message)
        { }

        public FileNotFoundException(string message, Exception innerException) 
            :base(message, innerException) 
        { }

    }

    [Serializable]
    internal class InternalException : Exception
    {
        public InternalException() { }

        public InternalException(string message) 
            :base (message)
        { }

        public InternalException (string message, Exception innerException) 
            :base (message, innerException) 
        { }
    }

}
