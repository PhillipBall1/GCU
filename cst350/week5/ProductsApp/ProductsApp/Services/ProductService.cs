using ProductsApp.Models;
using ProductsApp.ViewModels;

namespace ProductsApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDAO productDAO;
        private readonly IProductMapper productMapper;

        public ProductService(IProductDAO productDAO, IProductMapper productMapper)
        {
            this.productDAO = productDAO;
            this.productMapper = productMapper;
        }

        public async Task<int> AddProduct(ProductViewModel product)
        {
            var productDTO = productMapper.ToDTO(product);
            var productModel = productMapper.ToModel(productDTO);
            return await productDAO.AddProduct(productModel);
        }

        public async Task DeleteProduct(string Id)
        {
            int productId;
            if (int.TryParse(Id, out productId))
            {
                var productModel = await productDAO.GetProductById(productId);
                if (productModel != null)
                {
                    await productDAO.DeleteProduct(productModel);
                }
            }
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            IEnumerable<ProductModel> productModels = await productDAO.GetAllProducts();

            List<ProductViewModel> productsVM = new List<ProductViewModel>();

            foreach(ProductModel productModel in productModels)
            {
                ProductDTO productDTO = productMapper.ToDTO(productModel);

                ProductViewModel productVM = productMapper.ToViewModel(productDTO);

                productsVM.Add(productVM);
            }

            return productsVM;
        }

        public async Task<ProductViewModel> GetProductById(int id)
        {
            var productModel = await productDAO.GetProductById(id);
            if (productModel == null)
            {
                return null;
            }

            var productDTO = productMapper.ToDTO(productModel);
            return productMapper.ToViewModel(productDTO);
        }

        public async Task<IEnumerable<ProductViewModel>> SearchForProducts(SearchFor searchTerm)
        {
            IEnumerable<ProductModel> products;

            if (searchTerm.InTitle)
            {
                products = await productDAO.SearchForProductsByName(searchTerm.SearchTerm);
            }
            else if (searchTerm.InDescription)
            {
                products = await productDAO.SearchForProductsByDescription(searchTerm.SearchTerm);
            }
            else
            {
                products = await productDAO.GetAllProducts();
            }

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                ProductDTO productDTO = productMapper.ToDTO(product);
                productViewModels.Add(productMapper.ToViewModel(productDTO));
            }

            return productViewModels;
        }

        public async Task UpdateProduct(ProductViewModel product)
        {
            var productDTO = productMapper.ToDTO(product);
            var productModel = productMapper.ToModel(productDTO);
            await productDAO.UpdateProduct(productModel);
        }
    }
}
