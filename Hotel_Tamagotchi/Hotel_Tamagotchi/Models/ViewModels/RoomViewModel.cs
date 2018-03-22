using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.ViewModels
{
    public class RoomViewModel
    {

        public Room Room { get; set; }
        public List<Tamagotchi> Tamagotichis { get; set; }
        public int AmountOfTamagotchis { get; set; }
        public List<int> AmountOfTamagotchisOptions { get; set; }
        public List<int> SelectedTamagotchisIDList { get; set; }

        public RoomViewModel()
        {
            SelectedTamagotchisIDList = new List<int>();
        }
    }
}