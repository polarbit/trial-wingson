using System.Collections.Generic;
using WingsOn.Domain;
using WingsOn.Domain.BaseObjects;
using WingsOn.Domain.Entities;

namespace WingsOn.Dal
{
    public interface IRepository<T> where T : DomainEntity
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Save(T element);
    }
}
