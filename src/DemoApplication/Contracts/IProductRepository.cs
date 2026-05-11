using DemoDomain.Contracts;
using DemoDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApplication.Contracts
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
    }
}
