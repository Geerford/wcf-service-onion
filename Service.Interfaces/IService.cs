using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IService<T> where T : class
    {
        T Create(T model);

        T Delete(T model);

        void Dispose();

        T Edit(T model);

        T Get(int? id);

        IEnumerable<T> GetAll();
    }
}