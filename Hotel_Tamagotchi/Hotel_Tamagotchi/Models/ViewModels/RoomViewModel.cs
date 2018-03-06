using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.ViewModels
{
    public class RoomViewModel
    {
        public int ID
        {
            get
            {
                return _room.ID;
            }
        }
        public int Size
        {
            get
            {
                return _room.Size;
            }
            set
            {
                _room.Size = value;
            }
        }
        public string Type
        {
            get
            {
                return _room.Type;
            }
            set
            {
                _room.Type = value;
            }
        }
        public List<TamagotchiViewModel> TamagotchiList
        {
            get
            {
                return _room.TamagotchiList.Select(t => new TamagotchiViewModel(t)).ToList();
            }
            set
            {
                _room.TamagotchiList = value.Select(t => t.ToModel()).ToList();
            }
        }
        public RoomViewModel()
        {
            this._room = new Room();
        }

        public RoomViewModel(Room room)
        {
            this._room = room;
        }

        private Room _room;

        public Room ToModel()
        {
            return _room;
        }
    }
}