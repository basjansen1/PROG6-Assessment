using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.Repositories
{
    public class DummyTamagotchiRepository : ITamagotchiRepository
    {
        private List<Tamagotchi> _tamagotchis;

        public DummyTamagotchiRepository()
        {
            _tamagotchis = new List<Tamagotchi>();

            _tamagotchis.Add(new Tamagotchi()
            {
                ID = 1,
                Health = 30,
                Alive = true,
                Boredom = 20
            });
            _tamagotchis.Add(new Tamagotchi()
            {
                ID = 2,
                Health = 30,
                Alive = true,
                Boredom = 40
            });
            _tamagotchis.Add(new Tamagotchi()
            {
                ID = 3,
                Health = 50,
                Alive = true,
                Boredom = 0
            });
        }
        public Tamagotchi Add(Tamagotchi model)
        {
            _tamagotchis.Add(model);

            return model;
        }

        public void Delete(Tamagotchi model)
        {
            _tamagotchis.Remove(model);
        }

        public Tamagotchi Get(int id)
        {
            return _tamagotchis[id];
        }

        public List<Tamagotchi> GetAll()
        {
            return _tamagotchis;
        }

        public void SetRoom(Room room, Tamagotchi tamagotchi)
        {
            throw new NotImplementedException();
        }

        public void Update(Tamagotchi model)
        {
            throw new NotImplementedException();
        }
    }
}