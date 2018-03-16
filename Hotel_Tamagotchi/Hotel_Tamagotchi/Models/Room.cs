using Hotel_Tamagotchi.Models.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models
{
    public class Room
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [RoomSizeValidator]
        public int Size { get; set; }
        [Required]
        public string Type { get; set; }
        public virtual List<Tamagotchi>TamagotchiList { get; set; }

        public Room()
        {
            //TamagotchiList = new List<Tamagotchi>();
        }
    }
}