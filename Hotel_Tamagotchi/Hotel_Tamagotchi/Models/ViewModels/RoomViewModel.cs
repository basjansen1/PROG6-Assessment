using System;
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
        public int ID
        {
            get
            {
                return Room.ID;
            }
        }
        public int Size
        {
            get
            {
                return Room.Size;
            }
            set
            {
                Room.Size = value;
            }
        }
        public string Type
        {
            get
            {
                return Room.Type;
            }
            set
            {
                Room.Type = value;
            }
        }
        public List<TamagotchiViewModel> TamagotchiList
        {
            get
            {
                return Room.TamagotchiList.Select(t => new TamagotchiViewModel(t)).ToList();
            }
            set
            {
                Room.TamagotchiList = value.Select(t => t.ToModel()).ToList();
            }
        }
    }
}