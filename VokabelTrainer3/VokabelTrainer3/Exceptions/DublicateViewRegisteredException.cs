using System;
using System.Collections.Generic;
using System.Text;

namespace VokabelTrainer3.Exceptions
{
    class DublicateViewRegisteredException : Exception
    {
        private readonly string _message = "VokabelTrainer3\\Factory\\ViewFactory.cs\\Register - method \n " +
                                          "You accidentally registered a already registered View or ViewModel \n" +
                                          "Cannot register more then one Page and its viewmodel of the same type";

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
