using DemoApplication.Contracts;
using DemoApplication.Features.Products.Query;
using DemoDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoInfrastructure.Data.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(IList<Product>, int, int)> GetPagedProducts(GetAllProductByPagingQuery query,
            CancellationToken cancellationToken)
        {
            return await GetDynamicAsync(x => query.SearchText == null || x.Name.Contains(query.SearchText),
                 query.SortText,
                 null,
                 query.PageIndex,
                 query.PageSize,
                 true,
                 cancellationToken);
        }
    }
}
