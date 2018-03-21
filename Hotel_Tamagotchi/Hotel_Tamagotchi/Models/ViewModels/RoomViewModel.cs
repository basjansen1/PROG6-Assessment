using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.ViewModels
{
    public class RoomViewModel
    {
        public int? SelectedAmountOfTamagotchis { get; set; }
        public List<int> AmountOfTamagotchisOptionList { get; set; }
        public List<Tamagotchi> SelectedTamagotchis { get; set; }
        public RoomViewModel()
        {
            this.Room = new Room();
        }

        public RoomViewModel(Room room)
        {
            this.Room = room;
        }

        public Room Room { get; set; }
    }
}