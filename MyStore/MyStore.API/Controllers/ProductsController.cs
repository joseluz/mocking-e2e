using Microsoft.AspNetCore.Mvc;
using MyStore.API.Resources;
using MyStore.Application.Services;

namespace MyStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ProductResource>>> FindAll()
        {
            var products = await productService.FindAll();
            var productResources = products.Select(p => new ProductResource()
            {
                Id = p.Id,
                Key = p.Key,
                Name = p.Name,
                CurrentValue = p.CurrentValue
            });
            return Ok(productResources);
        }
    }
}
