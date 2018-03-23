using Hotel_Tamagotchi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.Repositories
{
    public class TamagotchiRepository : Repository, ITamagotchiRepository
    {
        public TamagotchiRepository(Hotel_TamagotchiContext context) : base(context)
        {
        }

        public void Add(Tamagotchi tamagotchi)
        {
            this._context.Tamagotchis.Add(tamagotchi);
            this._context.SaveChanges();
        }

        public void Delete(Tamagotchi tamagotchi)
        {
            this._context.Tamagotchis.Remove(tamagotchi);
            this._context.SaveChanges();
        }

        public Tamagotchi Get(int id)
        {
            return this._context.Tamagotchis.Include("CurrentRoom").Where(t => t.ID == id).First();
        }

        public List<Tamagotchi> GetAll()
        {
            return this._context.Tamagotchis.Include("CurrentRoom").ToList();
        }

        public void Update(Tamagotchi tamagotchi)
        {
            this._context.Entry(tamagotchi).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}