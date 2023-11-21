using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneGUI
{
    internal class ProductsDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=cst345_milestone;";

        #region Products

        public List<Products> GetAllProducts()
        {
            List<Products> products = new List<Products>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM PRODUCTS", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Products a = new Products
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        RetailPrice = reader.GetFloat(2),
                        WholesalePrice = reader.GetFloat(3),
                        Description = reader.GetString(4),
                        CategoryID = reader.GetInt32(5),
                        VendorID = reader.GetInt32(6)
                    };

                    products.Add(a);
                }
            }

            connection.Close();

            return products;
        }

        public int AddOneProduct(Products product)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO PRODUCTS (`name`, `retail_price`, `wholesale_price`, `description`, `product_categories_id`, `vendors_id`) VALUES (@Name, @Retail, @Wholesale, @Description, @Category, @Vendor)", connection);

            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Retail", product.RetailPrice);
            command.Parameters.AddWithValue("@Wholesale", product.WholesalePrice);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@Category", product.CategoryID);
            command.Parameters.AddWithValue("@Vendor", product.VendorID);

            int newRows = command.ExecuteNonQuery();

            connection.Close();

            return newRows;
        }

        public List<Products> GetProductsBySearch(string search)
        {
            List<Products> products = new List<Products>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            string searchPhrase = "%" + search + "%";

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM PRODUCTS WHERE NAME LIKE @search";
            command.Parameters.AddWithValue("@search", searchPhrase);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Products a = new Products
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        RetailPrice = reader.GetFloat(2),
                        WholesalePrice = reader.GetFloat(3),
                        Description = reader.GetString(4),
                        CategoryID = reader.GetInt32(5),
                        VendorID = reader.GetInt32(6)
                    };

                    products.Add(a);
                }
            }

            connection.Close();

            return products;
        }

        public List<Products> GetAllProductsByCategoryID(int id)
        {
            List<Products> products = new List<Products>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM PRODUCTS WHERE product_categories_id = @categoryID";
            command.Parameters.AddWithValue("@categoryID", id);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Products a = new Products
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        RetailPrice = reader.GetFloat(2),
                        WholesalePrice = reader.GetFloat(3),
                        Description = reader.GetString(4),
                        CategoryID = reader.GetInt32(5),
                        VendorID = reader.GetInt32(6)
                    };

                    products.Add(a);
                }
            }

            connection.Close();

            return products;
        }

        public List<Products> DeleteProductByID(int id)
        {
            List<Products> products = new List<Products>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "DELETE FROM PRODUCTS WHERE id = @productID";
            command.Parameters.AddWithValue("@productID", id);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Products a = new Products
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        RetailPrice = reader.GetFloat(2),
                        WholesalePrice = reader.GetFloat(3),
                        Description = reader.GetString(4),
                        CategoryID = reader.GetInt32(5),
                        VendorID = reader.GetInt32(6)
                    };

                    products.Add(a);
                }
            }

            connection.Close();

            return GetAllProducts();
        }

#endregion

        #region Categories

        public List<ProductCategories> GetAllCategories()
        {
            List<ProductCategories> products = new List<ProductCategories>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM PRODUCT_CATEGORIES", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProductCategories a = new ProductCategories
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                    };

                    products.Add(a);
                }
            }

            connection.Close();

            return products;
        }

        public int AddOneCategory(ProductCategories category)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO PRODUCT_CATEGORIES (`type`, `description`) VALUES (@Type, @Description)", connection);

            command.Parameters.AddWithValue("@Type", category.Name);
            command.Parameters.AddWithValue("@Description", category.Description);

            int newRows = command.ExecuteNonQuery();

            connection.Close();

            return newRows;
        }

        public List<ProductCategories> GetCategoryBySearch(string search)
        {
            List<ProductCategories> products = new List<ProductCategories>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            string searchPhrase = "%" + search + "%";

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM PRODUCT_CATEGORIES WHERE TYPE LIKE @search";
            command.Parameters.AddWithValue("@search", searchPhrase);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProductCategories a = new ProductCategories
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                    };

                    products.Add(a);
                }
            }

            connection.Close();

            return products;
        }

        public List<ProductCategories> DeleteCategoryByID(int id)
        {
            List<ProductCategories> products = new List<ProductCategories>();

            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "DELETE FROM PRODUCT_CATEGORIES WHERE id = @productID";
            command.Parameters.AddWithValue("@productID", id);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProductCategories a = new ProductCategories
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                    };

                    products.Add(a);
                }
            }

            connection.Close();

            return GetAllCategories();
        }

        #endregion
    }
}
