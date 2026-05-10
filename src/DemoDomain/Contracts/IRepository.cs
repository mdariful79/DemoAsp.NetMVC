using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDomain.Contracts
{
    public interface IRepository <TAggregateRoot, TKey>
        where TAggregateRoot : class, IAggregateRoot<TKey>
        where TKey : IComparable
    {
        void Add(TAggregateRoot entity);
        Task AddAsync(TAggregateRoot entity);
    }
}
