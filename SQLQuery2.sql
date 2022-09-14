CREATE DATABASE BookStoreDB;
use BookStoreDB

CREATE PROCEDURE [dbo].[Pcreate]
    @FULLNAME  VARCHAR(255),
    @EMAILId VARCHAR(255),
    @PASSWORD VARCHAR(255),
    @MobileNumber VARCHAR(255)
AS
BEGIN   
    CREATE TABLE [dbo].[@Register]
    (
        [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
        [@FULLNAME] VARCHAR(255) NOT NULL, 
        [@EMAILId] NVARCHAR(255) NOT NULL, 
        [@PASSWORD] NVARCHAR(255) NOT NULL, 
        [@MobileNumber] NVARCHAR(255) NOT NULL
    )
END





CREATE DATABASE BookStoreDB;
use BookStoreDB

create table Users (
	ID int IDENTITY(1,1) PRIMARY KEY (ID),
	FullName varchar(50),
	EmailId varchar(50),
	Password varchar(100),
	MobileNumber varchar(12));

	
	SELECT * FROM Users;

USE [BookStoreDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_User] @FullName VARCHAR(100), @EmailId VARCHAR(100), @Password VARCHAR(100), @MobileNumber BIGINT 
AS
BEGIN
INSERT INTO Users(FullName,EmailId,Password,MobileNumber) VALUES (@FullName, @EmailId, @Password, @MobileNumber)
END








        public string AdminLogin(LoginModel loginModel)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
            {
                try
                {
                    SqlCommand command = new SqlCommand("AdminLogin", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();

                    command.Parameters.AddWithValue("@EmailId", loginModel.EmailId);
                    command.Parameters.AddWithValue("@Password", loginModel.Password);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string query = "SELECT AdminId FROM AdminTable WHERE EmailId = '" + result + "'";
                        SqlCommand cmd = new SqlCommand(query, sqlConnection);
                        string Id = cmd.ExecuteScalar().ToString();
                        long ID = Int64.Parse((string)cmd.ExecuteScalar());
                        var Token = GenerateSecurityToken(result.ToString(), ID);

                        return Token;
                    }
                    else
                    {
                        return null;
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
