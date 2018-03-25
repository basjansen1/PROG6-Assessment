using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.Repositories
{
    public class DummyRoomRepository : IRoomRepository
    {
        private List<Room> _rooms;

        public DummyRoomRepository()
        {
            _rooms = new List<Room>();

            _rooms.Add(new Room() { ID = 1, Size = 3 });
            _rooms.Add(new Room() { ID = 2, Size = 5 });

        }
        public Room Add(Room model)
        {
            _rooms.Add(model);

            return model;
        }

        public void Delete(Room model)
        {
            _rooms.Remove(model);
        }

        public Room Get(int id)
        {
            return _rooms[id];
        }

        public List<Room> GetAll()
        {
            return _rooms;
        }

        public void Update(Room model)
        {
            throw new NotImplementedException();
        }
    }
}