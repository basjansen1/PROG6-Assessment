using Hotel_Tamagotchi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Helpers.Validators
{
    public class ReservationValidator
    {
        public static bool ValidateSelectedAmount(RoomViewModel roomViewModel)
        {
            if (roomViewModel.AmountOfTamagotchis <= roomViewModel.Room.Size && roomViewModel.AmountOfTamagotchis != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateSelectTamagotchis(RoomViewModel roomViewModel) // testbaar voor unit test
        {
            if (roomViewModel.SelectedTamagotchisIDList.Count() <= roomViewModel.AmountOfTamagotchis && roomViewModel.SelectedTamagotchisIDList.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}