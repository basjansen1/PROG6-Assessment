using Hotel_Tamagotchi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Helpers
{
    public class ReservationHelper
    {
        public int? SelectedAmountOfTamagotchis { get; set; }
        public Room SelectedRoom { get; set; }
        public List<int> AmountOfTamagotchisOptionList { get; set; }
        public List<Tamagotchi> SelectedTamagotchis { get; set; }

        public ReservationHelper()
        {

        }
        public void Set(Room room)
        {
            this.SelectedRoom = room;
            this.AmountOfTamagotchisOptionList = new List<int>();
            foreach (int option in RoomSizeOptions.SizeOptions)
            {
                if (option <= SelectedRoom.Size)
                {
                    AmountOfTamagotchisOptionList.Add(option);
                }
            }
            SelectedAmountOfTamagotchis = AmountOfTamagotchisOptionList.Min();
        }
    }
}