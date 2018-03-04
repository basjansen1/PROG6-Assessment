using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected Hotel_TamagotchiContext _context; //Todo: instanciëren (_context = new Context)

        public Repository(Hotel_TamagotchiContext context)
        {
            this._context = context;
        }
        public abstract void Create(T model);
        public abstract void Delete(T model);
        public abstract T Get(int id);
        public abstract List<T> GetAll();
        public abstract void Update(T model);
    }
}