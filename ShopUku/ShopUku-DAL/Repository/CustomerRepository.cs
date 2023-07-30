using Microsoft.Extensions.Options;
using ShopUku_DAL.Data;
using ShopUku_DAL.Model;
using System.Data.SqlClient;

namespace ShopUku_DAL.Repository
{
    public class CustomerRepository
    {
        private readonly Connection _connection;
        public CustomerRepository(IOptions<Connection> connection)
        {
            _connection = connection.Value;
        }

        public List<Customers> GetAll(int? page)
        {
            List<Customers> customers = new List<Customers>();
            var pageSize = 10;
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var offset = (pageIndex - 1) * pageSize;
                using (SqlCommand command = new SqlCommand("SELECT * FROM Customers ORDER BY id OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY", connection))
                {
                    command.Parameters.AddWithValue("@offset", offset);
                    command.Parameters.AddWithValue("@pageSize", pageSize);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customers model = new Customers();
                            model.id = (int)reader["id"];
                            model.fullName = (string)reader["fullName"];
                            model.emailAddress = (string)reader["emailAddress"];
                            model.phoneNumber = (string)reader["phoneNumber"];
                            model.addressLine = (string)reader["addressLine"];
                            model.city = (string)reader["city"];
                            model.country = (string)reader["country"];
                            model.isDeleted = (bool)reader["isDeleted"];
                            model.createdAt = (DateTime)reader["createdAt"];
                            model.updatedAt = (DateTime)reader["updatedAt"];
                            customers.Add(model);
                        }
                    }
                }
                connection.Close();
            }
            return customers.ToList();
        }

        public Customers GetById(int id)
        {
            Customers model = new Customers();
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Customers WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        model.id = reader.GetInt32(0);
                        model.fullName = reader.GetString(1);
                        model.emailAddress = reader.GetString(2);
                        model.phoneNumber = reader.GetString(3);
                        model.addressLine = reader.GetString(4);
                        model.city = reader.GetString(5);
                        model.country = reader.GetString(6);;
                        model.isDeleted = reader.GetBoolean(7);
                        model.createdAt = reader.GetDateTime(8);
                        model.updatedAt = reader.GetDateTime(9);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return model;
        }

        public Customers Create(Customers model)
        {
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var query = "INSERT INTO Customers ( fullName, emailAddress, phoneNumber, addressLine, city, country, isDeleted) VALUES ( @fullName, @emailAddress, @phoneNumber, @addressLine, @city, @country, @isDeleted)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fullName", model.fullName);
                    command.Parameters.AddWithValue("@emailAddress", model.emailAddress);
                    command.Parameters.AddWithValue("@phoneNumber", model.phoneNumber);
                    command.Parameters.AddWithValue("@addressLine", model.addressLine);
                    command.Parameters.AddWithValue("@city", model.city);
                    command.Parameters.AddWithValue("@country", model.country);
                    command.Parameters.AddWithValue("@isDeleted", model.isDeleted);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return model;
            }
        }

        public Customers Update(int id, Customers model)
        {
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var query = "UPDATE Customers SET fullName = @fullName, emailAddress = @emailAddress, phoneNumber = @phoneNumber, addressLine = @addressLine, city = @city, country = @country, isDeleted = @isDeleted WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@fullName", model.fullName);
                    command.Parameters.AddWithValue("@emailAddress", model.emailAddress);
                    command.Parameters.AddWithValue("@phoneNumber", model.phoneNumber);
                    command.Parameters.AddWithValue("@addressLine", model.addressLine);
                    command.Parameters.AddWithValue("@city", model.city);
                    command.Parameters.AddWithValue("@country", model.country); 
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
                using (SqlCommand command = new SqlCommand("DELETE FROM Customers WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rows = command.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        return "Deleted successfully.";
                    }
                }
                connection.Close();
            }
            return "Failed to delete.";
        }
    }
}
