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
            List<Tamagotchi> tamagotichiList = tamagotchiRepository.GetAll().Where(t => t.CurrentRoom != null).ToList();

            ProcessChillRoom(tamagotichiList.Where(t => t.CurrentRoom.Type == RoomType.Chillroom.ToString()).ToList());
            ProcessGameRoom(tamagotichiList.Where(t => t.CurrentRoom.Type == RoomType.Gameroom.ToString()).ToList());
            ProcessWorkRoom(tamagotichiList.Where(t => t.CurrentRoom.Type == RoomType.Workroom.ToString()).ToList());
            ProcessFightRoom(tamagotichiList.Where(t => t.CurrentRoom.Type == RoomType.Fightroom.ToString()).ToList());
            ProcessDateRoom(tamagotichiList.Where(t => t.CurrentRoom.Type == RoomType.DateRoom.ToString()).ToList());
            ProcessNoRoom(tamagotchiRepository.GetAll().Where(t => t.CurrentRoom == null).ToList());

            foreach (var t in tamagotchiRepository.GetAll())
            {
                t.Level++;

                // Standaard mutaties
                if (t.Boredom >= 70)
                    t.Health -= 20;

                if (t.Health <= 0)
                    t.Alive = false;
                
                // check for propertie errors
                if (t.Health > 100)
                    t.Health = 100;
                else if (t.Health < 0)
                    t.Health = 0;
                if (t.Boredom < 0)
                    t.Boredom = 0;
                if (t.Boredom > 100)
                    t.Boredom = 100;
                if (t.Cents < 0) 
                {
                    t.Cents = 0;
                }
                else if (t.Cents > 100)
                {
                    t.Cents = 100;
                }

                tamagotchiRepository.Update(t);
            }
        }

        private static void ProcessChillRoom(List<Tamagotchi> tamagotchis)
        {
            foreach(Tamagotchi t in tamagotchis.Where(t => t.CurrentRoom.Type == RoomType.Chillroom.ToString()))
            {
                t.Cents -= 10;
                t.Health += 20;
                t.Boredom += 10;
            }
        }

        private static void ProcessGameRoom(List<Tamagotchi> tamagotchis)
        {
            foreach(Tamagotchi t in tamagotchis.Where(t => t.CurrentRoom.Type == RoomType.Gameroom.ToString()))
            {
                t.Cents -= 20;
                t.Boredom = 0;
            }
        }

        private static void ProcessWorkRoom(List<Tamagotchi> tamagotchis)
        {
            foreach (Tamagotchi t in tamagotchis.Where(t => t.CurrentRoom.Type == RoomType.Workroom.ToString()))
            {
                Random r = new Random();
                int amountEarned = r.Next(10, 60);
                t.Cents += amountEarned;
                t.Boredom += 20;
            }
        }

        private static void ProcessFightRoom(List<Tamagotchi> tamagotchis)
        {
            Random r = new Random();
            int randomWinner = r.Next(tamagotchis.Count());

            tamagotchis[randomWinner].Cents += 20 * tamagotchis.Count() - 1;
            tamagotchis[randomWinner].Level += 1;

            for (int i = 0; i < tamagotchis.Count; i++)
            {
                if (i != randomWinner)
                {
                    tamagotchis[i].Cents -= 20;
                    tamagotchis[i].Health -= 30;
                }
            }
        }

        private static void ProcessDateRoom(List<Tamagotchi> tamagotchis)
        {
            foreach (Tamagotchi t in tamagotchis.Where(t => t.CurrentRoom.Type == RoomType.DateRoom.ToString()))
            {
                t.Cents -= 10;
                t.Boredom -= 30;
                t.Health += 10;
            }
        }

        private static void ProcessNoRoom(List<Tamagotchi> tamagotchis)
        {
            foreach(Tamagotchi t in tamagotchis)
            {
                t.Health -= 20;
                t.Boredom += 20;
            }
        }
    }
}