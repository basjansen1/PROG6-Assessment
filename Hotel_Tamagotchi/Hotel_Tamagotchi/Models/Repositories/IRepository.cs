using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Tamagotchi.Models.Repositories
{
    interface IRepository <T>
    {
        T Get(int id);
        List<T> GetAll();
        void Create(T model);
        void Update(T model);
        void Delete(T model);
    }
}
