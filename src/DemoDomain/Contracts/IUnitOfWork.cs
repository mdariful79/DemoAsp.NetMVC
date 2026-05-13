using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDomain.Contracts
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
    }
}
