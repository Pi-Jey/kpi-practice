using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
        public TimeSpan OpenTime { get; set; }

        [Column(name: "WhenClose")]
        public TimeSpan CloseTime { get; set; }

    }
}
