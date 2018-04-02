using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Helpers
{
    public class NightHelper
    {
        public static void ChangeProperties(ITamagotchiRepository tamagotchiRepository)
        {
            foreach (var t in tamagotchiRepository.GetAll())
            {
                // Standaard mutaties
                t.Level++;
                if (t.Boredom >= 70)
                    EditHealt(t,- 20);

                if (t.Health <= 0)
                    t.Alive = false;
            }
            // mutaties per kamer
            List<Tamagotchi> tamagotichiList = tamagotchiRepository.GetAll().Where(t => t.CurrentRoom != null).ToList();
            ProcessChillRoom(tamagotichiList.Where(t => t.CurrentRoom.Type == RoomType.Chillroom.ToString()).ToList());
            ProcessGameRoom(tamagotichiList.Where(t => t.CurrentRoom.Type == RoomType.Gameroom.ToString()).ToList());
            ProcessWorkRoom(tamagotichiList.Where(t => t.CurrentRoom.Type == RoomType.Workroom.ToString()).ToList());
            ProcessFightRoom(tamagotichiList.Where(t => t.CurrentRoom.Type == RoomType.Fightroom.ToString()).ToList());
            ProcessDateRoom(tamagotichiList.Where(t => t.CurrentRoom.Type == RoomType.DateRoom.ToString()).ToList());
            ProcessNoRoom(tamagotchiRepository.GetAll().Where(t => t.CurrentRoom == null).ToList());

            foreach (var t in tamagotchiRepository.GetAll())
            {
                // update tamagotchis
                tamagotchiRepository.Update(t);
            }
        }

        private static void ProcessChillRoom(List<Tamagotchi> tamagotchis)
        {
            foreach(Tamagotchi t in tamagotchis.Where(t => t.CurrentRoom.Type == RoomType.Chillroom.ToString()))
            {
                EditCents(t, -10);
                EditHealt(t, 20);
                EditBoredom(t, 10);
            }
        }

        private static void ProcessGameRoom(List<Tamagotchi> tamagotchis)
        {
            foreach(Tamagotchi t in tamagotchis.Where(t => t.CurrentRoom.Type == RoomType.Gameroom.ToString()))
            {
                EditCents(t, -20);
                t.Boredom = 0;
            }
        }

        private static void ProcessWorkRoom(List<Tamagotchi> tamagotchis)
        {
            foreach (Tamagotchi t in tamagotchis.Where(t => t.CurrentRoom.Type == RoomType.Workroom.ToString()))
            {
                Random r = new Random();
                int amountEarned = r.Next(10, 60);
                EditCents(t, amountEarned);
                EditBoredom(t, 20);
            }
        }

        private static void ProcessFightRoom(List<Tamagotchi> tamagotchis)
        {
            if (tamagotchis.Count() != 0)
            {
                Random r = new Random();
                int randomWinner = r.Next(tamagotchis.Count());

                EditCents(tamagotchis[randomWinner], 20 * tamagotchis.Count() - 1);
                tamagotchis[randomWinner].Level += 1;

                for (int i = 0; i < tamagotchis.Count; i++)
                {
                    if (i != randomWinner)
                    {
                        EditCents(tamagotchis[i], -20);
                        EditHealt(tamagotchis[i], -30);
                    }
                }
            }
        }

        private static void ProcessDateRoom(List<Tamagotchi> tamagotchis)
        {
            foreach (Tamagotchi t in tamagotchis.Where(t => t.CurrentRoom.Type == RoomType.DateRoom.ToString()))
            {
                EditCents(t, -10);
                EditBoredom(t, -30);
                EditHealt(t, 10);
            }
        }

        private static void ProcessNoRoom(List<Tamagotchi> tamagotchis)
        {
            foreach(Tamagotchi t in tamagotchis)
            {
                EditHealt(t, -20);
                EditBoredom(t, 20);
            }
        }

        private static void EditCents(Tamagotchi t, int digit)
        {
            t.Cents += digit;

            if (t.Cents < 0)
            {
                t.Cents = 0;
            }
            else if (t.Cents > 100)
            {
                t.Cents = 100;
            }
        }

        private static void EditHealt(Tamagotchi t, int digit)
        {
            t.Health += digit;

            if (t.Health > 100)
            {
                t.Health = 100;
            }
            else if (t.Health < 0)
            {
                t.Health = 0;
            }
        }

        private static void EditBoredom(Tamagotchi t, int digit)
        {
            t.Boredom += digit;

            if (t.Boredom < 0)
            {
                t.Boredom = 0;
            }
            else if (t.Boredom > 100)
            {
                t.Boredom = 100;
            }
        }
    }
}