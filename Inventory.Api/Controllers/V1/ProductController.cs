using Asp.Versioning;
using Inventory.Api.Services.V1;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers.V1
{
    [ApiVersion("1.0", Deprecated = true)]
    //[Route("api/{version:apiVersion}/[controller]")] 

    [Route("api/[controller]")]
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
