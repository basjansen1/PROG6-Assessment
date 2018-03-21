using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Tamagotchi.Controllers
{
    public class NightController : Controller
    {
        private ITamagotchiRepository _tamagotchiRepository;
        private List<Tamagotchi> _tamagotchis;

        public NightController()
        {
        }

        public NightController(ITamagotchiRepository tamagotchiRepository)
        {
            _tamagotchiRepository = tamagotchiRepository;

            _tamagotchis = _tamagotchiRepository.GetAll();
        }

        public void ChangeProperties()
        {
            foreach (var t in _tamagotchis)
            {
                t.Level++;

                // Standaard mutaties
                if (t.Boredom >= 70)
                    t.Health -= 20;

                if (t.Health <= 0)
                    t.Alive = false;

                // Kamer afhankelijke mutaties
                switch(t.CurrentRoom.Type)
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
                        PickRandomWinner();
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
                _tamagotchiRepository.Update(t);
            }
        }

        /// <summary>
        /// Picks a random winner. 
        /// </summary>
        /// <returns></returns>
        private void PickRandomWinner()
        {
            Random r = new Random();
            int randomWinner = r.Next(_tamagotchis.Count());

            _tamagotchis[randomWinner].Cents += 20 * _tamagotchis.Count() - 1;
            _tamagotchis[randomWinner].Level += 1;

            for (int i = 0; i < _tamagotchis.Count; i++)
            {
                if (i != randomWinner)
                {
                    _tamagotchis[i].Cents -= 20;
                    _tamagotchis[i].Health -= 30;
                }
            }
        }
    }
}