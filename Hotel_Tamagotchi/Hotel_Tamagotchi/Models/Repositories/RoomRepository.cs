using Hotel_Tamagotchi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.Repositories
{
    public class RoomRepository : Repository, IRoomRepository
    {
        public RoomRepository(Hotel_TamagotchiContext context) : base(context)
        {
        }

        public void Add(Room room)
        {
            this._context.Rooms.Add(room);
            this._context.SaveChanges();
        }

        public void Delete(Room room)
        {
            this._context.Rooms.Remove(room);
            this._context.SaveChanges();
        }

        public Room Get(int id)
        {
            return this._context.Rooms.Include("TamagotchiList").Where(t => t.ID == id).First();
        }

        public List<Room> GetAll()
        {
            return this._context.Rooms.Include("TamagotchiList").ToList();
        }

        public void Update(Room room)
        {
            this._context.Entry(room).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}