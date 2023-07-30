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

        public Users GetUserByUsername(string username)
        {
            Users? account = null;
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE username = @username", connection))
                {
                    command.Parameters.AddWithValue("@username", username);
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

        public string Delete(int id)
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
