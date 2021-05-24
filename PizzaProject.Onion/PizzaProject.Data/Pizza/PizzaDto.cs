using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaProject.Data.Pizza
{
    [Table("Pizza")]
    public class PizzaDto
    {
        [Required]
        [Column(name: "id")]
        public int Id { get; set; }

        [Required]
        [Column(name: "Name")]
        public string Name { get; set; }

        [Required]
        [Column(name: "Size")]
        public int Size { get; set; }

        [Required]
        [Column(name: "Recipe")]
        public string Recipe { get; set; }


    }
}
