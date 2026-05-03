using System;
using System.Collections.Generic;
using System.Text;

namespace DemoInfrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public interface IUnitOfWork
    {
    }
}
