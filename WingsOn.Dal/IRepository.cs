using System.Collections.Generic;
using WingsOn.Domain;
using WingsOn.Domain.BaseObjects;

namespace WingsOn.Dal
{
    public interface IRepository<T> where T : DomainEntity
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Save(T element);
    }
}
