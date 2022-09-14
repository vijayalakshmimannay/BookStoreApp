USE BookStoreDB

CREATE TABLE Orders(
	OrderId int identity(1,1) primary key,
	OrderQty int not null,
	TotalPrice float not null,
	OrderDate Date not null,
	ID INT NOT NULL FOREIGN KEY REFERENCES Users(ID),
	BookId INT NOT NULL FOREIGN KEY REFERENCES Book(BookId),
	AddressID int not null FOREIGN KEY REFERENCES AddressTable(AddressID)
	)

	ALTER TABLE Orders ADD CartId int not null FOREIGN KEY REFERENCES Cart(CartId) ;
SELECT * FROM Orders

ALTER TABLE Orders ADD OrderDate varchar(max)


--------Add Order --------
GO
CREATE PROCEDURE OrderTable
		@CartId int,
		@AddressID int,
		@OrderDate varchar(Max),
		@ID int
AS
	BEGIN try
		
		DECLARE @OrderQty int = (SELECT Book_Quantity FROM Cart WHERE  CartId = @CartId)
		Declare @Quantity int = (SELECT BookQuantity FROM Book bt Inner Join Cart ct ON bt.BookId = ct.BookId WHERE ct.CartId = @CartId)
		DECLARE @BookID int = (SELECT bt.BookId FROM Book bt Inner Join Cart ct ON bt.BookId = ct.BookId WHERE ct.CartId = @CartId)
		DECLARE @TotalPrice int = (SELECT DiscountPrice FROM Book WHERE BookId = @BookId)
		IF (@OrderQty <= @Quantity)
		BEGIN
			INSERT INTO Orders
			(
				OrderQty,
				AddressID,
				BookId,
				TotalPrice,
				OrderDate,
				CartId,
				ID
			)
			VALUES
			(
				@OrderQty,
				@AddressID,
				@BookId,
				@TotalPrice * @OrderQty,
				@OrderDate,
				@CartId,
				@ID
			)
	BEGIN
		UPDATE Book
		SET BookQuantity = BookQuantity - @OrderQty
		WHERE BookId = @BookId
	END
	BEGIN
		DELETE FROM Cart WHERE BookId = @BookID
	END
	END
	END try
	BEGIN catch
	END catch

	--------Delete Order --------

	GO
CREATE PROCEDURE DeleteFromOrders
		@OrderId int
AS
	BEGIN
	DECLARE @OrderQty int = (SELECT OrderQty FROM Orders WHERE OrderId = @OrderId)
	DECLARE @BookId int = (SELECT BookId FROM Orders WHERE OrderId = @OrderId)
		BEGIN
			UPDATE Book
			SET BookQuantity = BookQuantity + @OrderQty
			WHERE BookID = @BookID
		END
		BEGIN
			DELETE FROM Orders
			WHERE OrderId = @OrderId
		END
	END