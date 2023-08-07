using Microsoft.Extensions.Options;
using ShopUku_DAL.Data;
using ShopUku_DAL.Model;
using System.Data.SqlClient;

namespace ShopUku_DAL.Repository
{
    public class UserRepository
    {
        private readonly Connection _connection;
        public UserRepository(IOptions<Connection> connection)
        {
            _connection = connection.Value;
        }

        public List<Users> GetAll(int? page)
        {
            List<Users> user = new List<Users>();
            var pageSize = 10;
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var offset = (pageIndex - 1) * pageSize;
                using (SqlCommand command = new SqlCommand("SELECT * FROM Users ORDER BY id OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY", connection))
                {
                    command.Parameters.AddWithValue("@offset", offset);
                    command.Parameters.AddWithValue("@pageSize", pageSize);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users model = new Users();
                            model.id = (int)reader["id"];
                            model.username = (string)reader["username"];
                            model.password = (string)reader["password"];
                            model.email = (string)reader["email"];
                            model.isAdmin = (bool)reader["isAdmin"];
                            user.Add(model);
                        }
                    }
                }
                connection.Close();
            }
            return user.ToList();
        }

        public Users GetUser(string username, string password)
        {
            Users? account = null;
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE username = @username AND password = @password", connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        account = new Users
                        {
                            id = reader.GetInt32(0),
                            username = reader.GetString(1),
                            password = reader.GetString(2),
                            email = reader.GetString(3),
                            isAdmin = reader.GetBoolean(4)
                        };
                    }
                    reader.Close();
                }
            }
            return account!;
        }

        public Users CreatNewUserAcc(Users acc)
        {
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var query = "INSERT INTO Users ( username, password, email, isAdmin) VALUES ( @username, @password, @email, @isAdmin)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", acc.username);
                    command.Parameters.AddWithValue("@password", acc.password);
                    command.Parameters.AddWithValue("@email", acc.email);
                    command.Parameters.AddWithValue("@isAdmin", acc.isAdmin);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return acc;
            }
        }

        public Users UpdateUser(int id, Users acc)
        {
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var query = "UPDATE Users SET isAdmin = @isAdmin WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@isAdmin", acc.isAdmin);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return acc;
            }
        }

        public Users UpdateUserPass(Users acc)
        {
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var query = "UPDATE Users SET password = @password WHERE username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", acc.username);
                    command.Parameters.AddWithValue("@password", acc.password);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return acc;
            }
        }

        public string DeleteUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Users WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rows = command.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        return "User deleted successfully.";
                    }
                }
                connection.Close();
            }
            return "Failed to delete user.";
        }
    }
}
