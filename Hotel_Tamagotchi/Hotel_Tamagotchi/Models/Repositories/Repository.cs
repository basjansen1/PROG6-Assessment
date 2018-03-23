using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.Repositories
{
    public abstract class Repository
    {
        protected Hotel_TamagotchiContext _context; 

        public Repository(Hotel_TamagotchiContext context)
        {
            this._context = context;
        }

        ~Repository()
        {
            _context.Dispose();
        }

        protected void ExcecuteSQLCommand(string sql)
        {
            _context.Database.ExecuteSqlCommand(sql);
        }
    }
}