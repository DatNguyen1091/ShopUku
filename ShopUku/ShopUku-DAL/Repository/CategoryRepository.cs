using Microsoft.Extensions.Options;
using ShopUku_DAL.Data;
using ShopUku_DAL.Model;
using System.Data.SqlClient;

namespace ShopUku_DAL.Repository
{
    public class CategoryRepository
    {
        private readonly Connection _connection;
        public CategoryRepository(IOptions<Connection> connection)
        {
            _connection = connection.Value;
        }

        public List<Categories> GetAll(int? page)
        {
            List<Categories> categories = new List<Categories>();
            int pageSize = 10;
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var offset = (pageIndex - 1) * pageSize;
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var query = "SELECT * FROM Categories ORDER BY id OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@offset", offset);
                    command.Parameters.AddWithValue("@pageSize", pageSize);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Categories model = new Categories();
                            model.id = (int)reader["id"];
                            model.name = (string)reader["name"];
                            model.description = (string)reader["description"];
                            model.isDeleted = (bool)reader["isDeleted"];
                            model.createdAt = (DateTime)reader["createdAt"];
                            model.updatedAt = (DateTime)reader["updatedAt"];
                            categories.Add(model);
                        }
                    }
                }
                connection.Close();
            }
            return categories;
        }

        public Categories GetById(int id)
        {
            Categories category = new Categories();
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Categories WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        category.id = reader.GetInt32(0);
                        category.name = reader.GetString(1);
                        category.description = reader.GetString(3);
                        category.isDeleted = reader.GetBoolean(4);
                        category.createdAt = reader.GetDateTime(5);
                        category.updatedAt = reader.GetDateTime(6);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return category;
        }

        public Categories Create(Categories model)
        {
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var query = "INSERT INTO Categories (name, description, isDeleted) VALUES (@name, @description, @isDeleted)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", model.name);
                    command.Parameters.AddWithValue("@description", model.description);
                    command.Parameters.AddWithValue("@isDeleted", model.isDeleted);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return model;
            }
        }

        public Categories Update(int id, Categories model)
        {
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var query = "UPDATE Categories SET name = @name, description = @description, isDeleted = @isDeleted WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", model.name);
                    command.Parameters.AddWithValue("@description", model.description);
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
                using (SqlCommand command = new SqlCommand("DELETE FROM Categories WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rows = command.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        return "Category deleted successfully.";
                    }
                }
                connection.Close();
            }
            return "Failed to delete category.";
        }
    }
}
