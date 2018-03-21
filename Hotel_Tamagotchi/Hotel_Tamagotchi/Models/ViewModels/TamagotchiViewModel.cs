using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.ViewModels
{
    public class TamagotchiViewModel
    {
        public Tamagotchi Tamagotchi { get; set; }
        public int ID
        {
            get
            {
                return Tamagotchi.ID;
            }
        }
        public string Name
        {
            get
            {
                return Tamagotchi.Name;
            }
            set
            {
                Tamagotchi.Name = value;
            }
        }
        public int Age
        {
            get
            {
                return Tamagotchi.Age;
            }
            set
            {
                Tamagotchi.Age = value;
            }
        }
        public int Cents
        {
            get
            {
                return Tamagotchi.Cents;
            }
            set
            {
                Tamagotchi.Cents = value;
            }
        }
        public int Health
        {
            get
            {
                return Tamagotchi.Health;
            }
            set
            {
                Tamagotchi.Health = value;
            }
        }
        public int Boredom
        {
            get
            {
                return Tamagotchi.Boredom;
            }
            set
            {
                Tamagotchi.Boredom = value;
            }
        }
        public bool Alive
        {
            get
            {
                return Tamagotchi.Alive;
            }
            set
            {

                Tamagotchi.Alive = value;
            }
        }
        public RoomViewModel CurrentRoom
        {
            get
            {
                return new RoomViewModel (Tamagotchi.CurrentRoom);
            }
            set
            {
                Tamagotchi.CurrentRoom = value.ToModel();
            }
        }
        public TamagotchiViewModel()
        {
            this.Tamagotchi = new Tamagotchi();
        }

        public TamagotchiViewModel(Tamagotchi tamagotchi)
        {
            Tamagotchi = tamagotchi;
        }

    }
}