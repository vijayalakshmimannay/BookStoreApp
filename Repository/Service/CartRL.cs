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
    public class CartRL : ICartRL
    {
        public CartRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        SqlConnection sqlConnection;
        SqlDataReader sqlDataReader;
        List<GetCartModel> cart = new List<GetCartModel>();
        public CartModel AddCart(CartModel cart, int UserId)
        {
            try
            {
                sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("AddToCart", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId ", cart.BookId);
                    cmd.Parameters.AddWithValue("@BookQuantity ", cart.BookQuantity);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result != 0)
                    {
                        return cart;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CartModel UpdateCart(int CartId, CartModel cart, int UserId)
        {
            try
            {
                sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("UpdateCart", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CartId ", CartId);
                    cmd.Parameters.AddWithValue("@BookQuantity ", cart.BookQuantity);
                    cmd.Parameters.AddWithValue("@BookId ", cart.BookId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result != 0)
                    {
                        return cart;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string RemoveCart(int CartId)
        {
            try
            {
                sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("RemoveCart", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CartId ", CartId);


                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result != 0)
                    {
                        return "Remove Cart";
                    }
                    else
                    {
                        return "Failed";
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<CartModel> GetAllCart(int UserId)
        {
            List<CartModel> cartModel = new List<CartModel>();

            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
          
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();

                    String query = "SELECT CartId, Book_Quantity, BookId FROM Cart WHERE UserId = '" + UserId + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        cartModel.Add(new CartModel()
                        {
                            BookId = (int)sqlDataReader["BookId"],
                            BookQuantity = (int)sqlDataReader["Book_Quantity"]


                        });
                    }
                    return cartModel;
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
    }
}

