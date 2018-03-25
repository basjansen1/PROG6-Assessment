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
                t.Level++;

                // Standaard mutaties
                if (t.Boredom >= 70)
                    t.Health -= 20;

                if (t.Health <= 0)
                    t.Alive = false;

                if (t.CurrentRoom != null)
                {
                    // Kamer afhankelijke mutaties
                    switch (t.CurrentRoom.Type)
                    {
                        case "Chillroom":
                            t.Cents -= 10;
                            t.Health += 20;
                            t.Boredom += 10;
                            break;
                        case "Gameroom":
                            t.Cents -= 10;
                            t.Boredom = 0;
                            break;
                        case "Workroom":
                            Random r = new Random();
                            int amountEarned = r.Next(10, 60);
                            t.Cents += amountEarned;
                            t.Boredom += 20;
                            break;
                        case "Fightroom":
                            PickRandomWinner(tamagotchiRepository.GetAll());
                            break;
                        case "DateRoom":
                            t.Cents -= 10;
                            t.Boredom -= 30;
                            t.Health += 10;
                            break;
                        default:
                            // Geen kamer
                            t.Health -= 20;
                            t.Boredom += 20;
                            break;
                    }
                }

                if (t.Health > 100)
                    t.Health = 100;
                if (t.Boredom > 100)
                    t.Boredom = 100;

                tamagotchiRepository.Update(t);
            }
        }

        /// <summary>
        /// Picks a random winner. 
        /// </summary>
        /// <returns></returns>
        private static void PickRandomWinner(List<Tamagotchi> tamagotchis)
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
    }
}