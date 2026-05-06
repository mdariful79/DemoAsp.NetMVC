using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDomain.Contaracts
{
    public interface IRepository <TAggregateRoot, TKey>
        where TAggregateRoot : class, IAggregateRoot<TKey>
        where TKey : IComparable
    {
    }
}
