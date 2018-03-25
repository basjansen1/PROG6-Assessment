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
                Boredom = 20,
                CurrentRoom = new Room() { Type = "Chillroom"}
            });
            _tamagotchis.Add(new Tamagotchi()
            {
                ID = 2,
                Health = 30,
                Alive = true,
                Boredom = 40,
                CurrentRoom = new Room() { Type = "Workroom" }
            });
            _tamagotchis.Add(new Tamagotchi()
            {
                ID = 3,
                Health = 50,
                Alive = true,
                Boredom = 0,
                CurrentRoom = new Room() { Type = "Gameroom" }
            });
            _tamagotchis.Add(new Tamagotchi()
            {
                ID = 5,
                Health = 30,
                Alive = true,
                Boredom = 20,
                CurrentRoom = new Room() { Type = "DateRoom" }
            });
            _tamagotchis.Add(new Tamagotchi()
            {
                ID = 8,
                Health = 30,
                Alive = true,
                Boredom = 20,
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
            Tamagotchi tamagotchi = _tamagotchis.Find(t => t.ID == model.ID);
            tamagotchi.Health = model.Health;
            tamagotchi.Name = model.Name;
            tamagotchi.Level = model.Level;
        }
    }
}