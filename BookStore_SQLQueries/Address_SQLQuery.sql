
use BookStoreDB;

----Create AddressTable  -----

CREATE TABLE AddressTable
(
	AddressID int identity primary key,
	Address varchar(Max) Not Null,
	City varchar(100) Not Null,
	State varchar(100) Not Null,
	TypeID int Not Null,
	UserID int Not Null
)
SELECT * FROM AddressTable

----Create Table AddressType -----

CREATE TABLE AddressType
(
	TypeID int Not Null identity(1,1) primary key,
	Type varchar(255)
)

INSERT INTO AddressType
VALUES ('Home')

INSERT INTO AddressType
VALUES ('Office')

INSERT INTO AddressType
VALUES ('Other')

SELECT * FROM AddressTable

----------- Store procedure for Add Address ----------

GO
CREATE PROCEDURE InsertIntoAddressTable
		@Address varchar(max),
		@City varchar(100),
		@State varchar(100),
		@TypeID int,
		@UserID int
AS
BEGIN
INSERT into AddressTable(Address,City,State,TypeID,UserID)values(@Address,@City,@State,@TypeID,@UserID)
END

----------- Store procedure for Update Address ----------

GO
CREATE PROCEDURE UpdateAddressTable
		@AddressID int,
		@Address varchar(Max),
		@City varchar(100),
		@State varchar(100)
AS
	BEGIN
		UPDATE AddressTable
		SET
			Address = @Address,
			City = @City,
			State = @State
		WHERE
			AddressID = @AddressID
	END