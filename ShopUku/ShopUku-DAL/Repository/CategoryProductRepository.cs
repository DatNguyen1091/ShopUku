using Microsoft.Extensions.Options;
using ShopUku_DAL.Data;
using ShopUku_DAL.Model;
using System.Data.SqlClient;

namespace ShopUku_DAL.Repository
{
    public class CategoryProductRepository
    {
        private readonly Connection _connection;
        public CategoryProductRepository(IOptions<Connection> connection)
        {
            _connection = connection.Value;
        }

        public List<CategoryProduct> GetCategoryProduct()
        {
            List<CategoryProduct> listCatePro = new List<CategoryProduct>();
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();

                var query = "SELECT c.*, p.id AS productId, p.name AS productName, p.description, p.price, p.oldPrice, " +
                   "p.imageUrl, p.quantity, p.categoryId, p.isDeleted AS productIsDeleted, " +
                   "p.createdAt AS productCreatedAt, p.updatedAt AS productUpdatedAt " +
                   "FROM Categories AS c " +
                   "LEFT JOIN Products p ON c.id = p.categoryId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@CateId", CateId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CategoryProduct Category = new CategoryProduct
                            {
                                Category = new Categories
                                {
                                    id = (int)reader["id"],
                                    name = (string)reader["name"],
                                    isDeleted = (bool)reader["isDeleted"],
                                    createdAt = (DateTime)reader["createdAt"],
                                    updatedAt = (DateTime)reader["updatedAt"]
                                },
                                products = null
                            };
                            if (reader["CategoryId"] != DBNull.Value)
                            {
                                Category.products = new Products
                                {
                                    id = (int)reader["productId"],
                                    name = (string)reader["productName"],
                                    description = (string)reader["description"],
                                    price = (decimal)reader["price"],
                                    oldPrice = (decimal)reader["oldPrice"],
                                    imageUrl = (string)reader["imageUrl"],
                                    quantity = (int)reader["quantity"],
                                    categoryId = (int)reader["categoryId"],
                                    isDeleted = (bool)reader["productIsDeleted"],
                                    createdAt = (DateTime)reader["productCreatedAt"],
                                    updatedAt = (DateTime)reader["productUpdatedAt"]
                                };
                            }
                            listCatePro.Add(Category);
                        }
                    }
                }
                connection.Close();
            }
            return listCatePro.ToList();
        }

        public List<CategoryProduct> GetCategoryProductByCateId(int CateId)
        {
            List<CategoryProduct> listCatePro = new List<CategoryProduct>();
            using (SqlConnection connection = new SqlConnection(_connection.SQLString))
            {
                connection.Open();
                
                var query = "SELECT c.*, p.id AS productId, p.name AS productName, p.description, p.price, p.oldPrice, " +
                    "p.imageUrl, p.quantity, p.categoryId, p.isDeleted AS productIsDeleted, " +
                    "p.createdAt AS productCreatedAt, p.updatedAt AS productUpdatedAt " +
                    "FROM Categories AS c " +
                    "LEFT JOIN Products p ON c.id = p.categoryId " +
                    "WHERE c.id = @CateId;";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CateId", CateId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CategoryProduct Category = new CategoryProduct
                            {
                                Category = new Categories
                                {
                                    id = (int)reader["id"],
                                    name = (string)reader["name"],
                                    isDeleted = (bool)reader["isDeleted"],
                                    createdAt = (DateTime)reader["createdAt"],
                                    updatedAt = (DateTime)reader["updatedAt"]
                                },
                                products = null
                            };
                            if (reader["CategoryId"] != DBNull.Value)
                            {
                                Category.products = new Products
                                {
                                    id = (int)reader["productId"],
                                    name = (string)reader["productName"],
                                    description = (string)reader["description"],
                                    price = (decimal)reader["price"],
                                    oldPrice = (decimal)reader["oldPrice"],
                                    imageUrl = (string)reader["imageUrl"],
                                    quantity = (int)reader["quantity"],
                                    categoryId = (int)reader["categoryId"],
                                    isDeleted = (bool)reader["productIsDeleted"],
                                    createdAt = (DateTime)reader["productCreatedAt"],
                                    updatedAt = (DateTime)reader["productUpdatedAt"]
                                };
                            }
                            listCatePro.Add(Category);
                        }
                    }
                }
                connection.Close();
            }
            return listCatePro.ToList();
        }

    }
}
