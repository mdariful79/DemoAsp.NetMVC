using DemoDomain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApplication.Contracts
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        public IProductRepository ProductRepository { get;  }
    }
}
