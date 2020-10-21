using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.Data.Services
{
    interface IDataServices<T>
    {
        void Add(T data);
        T Get(int id);
        List<T> GetAll();
        void Edit(int id, T data);
        void Delete(int id);

    }
}
