using Cortex.Mediator.Queries;
using DemoDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApplication.Features.Products.Query
{
    public class GetAllProductByPagingQuery : IQuery<(IList<Product>, int, int)>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }
        public string SortText { get; set; }
    }
}
