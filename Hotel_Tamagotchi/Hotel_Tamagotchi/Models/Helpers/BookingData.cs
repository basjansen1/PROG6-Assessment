using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.Helpers
{
    public class BookingData
    {
        public int SelectedAmountOfTamagotchis { get; set; }
        public Room SelectedRoom { get; set; }
        public List<int> AmountOfTamagotchisOptionList { get; set; }

        public BookingData(Room room)
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
        }
    }
}