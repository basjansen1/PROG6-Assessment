using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Tamagotchi.Models.Repositories
{
    public interface IRepository <T>
    {
        T Get(int id);
        List<T> GetAll();
        T Add(T model);
        void Update(T model);
        void Delete(T model);
    }
}
