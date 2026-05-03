using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDomain.Contaracts
{
    public class IUnitOfWork
    {
        void Save();
        void SaveAsync();
    }
}
