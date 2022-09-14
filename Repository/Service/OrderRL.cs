using Microsoft.Extensions.Configuration;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Service
{
    public class OrderRL : IOrderRL
    {
        
        public OrderRL(IConfiguration configuration)
        {
            this.Configuration = configuration;

        }
        public IConfiguration Configuration { get; }
        SqlConnection sqlConnection;
        SqlDataReader sqlDataReader;
        List<GetOrderModel> orders=new List<GetOrderModel>();

        public bool AddOrder(OrderModel order, int ID)
        {

            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
                try
                {

                    SqlCommand sqlCommand = new SqlCommand("OrderTable", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@CartId", order.CartId);
                    sqlCommand.Parameters.AddWithValue("@AddressID", order.AddressID);
                    sqlCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now.ToString());
                    sqlCommand.Parameters.AddWithValue("@ID", ID);

                    var result = sqlCommand.ExecuteNonQuery();

                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
        }


        public bool CancelOrder(int OrderID)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("DeleteFromOrders", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@OrderId", OrderID);

                    int result = sqlCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
        }

        public IEnumerable<GetOrderModel> GetAllOrders()
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
                try
                {
                    sqlConnection.Open();
                    String query = "SELECT OrderId, OrderQty, AddressID, BookId, ID, TotalPrice, OrderDate FROM Orders";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        orders.Add(new GetOrderModel()
                        {
                            OrderID = sqlDataReader["OrderId"].ToString(),
                            OrderQty = sqlDataReader["OrderQty"].ToString(),
                            AddressID = sqlDataReader["AddressID"].ToString(),
                            BookID = sqlDataReader["BookId"].ToString(),
                            ID = sqlDataReader["ID"].ToString(),
                            TotalPrice = sqlDataReader["TotalPrice"].ToString(),
                            OrderDate = sqlDataReader["OrderDate"].ToString()
                        });
                    }
                    return orders;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
        }




    }
}
