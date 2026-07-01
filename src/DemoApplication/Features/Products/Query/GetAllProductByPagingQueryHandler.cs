using Cortex.Mediator.Queries;
using DemoApplication.Contracts;
using DemoDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApplication.Features.Products.Query
{
    public class GetAllProductsByPagingQueryHandler : IQueryHandler<GetAllProductByPagingQuery, (IList<Product>, int, int)>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public GetAllProductsByPagingQueryHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public async Task<(IList<Product>, int, int)> Handle(GetAllProductByPagingQuery query,
            CancellationToken cancellationToken)
        {
            return await _applicationUnitOfWork.ProductRepository.GetPagedProducts(query, cancellationToken);
        }
    }
}
