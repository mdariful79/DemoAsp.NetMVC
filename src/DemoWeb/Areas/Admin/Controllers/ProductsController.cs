using Cortex.Mediator;
using DemoApplication.Exceptions;
using DemoApplication.Features.Products.Command;
using DemoApplication.Features.Products.Query;
using DemoDomain.Entities;
using DemoDomain.Utilities;
using DemoInfrastructure.Extensions;
using DemoWeb.Areas.Admin.Models;
using DemoWeb.Codes;
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

        public IActionResult Create()
        {
            var model = new ProductCreateModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var command = _mapper.Map<ProductAddCommand>(model);
                    var result = await _mediator.SendCommandAsync(command);

                    TempData.Put(Constants.ResponseTempKey,
                        new ResponseModel
                        {
                            Message = "Product successfully crated.",
                            Type = ResponseTypes.Success
                        });

                    return RedirectToAction(nameof(Index));
                }
                catch (DuplicateDataException oex)
                {
                    TempData.Put(Constants.ResponseTempKey,
                        new ResponseModel
                        {
                            Message = oex.Message,
                            Type = ResponseTypes.Danger
                        });
                }
                catch (Exception ex)
                {
                    const string errorMessage = "Failed to create product.";

                    _logger.LogError(ex, errorMessage);

                    TempData.Put(Constants.ResponseTempKey,
                        new ResponseModel
                        {
                            Message = errorMessage,
                            Type = ResponseTypes.Danger
                        });
                }
            }
            else
            {
                TempData.Put(Constants.ResponseTempKey,
                    new ResponseModel
                    {
                        Message = "Please provide all information.",
                        Type = ResponseTypes.Success
                    });
            }

            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> GetPagedProducts([FromBody] ProductListModel model)
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
