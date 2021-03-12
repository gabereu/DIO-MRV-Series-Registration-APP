using System.Collections.Generic;

namespace interfaces
{
    public interface IRepository<T>
    {
        List<T> Listing();
        T GetById(int id);
        void Push(T entity);

        void Remove(int id);

        void Update(T entity);

        int NextId();
    }
}