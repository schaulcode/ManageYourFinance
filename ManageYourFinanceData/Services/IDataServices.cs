using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.Data.Services
{
    public interface IDataServices<T>
    {
        void Add(T data);
        T Get(int id);
        List<T> GetAll(int? id = null, Type relationDb = null);
        List<T> GetAll(string columnName, DateTime date, string expression = "=");
        void Edit(int id, T data);
        void Delete(int id);

    }
}
