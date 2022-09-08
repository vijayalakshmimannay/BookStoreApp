use BookStoreDB;
CREATE TABLE AdminTable
(
AdminId int identity primary key,
AdminName varchar(Max) Not null,
EmailId varchar(Max) Not null,
Password varchar(Max) Not null,
AdminPhoneNo varchar(20) Not null
);

SELECT * FROM AdminTable;

ALTER TABLE AdminTable ADD Address varchar(300);

INSERT INTO AdminTable values('Admin', 'Admin@gmail.com','123456','8798789876','AndhraPradesh');


Go
CREATE PROCEDURE [AdminLogin] @EmailId VARCHAR(100), @Password VARCHAR (100)
AS
BEGIN
SELECT EmailId,Password FROM Users WHERE EmailId= @EmailId AND Password=@Password
END


