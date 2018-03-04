using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.Repositories
{
    public class RoomRepository : Repository<Room>
    {
        public RoomRepository(Hotel_TamagotchiContext context) : base(context)
        {
        }

        public override void Create(Room model)
        {
            this._context.Rooms.Add(model);
            this._context.SaveChanges();
        }

        public override void Delete(Room model)
        {
            this._context.Rooms.Remove(model);
            this._context.SaveChanges();
        }

        public override Room Get(int id)
        {
            return this._context.Rooms.Find(id);
        }

        public override List<Room> GetAll()
        {
            return this._context.Rooms.ToList();
        }

        public override void Update(Room model)
        {
            this._context.Entry(model).State = EntityState.Modified;
        }
    }
}