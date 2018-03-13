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

        public void Add(RoomViewModel roomViewModel)
        {
            this._context.Rooms.Add(roomViewModel.ToModel());
            this._context.SaveChanges();
        }

        public void Delete(RoomViewModel roomViewModel)
        {
            this._context.Rooms.Remove(roomViewModel.ToModel());
            this._context.SaveChanges();
        }

        public RoomViewModel Get(int id)
        {
            return new RoomViewModel(this._context.Rooms.Find(id));
        }

        public List<RoomViewModel> GetAll()
        {
            return this._context.Rooms.Select(r => new RoomViewModel(r)).ToList();
        }

        public void Update(RoomViewModel roomViewModel)
        {
            this._context.Entry(roomViewModel.ToModel()).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}