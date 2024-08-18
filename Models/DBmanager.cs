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
                        Category = reader.GetString(reader.GetOrdinal("category")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Price = reader.GetInt32(reader.GetOrdinal("price")),
                        Customer = reader.GetString(reader.GetOrdinal("customer")),
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
                @"INSERT INTO dbo.Orders (category, ""name"", price, customer)
                    VALUES (@category, @name, @price, @customer)");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@category", order.Category));
            sqlCommand.Parameters.Add(new SqlParameter("@name", order.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@price", order.Price));
            sqlCommand.Parameters.Add(new SqlParameter("@customer", order.Customer));
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
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
                        Category = reader.GetString(reader.GetOrdinal("category")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Price = reader.GetInt32(reader.GetOrdinal("price")),
                        Customer = reader.GetString(reader.GetOrdinal("customer")),
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
                    SET category = @category, ""name"" = @name, price = @price, customer = @customer
                    WHERE orderId = @orderId");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@orderId", order.OrderId));
            sqlCommand.Parameters.Add(new SqlParameter("@category", order.Category));
            sqlCommand.Parameters.Add(new SqlParameter("@name", order.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@price", order.Price));
            sqlCommand.Parameters.Add(new SqlParameter("@customer", order.Customer));
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }
    }
}