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
    public class AddressRL : IAddressRL
    {

        public AddressRL(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        SqlConnection sqlConnection;
        private SqlDataReader sqlDataReader;
        List<GetAddressModel> address = new List<GetAddressModel>();

        public bool AddAddress(AddressModel addressModel, int UserID)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
                try
                {

                    SqlCommand command = new SqlCommand("InsertIntoAddressTable", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();

                    command.Parameters.AddWithValue("@Address", addressModel.Address);
                    command.Parameters.AddWithValue("@City", addressModel.City);
                    command.Parameters.AddWithValue("@State", addressModel.State);
                    command.Parameters.AddWithValue("@TypeID", addressModel.TypeID);
                    command.Parameters.AddWithValue("@UserID", UserID);

                    int result = command.ExecuteNonQuery();
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

        public bool UpdateAddress(AddressModel addressModel, int AddressID)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
                try
                {
                    SqlCommand command = new SqlCommand("UpdateAddressTable", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();

                    command.Parameters.AddWithValue("@Address", addressModel.Address);
                    command.Parameters.AddWithValue("@City", addressModel.City);
                    command.Parameters.AddWithValue("@State", addressModel.State);
                    command.Parameters.AddWithValue("@AddressID", AddressID);

                    int result = command.ExecuteNonQuery();
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

        public IEnumerable<GetAddressModel> GetAddress(int UserID)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
                try
                {
                    sqlConnection.Open();
                    String query = "SELECT AddressID, Address, City, State, TypeID FROM AddressTable WHERE UserID = '" + UserID + "'";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        address.Add(new GetAddressModel()
                        {
                            AddressID = sqlDataReader["AddressID"].ToString(),
                            Address = sqlDataReader["Address"].ToString(),
                            City = sqlDataReader["City"].ToString(),
                            State = sqlDataReader["State"].ToString(),
                            TypeID = sqlDataReader["TypeID"].ToString()
                        });
                    }
                    return address;
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
