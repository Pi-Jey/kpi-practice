using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaProject.Onion.PizzaContract
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Recipe { get; set; }


    }
}
