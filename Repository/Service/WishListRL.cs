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
        SqlDataReader sqlDataReader;
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

        public string DeleteWishList(int WishListId, int UserId)
        {
            try
            {

                sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("DeleteWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WishListId ", WishListId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result != 0)
                    {
                        return "Delete WishList";
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

        public IEnumerable<WishListModel> GetWishList(int UserId)
        {
            List<WishListModel> wishlist = new List<WishListModel>();
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
                try
                {
                    using (sqlConnection)
                    {
                        sqlConnection.Open();
                        String query = "SELECT WishListId, BookId FROM WishList WHERE UserId = '" + UserId + "'";
                        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read())
                        {
                            wishlist.Add(new WishListModel()
                            {
                                WishListId = (int)sqlDataReader["WishlistId"],
                                BookId = (int)sqlDataReader["BookId"]

                            });
                        }
                        return wishlist;
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
