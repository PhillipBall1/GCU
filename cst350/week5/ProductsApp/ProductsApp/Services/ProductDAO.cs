using ProductsApp.Models;
using System.Data.SqlClient;

namespace ProductsApp.Services
{
    public class ProductDAO : IProductDAO
    {
        private readonly string connectionString;

        public ProductDAO(IConfiguration config)
        {
            connectionString = config["SQLConnection:DefaultConnection"];
        }

        public async Task<int> AddProduct(ProductModel product)
        {
            string query = "INSERT INTO Products (Name, Price, Description, CreatedAt, ImageURL) " +
                           "OUTPUT INSERTED.Id " +
                           "VALUES (@Name, @Price, @Description, @CreatedAt, @ImageURL)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@CreatedAt", product.CreatedAt);
                cmd.Parameters.AddWithValue("@ImageURL", product.ImageURL);

                await conn.OpenAsync();
                return Convert.ToInt32(await cmd.ExecuteScalarAsync());
            }
        }

        public async Task DeleteProduct(ProductModel product)
        {
            string query = "DELETE FROM Products WHERE ID = @Id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", product.Id);
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            string query = "SELECT ID, Name, Price, Description, CreatedAt, ImageURL FROM Products";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                await conn.OpenAsync();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        products.Add(MapToProduct(reader));
                    }
                }
            }
            return products;
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            string query = "SELECT ID, Name, Price, Description, CreatedAt, ImageURL FROM Products WHERE ID = @Id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                await conn.OpenAsync();

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return MapToProduct(reader);
                    }
                }
            }
            return null;
        }

        public async Task<IEnumerable<ProductModel>> SearchForProductsByName(string searchTerm)
        {
            List<ProductModel> products = new List<ProductModel>();
            string query = "SELECT ID, Name, Price, Description, CreatedAt, ImageURL FROM Products " +
                           "WHERE Name LIKE @SearchTerm";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                await conn.OpenAsync();

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        products.Add(MapToProduct(reader));
                    }
                }
            }
            return products;
        }

        public async Task<IEnumerable<ProductModel>> SearchForProductsByDescription(string searchTerm)
        {
            List<ProductModel> products = new List<ProductModel>();
            string query = "SELECT ID, Name, Price, Description, CreatedAt, ImageURL FROM Products " +
                           "WHERE Description LIKE @SearchTerm";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                await conn.OpenAsync();

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        products.Add(MapToProduct(reader));
                    }
                }
            }
            return products;
        }

        public async Task UpdateProduct(ProductModel product)
        {
            string query = "UPDATE Products SET Name = @Name, Price = @Price, Description = @Description, " +
                           "CreatedAt = @CreatedAt, ImageURL = @ImageURL WHERE ID = @Id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", product.Id);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@CreatedAt", product.CreatedAt);
                cmd.Parameters.AddWithValue("@ImageURL", product.ImageURL);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        private ProductModel MapToProduct(SqlDataReader reader)
        {
            return new ProductModel
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetDecimal(2),
                Description = reader.GetString(3),
                CreatedAt = reader.GetDateTime(4),
                ImageURL = reader.GetString(5)
            };
        }
    }
}
