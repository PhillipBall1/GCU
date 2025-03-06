using Microsoft.AspNetCore.Mvc;
using ProductsApp.Models;
using ProductsApp.Services;
using ProductsApp.ViewModels;
using System.Diagnostics;

namespace ProductsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly IWebHostEnvironment webHost;
        private readonly IConfiguration config;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IWebHostEnvironment webHost, IConfiguration config)
        {
            _logger = logger;
            this.productService = productService;
            this.webHost = webHost;
            this.config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShowCreateProductForm()
        {
            ViewBag.TaxRate = decimal.Parse(config["ProductMapper:TaxRate"]);
            ViewBag.Images = GetImageNames();

            var pvm = new ProductViewModel();
            pvm.CreatedAt = DateTime.Now;
            return View(pvm);
        }

        private List<string> GetImageNames()
        {
            string imageFolderPath = Path.Combine(webHost.WebRootPath, "images");

            if(!Directory.Exists(imageFolderPath)) 
            { 
                Directory.CreateDirectory(imageFolderPath);
            }
            return Directory.EnumerateFiles(imageFolderPath).Select(fileName => Path.GetFileName(fileName)).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel pvm)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Error Checking:\n");

                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Field: {state.Key}, Error: {error.ErrorMessage}");
                    }
                }

                ViewBag.TaxRate = decimal.Parse(config["ProductMapper:TaxRate"]);
                ViewBag.Images = GetImageNames();
                return View("ShowCreateProductForm", pvm);
            }

            if (pvm.ImageFile != null)
            {
                pvm.ImageURL = await PerformFileUpload(pvm);
            }

            await productService.AddProduct(pvm);
            return RedirectToAction(nameof(Index));
        }


        private async Task<string> PerformFileUpload(ProductViewModel pvm)
        {
            if (pvm.ImageFile == null) return "";

            if (pvm.ImageFile.Length == 0) return "";

            string uploadsFolder = Path.Combine(webHost.WebRootPath, "images");

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + pvm.ImageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using(var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await pvm.ImageFile.CopyToAsync(fileStream);
            }

            return uniqueFileName;
        }

        public async Task<IActionResult> ShowAllProducts()
        {
            IEnumerable<ProductViewModel> products = await productService.GetAllProducts();
            return View(products);
        }

        public async Task<IActionResult> ShowAllProductsGrid()
        {
            ViewBag.TaxRate = decimal.Parse(config["ProductMapper:TaxRate"]);
            ViewBag.Images = GetImageNames();

            List<ProductViewModel> products = (await productService.GetAllProducts()).ToList();

            return View(products);
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await productService.DeleteProduct(id);
            return RedirectToAction("ShowAllProducts");
        }

        public async Task<IActionResult> ShowUpdateProductForm(int id)
        {
            ViewBag.TaxRate = decimal.Parse(config["ProductMapper:TaxRate"]);
            ViewBag.Images = GetImageNames();

            ProductViewModel product = await productService.GetProductById(id);
            return View(product);
        }

        public async Task<IActionResult> ShowUpdateModal(int id)
        {
            ViewBag.TaxRate = decimal.Parse(config["ProductMapper:TaxRate"]);
            ViewBag.Images = GetImageNames();

            ProductViewModel product = await productService.GetProductById(id);
            return PartialView(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductViewModel pvm)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Error Checking:\n");

                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Field: {state.Key}, Error: {error.ErrorMessage}");
                    }
                }

                ViewBag.TaxRate = decimal.Parse(config["ProductMapper:TaxRate"]);
                ViewBag.Images = GetImageNames();
                return View("ShowUpdateProductForm", pvm);
            }

            if (pvm.ImageFile != null) pvm.ImageURL = await PerformFileUpload(pvm);

            await productService.UpdateProduct(pvm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductFromModal(ProductViewModel pvm)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Error Checking:\n");

                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Field: {state.Key}, Error: {error.ErrorMessage}");
                    }
                }

                ViewBag.TaxRate = decimal.Parse(config["ProductMapper:TaxRate"]);
                ViewBag.Images = GetImageNames();
                return PartialView("ShowUpdateModal", pvm);
            }

            if (pvm.ImageFile != null) pvm.ImageURL = await PerformFileUpload(pvm);

            await productService.UpdateProduct(pvm);

            if (!int.TryParse(pvm.Id, out int productId)) return BadRequest("Invalid product ID.");

            ProductViewModel product = await productService.GetProductById(productId);


            return PartialView("_ProductCard", product);
        }

        public IActionResult ShowSearchForm()
        {
            return View();
        }

        public async Task<IActionResult> SearchForProducts(SearchFor search)
        {
            List<ProductViewModel> results = (await productService.SearchForProducts(search)).ToList();

            ViewBag.SearchTerm = search.SearchTerm;
            ViewBag.InTitle = search.InTitle;
            ViewBag.InDescription = search.InDescription;

            return View("SearchForProducts", results);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ShowProduct(int id)
        {
            ProductViewModel product = await productService.GetProductById(id);
            return View(product);
        }
    }
}