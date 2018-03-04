using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.Repositories
{
    public class TamagotchiRepository : Repository<Tamagotchi>
    {
        public TamagotchiRepository(Hotel_TamagotchiContext context) : base(context)
        {
        }

        public override void Create(Tamagotchi model)
        {
            this._context.Tamagotchis.Add(model);
            this._context.SaveChanges();
        }

        public override void Delete(Tamagotchi model)
        {
            this._context.Tamagotchis.Remove(model);
            this._context.SaveChanges();
        }

        public override Tamagotchi Get(int id)
        {
            return this._context.Tamagotchis.Find(id);
        }

        public override List<Tamagotchi> GetAll()
        {
            return this._context.Tamagotchis.ToList();
        }

        public override void Update(Tamagotchi model)
        {
            this._context.Entry(model).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}