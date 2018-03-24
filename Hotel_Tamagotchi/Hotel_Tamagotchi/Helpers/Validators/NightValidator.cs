using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Helpers.Validators
{
    public class NightValidator
    {
        public static void UnlinkRooms(List<Tamagotchi> _tamagotchis, ITamagotchiRepository _tamagotchiRepository)
        {
            foreach (var t in _tamagotchis)
            {
                t.CurrentRoom = null;
                _tamagotchiRepository.Update(t);
            }
        }
    }
}