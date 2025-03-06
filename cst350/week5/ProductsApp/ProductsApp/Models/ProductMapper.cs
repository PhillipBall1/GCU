using ProductsApp.ViewModels;
using System.Reflection;

namespace ProductsApp.Models
{
    public class ProductMapper : IProductMapper
    {
        public string CurrencyFormat { get; set; } = "C";
        public string DateFormat { get; set; } = "D";
        public decimal TaxRate { get; set; } = 0.08m;

        public ProductMapper(string currencyFormat, string dateFormat, decimal taxRate)
        {
            CurrencyFormat = currencyFormat;
            DateFormat = dateFormat;
            TaxRate = taxRate;
        }

        public ProductDTO ToDTO(ProductModel model)
        {
            return new ProductDTO
            {
                Id = model.Id.ToString(),
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                CreatedAt = model.CreatedAt,
                ImageURL = model.ImageURL,
                EstimatedTax = model.Price * TaxRate,
                FormattedPrice = model.Price.ToString(CurrencyFormat)
            };
        }

        public ProductDTO ToDTO(ProductViewModel viewModel)
        {
            if(viewModel.Id == null)
            {
                return new ProductDTO
                {
                    Name = viewModel.Name,
                    Price = viewModel.Price,
                    Description = viewModel.Description,
                    CreatedAt = viewModel.CreatedAt,
                    ImageURL = viewModel.ImageURL
                };
            }

            return new ProductDTO
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Price = viewModel.Price,
                Description = viewModel.Description,
                CreatedAt = viewModel.CreatedAt,
                ImageURL = viewModel.ImageURL
            };
        }

        public ProductModel ToModel(ProductDTO dto)
        {
            if (dto.Id == null)
            {
                return new ProductModel
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Description = dto.Description,
                    CreatedAt = (DateTime)dto.CreatedAt,
                    ImageURL = dto.ImageURL ?? string.Empty
                };
            }

            return new ProductModel
            {
                Id = int.Parse(dto.Id),
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                CreatedAt = (DateTime)dto.CreatedAt,
                ImageURL = dto.ImageURL ?? string.Empty
            };
        }

        public ProductViewModel ToViewModel(ProductDTO dto)
        {
            return new ProductViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                CreatedAt = (DateTime)dto.CreatedAt,
                ImageURL = dto.ImageURL,
                EstimatedTax = dto.EstimatedTax,
                FormattedEstimatedTax = dto.EstimatedTax.ToString(CurrencyFormat),
                FormattedPrice = dto.Price.ToString(CurrencyFormat),
                FormattedDate = dto.CreatedAt?.ToString(DateFormat) ?? "N/A" 
            };
        }

    }
}
