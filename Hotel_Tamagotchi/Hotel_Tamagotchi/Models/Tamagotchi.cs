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
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        int Age { get; set; }
        //[]
        int Cents { get; set; }
        [Range(0, 100)]
        int Health { get; set; }
        [Range(0, 100)]
        int Boredom { get; set; }
        bool Alive { get; set; }

        public Tamagotchi()
        {
            Age = 0;
            Cents = 100;
            Boredom = 0;
            Alive = true;
        }
    }
}