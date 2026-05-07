using DemoDomain.Contaracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoInfrastructure.Data
{
    public interface Repository<TAggregateRoot, TKey> : IRepository<TAggregateRoot, TKey>
        where TAggregateRoot : class, IAggregateRoot<TKey>
        where TKey : IComparable
    {
        void Add(TAggregateRoot entity);
        void AddAsync(TAggregateRoot entity);
        
    }
}
