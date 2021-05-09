using System;

namespace PizzaProject.Model.Exception
{
    public class ValidationException : SystemException
    {
        public ValidationException(string message = "") : base(message)
        {

        }
    }
}
