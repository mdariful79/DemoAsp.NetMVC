using DemoApplication.Features.Products.Query;
using DemoDomain.Contracts;
using DemoDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApplication.Contracts
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<(IList<Product>, int, int)> GetPagedProducts(GetAllProductByPagingQuery query,
            CancellationToken cancellationToken);
        Task<bool> IsDuplicateProductName(string name, CancellationToken cancellationToken);

    }
}
