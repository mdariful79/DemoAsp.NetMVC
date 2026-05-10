using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDomain.Contracts
{
    public interface IAggregateRoot<TKey>
    {
        TKey Id { get; set; }
    }
}
