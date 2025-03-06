using Microsoft.AspNetCore.Mvc;
using ProductsApp.Models;
using ProductsApp.Services;
using ProductsApp.ViewModels;
using System.Diagnostics;

namespace ProductsApp.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductsRestController : ControllerBase
    {
        private readonly ILogger<ProductsRestController> _logger;
        private readonly IProductService productService;
        private readonly IWebHostEnvironment webHost;
        private readonly IConfiguration config;

        public ProductsRestController(ILogger<ProductsRestController> logger, IProductService productService, IWebHostEnvironment webHost, IConfiguration config)
        {
            _logger = logger;
            this.productService = productService;
            this.webHost = webHost;
            this.config = config;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> ShowAllProducts()
        {
            IEnumerable<ProductViewModel> products = await productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("grid")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> ShowAllProductsGrid()
        {
            List<ProductViewModel> products = (await productService.GetAllProducts()).ToList();
            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpGet("update-form/{id}")]
        public async Task<ActionResult<ProductViewModel>> ShowUpdateProductForm(int id)
        {
            ProductViewModel product = await productService.GetProductById(id);
            return Ok(product);
        }

        [HttpGet("update-modal/{id}")]
        public async Task<ActionResult<ProductViewModel>> ShowUpdateModal(int id)
        {
            ProductViewModel product = await productService.GetProductById(id);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> ShowProduct(int id)
        {
            ProductViewModel product = await productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductViewModel pvm)
        {
            if (pvm == null)
            {
                return BadRequest("Product data is required.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProduct = await productService.AddProduct(pvm);
            return CreatedAtAction(nameof(ShowProduct), new { id = pvm.Id }, pvm);
        }


        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> SearchForProducts([FromQuery] string searchTerm, [FromQuery] bool inTitle, [FromQuery] bool inDescription)
        {
            SearchFor searchFor = new SearchFor
            {
                SearchTerm= searchTerm,
                InTitle=inTitle,
                InDescription=inDescription
            };

            var searchResults = await productService.SearchForProducts(searchFor);

            if(searchResults == null)
            {
                return NotFound("Your search didn't match any criteria");
            }

            return Ok(searchResults);
        }
    }
}
