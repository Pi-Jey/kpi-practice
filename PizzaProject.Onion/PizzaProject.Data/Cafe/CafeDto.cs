using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaProject.Data.Cafe
{
    [Table("Cafe")]
    public class CafeDto
    {
        [Required]
        [Column(name: "id")]
        public int Id { get; set; }

        [Required]
        [Column(name: "Name")]
        public string Name { get; set; }

        [Required]
        [Column(name: "WhenOpen")]
        public string OpenTime { get; set; }

        [Required]
        [Column(name: "WhenClose")]
        public string CloseTime { get; set; }

    }
}
