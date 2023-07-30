using Microsoft.Extensions.Options;
using ShopUku_DAL.Data;
using ShopUku_DAL.Model;
using System.Data.SqlClient;

namespace ShopUku_DAL.Repository
{
    public class ProductRepository
    {
        private readonly Connection _connection;
        public ProductRepository(IOptions<Connection> connection)
        {
            _connection = connection.Value;
        }

        public List<Products> GetAll(int? page)
        {
            List<Products> products = new List<Products>();
            var pageSize = 6;
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var offset = (pageIndex - 1) * pageSize;
                using (SqlCommand command = new SqlCommand("SELECT * FROM Products ORDER BY id OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY", connection))
                {
                    command.Parameters.AddWithValue("@offset", offset);
                    command.Parameters.AddWithValue("@pageSize", pageSize);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products model = new Products();
                            model.id = (int)reader["id"];
                            model.name = (string)reader["name"];
                            model.description = (string)reader["description"];
                            model.metaDescription = (string)reader["metaDescription"];
                            model.price = (decimal)reader["price"];
                            model.oldPrice = (decimal)reader["oldPrice"];
                            model.imageUrl = (string)reader["imageUrl"];
                            model.quantity = (int)reader["quantity"];
                            model.categoryId = (int)reader["categoryId"];
                            model.brandId = (int)reader["brandId"];
                            model.isDeleted = (bool)reader["isDeleted"];
                            model.createdAt = (DateTime)reader["createdAt"];
                            model.updatedAt = (DateTime)reader["updatedAt"];
                            products.Add(model);
                        }
                        connection.Close();
                    }
                }
            }
            return products.ToList();
        }

        public Products GetById(int id)
        {
            Products item = new Products();
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        item.id = reader.GetInt32(0);
                        item.name = reader.GetString(1);
                        item.description = reader.GetString(2);
                        item.metaDescription = reader.GetString(3);
                        item.price = reader.GetDecimal(4);
                        item.oldPrice = reader.GetDecimal(5);
                        item.imageUrl = reader.GetString(6);
                        item.quantity = reader.GetInt32(7);
                        item.categoryId = reader.GetInt32(8);
                        item.brandId = reader.GetInt32(9);
                        item.isDeleted = reader.GetBoolean(10);
                        item.createdAt = reader.GetDateTime(11);
                        item.updatedAt = reader.GetDateTime(12);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return item;
        }

        public Products Create(Products model)
        {
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var query = "INSERT INTO Products (name, description, metaDescription, price, oldPrice, imageUrl, quantity, categoryId, brandId, isDeleted) VALUES (@name, @description, @metaDescription, @price, @oldPrice, @imageUrl, @quantity, @categoryId, @brandId, @isDeleted)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", model.name);
                    command.Parameters.AddWithValue("@description", model.description);
                    command.Parameters.AddWithValue("@metaDescription", model.metaDescription);
                    command.Parameters.AddWithValue("@price", model.price);
                    command.Parameters.AddWithValue("@oldPrice", model.oldPrice);
                    command.Parameters.AddWithValue("@quantity", model.quantity);
                    command.Parameters.AddWithValue("@categoryId", model.categoryId);
                    command.Parameters.AddWithValue("@brandId", model.brandId);
                    command.Parameters.AddWithValue("@imageUrl", model.imageUrl);
                    command.Parameters.AddWithValue("@isDeleted", model.isDeleted);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return model;
            }
        }

        public Products Update(int id, Products model)
        {
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var query = "UPDATE Products SET name = @name, description = @description, metaDescription = @metaDescription, price = @price, oldPrice = @oldPrice, imageUrl = @imageUrl, quantity = @quantity, categoryId = @categoryId, brandId = @brandId, isDeleted = @isDeleted WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", model.name);
                    command.Parameters.AddWithValue("@description", model.description);
                    command.Parameters.AddWithValue("@metaDescription", model.metaDescription);
                    command.Parameters.AddWithValue("@price", model.price);
                    command.Parameters.AddWithValue("@oldPrice", model.oldPrice);
                    command.Parameters.AddWithValue("@quantity", model.quantity);
                    command.Parameters.AddWithValue("@categoryId", model.categoryId);
                    command.Parameters.AddWithValue("@brandId", model.brandId);
                    command.Parameters.AddWithValue("@imageUrl", model.imageUrl);
                    command.Parameters.AddWithValue("@isDeleted", model.isDeleted);
                    int rows = command.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new Exception("Update failed");
                    }
                }
                return model;
            }
        }

        public string Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Products WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rows = command.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        return "Item deleted successfully.";
                    }
                }
                connection.Close();
            }
            return "Failed to delete item.";
        }
    }
}
