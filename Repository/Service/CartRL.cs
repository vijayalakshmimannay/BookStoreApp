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
        private readonly IConfiguration configuration;
        public CartRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public CartModel AddCart(CartModel cart, int UserId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:BookStore"]))
                {
                    SqlCommand cmd = new SqlCommand("AddToCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId ", cart.BookId);
                    cmd.Parameters.AddWithValue("@BookQuantity ", cart.BookQuantity);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();

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
    }
}
