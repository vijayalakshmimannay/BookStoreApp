USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[AdminLogin]    Script Date: 10-09-2022 08:29:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AdminLogin] @EmailId VARCHAR(100), @Password VARCHAR (100)
AS
BEGIN
SELECT EmailId,Password FROM AdminTable WHERE EmailId= @EmailId AND Password=@Password
END
