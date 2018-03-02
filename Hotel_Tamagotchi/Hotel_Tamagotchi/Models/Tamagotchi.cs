using Hotel_Tamagotchi.Models.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models
{
    public class Tamagotchi
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "The name must have a length no more than 10 characters")]
        [StringLength(10)]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [AgeValidator]
        public int Cents { get; set; }
        [Range(0, 100)]
        public int Health { get; set; }
        [Required]
        [Range(0, 100)]
        public int Boredom { get; set; }
        [Required]
        public bool Alive { get; set; }

        public Tamagotchi()
        {
            Age = 0;
            Cents = 100;
            Boredom = 0;
            Alive = true;
        }
    }
}