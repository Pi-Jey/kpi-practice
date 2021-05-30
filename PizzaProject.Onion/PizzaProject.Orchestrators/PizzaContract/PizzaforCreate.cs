using System.ComponentModel.DataAnnotations;

namespace PizzaProject.Orchestrators.PizzaContract
{
    public class PizzaforCreate
    {
        [Required]
        [Range(3, 30)]
        public string Name { get; set; }
        [Required]
        [Range(20, 40)]
        public int Size { get; set; }
        [Required]
        [Range(10, 50)]
        public string Recipe { get; set; }
    }
}
