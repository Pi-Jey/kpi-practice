using System.ComponentModel.DataAnnotations;

namespace PizzaProject.Orchestrators.CafeContract
{
    public class CafeforCreate
    {
        [Required]
        [Range(3,30)]
        public string Name { get; set; }
        [Required]
        public string OpenTime { get; set; }
        [Required]
        public string CloseTime { get; set; }
    }
}