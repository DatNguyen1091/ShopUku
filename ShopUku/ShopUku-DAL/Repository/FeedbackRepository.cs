using Microsoft.Extensions.Options;
using ShopUku_DAL.Data;
using ShopUku_DAL.Model;
using System.Data.SqlClient;

namespace ShopUku_DAL.Repository
{
    public class FeedbackRepository
    {
        private readonly Connection _connection;
        public FeedbackRepository(IOptions<Connection> connection)
        {
            _connection = connection.Value;
        }

        public List<Feedback> GetAll(int? page)
        {
            List<Feedback> feedback = new List<Feedback>();
            var pageSize = 10;
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var offset = (pageIndex - 1) * pageSize;
                using (SqlCommand command = new SqlCommand("SELECT * FROM Feedback ORDER BY id OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY", connection))
                {
                    command.Parameters.AddWithValue("@offset", offset);
                    command.Parameters.AddWithValue("@pageSize", pageSize);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Feedback model = new Feedback();
                            model.id = (int)reader["id"];
                            model.name = (string)reader["name"];
                            model.email = (string)reader["email"];
                            model.subject = (string)reader["subject"];
                            model.message = (string)reader["message"];
                            model.createdAt = (DateTime)reader["createdAt"];
                            feedback.Add(model);
                        }
                    }
                }
                connection.Close();
            }
            return feedback.ToList();
        }

        public Feedback GetById(int id)
        {
            Feedback model = new Feedback();
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Feedback WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        model.id = reader.GetInt32(0);
                        model.name = reader.GetString(1);
                        model.email = reader.GetString(2);
                        model.subject = reader.GetString(3);
                        model.message = reader.GetString(4);
                        model.createdAt = reader.GetDateTime(5);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return model;
        }

        public Feedback Create(Feedback model)
        {
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                var query = "INSERT INTO Feedback ( name, email, subject, message ) VALUES ( @names, @email, @subject, @message )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", model.name);
                    command.Parameters.AddWithValue("@email", model.email);
                    command.Parameters.AddWithValue("@subject", model.subject);
                    command.Parameters.AddWithValue("@message", model.message);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return model;
            }
        }

        public string Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Feedback WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rows = command.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        return "Brand deleted successfully.";
                    }
                }
                connection.Close();
            }
            return "Failed to delete brand.";
        }
    }
}
