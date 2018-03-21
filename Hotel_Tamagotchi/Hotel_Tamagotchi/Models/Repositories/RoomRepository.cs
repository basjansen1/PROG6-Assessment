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

        public void Add(RoomViewModel room)
        {
            this._context.Rooms.Add(room.Room);
            this._context.SaveChanges();
        }

        public void Delete(RoomViewModel room)
        {
            this._context.Rooms.Remove(room.Room);
            this._context.SaveChanges();
        }

        public RoomViewModel Get(int id)
        {
            return new RoomViewModel(this._context.Rooms.Include("TamagotchiList").Where(t => t.ID == id).First());
        }

        public List<RoomViewModel> GetAll()
        {
            return this._context.Rooms.Include("TamagotchiList").Select(r => new RoomViewModel(r)).ToList();
        }

        public void Update(RoomViewModel room)
        {
            this._context.Entry(room.Room).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}