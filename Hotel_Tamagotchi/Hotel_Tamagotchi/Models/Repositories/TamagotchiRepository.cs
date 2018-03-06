using Hotel_Tamagotchi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.Repositories
{
    public class TamagotchiRepository : Repository<TamagotchiViewModel>
    {
        public TamagotchiRepository(Hotel_TamagotchiContext context) : base(context)
        {
        }

        public override void Add(TamagotchiViewModel tamagotchiViewModel)
        {
            this._context.Tamagotchis.Add(tamagotchiViewModel.ToModel());
            this._context.SaveChanges();
        }

        public override void Delete(TamagotchiViewModel tamagotchiViewModel)
        {
            this._context.Tamagotchis.Remove(tamagotchiViewModel.ToModel());
            this._context.SaveChanges();
        }

        public override TamagotchiViewModel Get(int id)
        {
            return new TamagotchiViewModel (this._context.Tamagotchis.Find(id));
        }

        public override List<TamagotchiViewModel> GetAll()
        {
            return this._context.Tamagotchis.Select(t => new TamagotchiViewModel(t)).ToList();
        }

        public override void Update(TamagotchiViewModel tamagotchiViewModel)
        {
            this._context.Entry(tamagotchiViewModel.ToModel()).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}