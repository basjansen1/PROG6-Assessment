﻿using Hotel_Tamagotchi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Tamagotchi.Models.Repositories
{
    public interface ITamagotchiRepository : IRepository<Tamagotchi>
    {
        void SetRoom(Room room, Tamagotchi tamagotchi);
    }
}
