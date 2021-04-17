using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaProject.Model.Exception
{
    public class ValidationException : SystemException
    {
        public ValidationException(string message = "") : base(message)
        {

        }
    }
}
