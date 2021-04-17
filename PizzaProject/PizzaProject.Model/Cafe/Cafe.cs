using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaProject.Model.Cafe
{
    public class Cafe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
    }
}
