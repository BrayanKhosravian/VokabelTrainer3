using System;
using System.Collections.Generic;
using System.Text;

namespace VokabelTrainer3.Exceptions
{
    class DublicateViewRegisteredException : AggregateException
    {

        public DublicateViewRegisteredException() : base()
        {
            
        }

        public DublicateViewRegisteredException(string message) : base(message)
        {
            
        }

        public DublicateViewRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
