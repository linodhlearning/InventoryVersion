using Asp.Versioning;
using Inventory.Api.Services.V2;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers.V2
{
    //[Route("api/{version:apiVersion}/[controller]")]

    [Route("api/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }
    }
}
