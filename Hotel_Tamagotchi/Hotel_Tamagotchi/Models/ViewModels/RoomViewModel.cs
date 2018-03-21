﻿using System;
using System.Collections.Generic;
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
        
    }
}