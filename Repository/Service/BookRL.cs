using Experimental.System.Messaging;
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
    public class BookRL : IBookRL
    {
        public BookRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        SqlConnection sqlConnection;


        public bool AddBook(BookModel bookModel)
        {

            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
            {
                try
                {
                    SqlCommand command = new SqlCommand("AddBook", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    command.Parameters.AddWithValue("@BookName ", bookModel.BookName);
                    command.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    command.Parameters.AddWithValue("@Rating ", bookModel.Rating);
                    command.Parameters.AddWithValue("@RatingCount", bookModel.RatingCount);
                    command.Parameters.AddWithValue("@DiscountPrice ", bookModel.DiscountPrice);
                    command.Parameters.AddWithValue("@ActualPrice", bookModel.ActualPrice);
                    command.Parameters.AddWithValue("@Description ", bookModel.Description);
                    command.Parameters.AddWithValue("@BookImage", bookModel.BookImage);
                    command.Parameters.AddWithValue("@BookQuantity", bookModel.BookQuantity);
                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }



        }

        public List<GetAllBookModel> GetAllBooks()
        {
            List<GetAllBookModel> books = new List<GetAllBookModel>();
            try
            {
                sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("GetAllBooks", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            books.Add(new GetAllBookModel
                            {
                                BookId = Convert.ToInt32(reader["BookId"]),
                                BookName = reader["BookName"].ToString(),
                                AuthorName = reader["AuthorName"].ToString(),
                                Rating = reader["Rating"].ToString(),
                                RatingCount = Convert.ToInt32(reader["RatingCount"]),
                                DiscountPrice = reader["DiscountPrice"].ToString(),
                                ActualPrice = reader["ActualPrice"].ToString(),
                                BookImage = reader["BookImage"].ToString(),
                                BookQuantity = Convert.ToInt32(reader["BookQuantity"]),
                            });
                        }
                        sqlConnection.Close();
                        return books;
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

        public BookModel GetBookById(int BookId)
        {
            try
            {
                sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("GetBookById", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookId ", BookId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        BookModel model = new BookModel();
                        while (reader.Read())
                        {
                           //BookId = Convert.ToInt32(reader["BookId"]);
                            model.BookId = Convert.ToInt32(reader["BookId"]);
                            model.BookName = reader["BookName"].ToString();
                            model.AuthorName = reader["AuthorName"].ToString();
                            model.Rating = reader["Rating"].ToString();
                            model.RatingCount = Convert.ToInt32(reader["RatingCount"]);
                            model.DiscountPrice = reader["DiscountPrice"].ToString();
                            model.ActualPrice = reader["ActualPrice"].ToString();
                            model.BookImage = reader["BookImage"].ToString();
                            model.BookQuantity = Convert.ToInt32(reader["BookQuantity"]);

                        }
                        sqlConnection.Close();
                        return model;
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
        public bool UpdateBook(BookModel bookModel)
        {

            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
            {
                try
                {
                    SqlCommand command = new SqlCommand("UpdateBook", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();

                    command.Parameters.AddWithValue("@BookId ", bookModel.BookId);
                    command.Parameters.AddWithValue("@BookName ", bookModel.BookName);
                    command.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    command.Parameters.AddWithValue("@Rating ", bookModel.Rating);
                    command.Parameters.AddWithValue("@RatingCount", bookModel.RatingCount);
                    command.Parameters.AddWithValue("@DiscountPrice ", bookModel.DiscountPrice);
                    command.Parameters.AddWithValue("@ActualPrice", bookModel.ActualPrice);
                    command.Parameters.AddWithValue("@Description ", bookModel.Description);
                    command.Parameters.AddWithValue("@BookImage", bookModel.BookImage);
                    command.Parameters.AddWithValue("@BookQuantity", bookModel.BookQuantity);
                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public string DeleteBook(int BookId)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
            {
                try
                {

                    SqlCommand command = new SqlCommand("DeleteBook", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    command.Parameters.AddWithValue("@BookId ", BookId);
                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return "Book deleted";
                    }
                    else
                    {
                        return "Failed to delete";
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
