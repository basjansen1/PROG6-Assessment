using Hotel_Tamagotchi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Helpers.Validators
{
    public class RoomValidator
    {
        public static bool CanDelete(IRoomRepository roomRepository)
        {
            if (roomRepository.GetAll().Count() > 4)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}