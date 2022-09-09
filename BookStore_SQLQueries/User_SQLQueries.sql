CREATE DATABASE BookStoreDB;
use BookStoreDB

----Create Table for Users -----

create table Users (
	ID int IDENTITY(1,1) PRIMARY KEY (ID),
	FullName varchar(50),
	EmailId varchar(50),
	Password varchar(100),
	MobileNumber BIGINT);

	
	SELECT * FROM Users;

USE [BookStoreDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Register] @FullName VARCHAR(100), @EmailId VARCHAR(100), @Password VARCHAR(100), @MobileNumber BIGINT 
AS
BEGIN
INSERT INTO Users(FullName,EmailId,Password,MobileNumber) VALUES (@FullName, @EmailId, @Password, @MobileNumber)
END

Go
CREATE PROCEDURE [Login] @EmailId VARCHAR(100), @Password VARCHAR (100)
AS
BEGIN
SELECT EmailId,Password FROM Users WHERE EmailId= @EmailId AND Password=@Password
END

CREATE PROCEDURE ForgetPassword
(
@EmailId varchar(180)
)
As
Begin
	Select * from Users where EmailId=@EmailId
End;


CREATE PROCEDURE ResetPassword
	@EmailId varchar(100),
	@Password varchar(100)
AS
BEGIN
	UPDATE Users SET Password = @Password WHERE EmailId = @EmailId;
END