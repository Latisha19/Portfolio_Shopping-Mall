using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCCC.Models
{
    public class DBmanager
    {
        private readonly string ConnStr = ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString;

        public List<Orders> GetOrders()
        {
            List<Orders> orders = new List<Orders>();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Orders");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Orders order = new Orders
                    {
                        OrderId = reader.GetInt32(reader.GetOrdinal("orderId")),
                        CategoryId = reader.GetString(reader.GetOrdinal("categoryId")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Price = reader.GetInt32(reader.GetOrdinal("price")),
                        Customer = reader.GetString(reader.GetOrdinal("customer")),
                        Quantity = reader.GetInt32(reader.GetOrdinal("quantity"))
                    };
                    orders.Add(order);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return orders;
        }

        public void CreateOrder(Orders order)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("" +
                @"INSERT INTO dbo.Orders (categoryId, ""name"", price, customer, quantity)
                    VALUES (@categoryId, @name, @price, @customer, @quantity)");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@categoryId", order.CategoryId));
            sqlCommand.Parameters.Add(new SqlParameter("@name", order.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@price", order.Price));
            sqlCommand.Parameters.Add(new SqlParameter("@customer", order.Customer));
            sqlCommand.Parameters.Add(new SqlParameter("@quantity", order.Quantity));
            sqlConnection.Open();

            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }

        public Orders GetOrderById(int orderId)
        {
            Orders order = new Orders();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Orders WHERE orderId = @orderId");
            sqlCommand.Parameters.Add(new SqlParameter("@orderId", orderId));
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    order = new Orders
                    {
                        OrderId = reader.GetInt32(reader.GetOrdinal("orderId")),
                        CategoryId = reader.GetString(reader.GetOrdinal("categoryId")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Price = reader.GetInt32(reader.GetOrdinal("price")),
                        Customer = reader.GetString(reader.GetOrdinal("customer")),
                        Quantity = reader.GetInt32(reader.GetOrdinal("quantity"))
                    };
                }
            }
            else
            {
                Console.WriteLine("找不到該筆資料");
            }
            sqlConnection.Close();
            return order;
        }

        public void UpdateOrder(Orders order)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("" +
                @"UPDATE dbo.Orders
                    SET categoryId = @categoryId, ""name"" = @name, price = @price, 
                        customer = @customer, quantity = @quantity
                    WHERE orderId = @orderId");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@orderId", order.OrderId));
            sqlCommand.Parameters.Add(new SqlParameter("@categoryId", order.CategoryId));
            sqlCommand.Parameters.Add(new SqlParameter("@name", order.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@price", order.Price));
            sqlCommand.Parameters.Add(new SqlParameter("@customer", order.Customer));
            sqlCommand.Parameters.Add(new SqlParameter("@quantity", order.Quantity));
            sqlConnection.Open();

            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }

        public void DeleteOrder(int orderId)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM dbo.Orders WHERE orderId = @orderId");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@orderId", orderId));
            sqlConnection.Open();

            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }
    }
}