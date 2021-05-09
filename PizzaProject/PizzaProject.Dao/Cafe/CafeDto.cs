using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaProject.Dao.Cafe
{
    [Table(name: "Cafe")]
    public class CafeDto
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "Name")]
        public string Name { get; set; }

        [Column(name: "WhenOpen")]
        public string OpenTime { get; set; }

        [Column(name: "WhenClose")]
        public string CloseTime { get; set; }

    }
}
