using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.ViewModels
{
    public class TamagotchiViewModel
    {
        public int ID
        {
            get
            {
                return _tamagotchi.ID;
            }
        }
        public string Name
        {
            get
            {
                return _tamagotchi.Name;
            }
            set
            {
                _tamagotchi.Name = value;
            }
        }
        public int Age
        {
            get
            {
                return _tamagotchi.Age;
            }
            set
            {
                _tamagotchi.Age = value;
            }
        }
        public int Cents
        {
            get
            {
                return _tamagotchi.Cents;
            }
            set
            {
                _tamagotchi.Cents = value;
            }
        }
        public int Health
        {
            get
            {
                return _tamagotchi.Health;
            }
            set
            {
                _tamagotchi.Health = value;
            }
        }
        public int Boredom
        {
            get
            {
                return _tamagotchi.Boredom;
            }
            set
            {
                _tamagotchi.Boredom = value;
            }
        }
        public bool Alive
        {
            get
            {
                return _tamagotchi.Alive;
            }
            set
            {

                _tamagotchi.Alive = value;
            }
        }
        public Room CurrentRoom
        {
            get
            {
                return _tamagotchi.CurrentRoom;
            }
            set
            {
                _tamagotchi.CurrentRoom = value;
            }
        }
        public TamagotchiViewModel()
        {
            this._tamagotchi = new Tamagotchi();
        }

        public TamagotchiViewModel(Tamagotchi tamagotchi)
        {
            this._tamagotchi = tamagotchi;
        }

        private Tamagotchi _tamagotchi;

        public Tamagotchi ToModel()
        {
            return _tamagotchi;
        }
    }
}