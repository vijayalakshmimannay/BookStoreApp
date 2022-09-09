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
    public class WishListRL : IWishListRL
    {
        public WishListRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        SqlConnection sqlConnection;
        public WishListModel AddWishList(WishListModel wish, int UserId)
        {
            try
            {
                sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("AddWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId ", wish.BookId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result != 0)
                    {
                        return wish;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
