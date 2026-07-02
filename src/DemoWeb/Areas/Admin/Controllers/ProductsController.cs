using Cortex.Mediator;
using DemoApplication.Features.Products.Query;
using DemoDomain.Entities;
using DemoDomain.Utilities;
using DemoWeb.Areas.Admin.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DemoWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(ILogger<ProductsController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetPagedProducts([FromForm] ProductListModel model)
        {
            try
            {
                var query = _mapper.Map<GetAllProductByPagingQuery>(model);
                query.SearchText = model.Search.Value;
                query.SortText = model.FormatSortExpression("Name", "Price");

                var (items, total, totalDisplay) = await _mediator.SendQueryAsync<GetAllProductByPagingQuery,
                    (IList<Product>, int, int)>(query);

                var product = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = (from item in items
                            select new string[]
                            {
                                HttpUtility.HtmlEncode(item.Name),
                                item.Price.ToString(),
                                item.Id.ToString()
                            }).ToArray()
                };

                return Json(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get product list");

                return Json(DataTables.EmptyResult);
            }
        }
    }
}