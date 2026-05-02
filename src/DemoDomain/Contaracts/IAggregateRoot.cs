using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDomain.Contaracts
{
    public interface IAggregateRoot<Tkey>
    {
        Tkey Id { get; set; }
    }
}
