use BookStoreDB;

----Create Table for Cart -----
Create Table Cart
(
CartId int identity(1,1) primary key,
Book_Quantity int default 1,
UserId int not null foreign key (UserId) references Users(ID),
BookId int not null Foreign key (BookId) references Book(BookId)
);

select * from Cart

--------------- Add to the cart ---------

CREATE PROCEDURE AddToCart
( 
  @BookQuantity int, @UserId int, @BookId int
)
AS
BEGIN
	INSERT INTO Cart(Book_Quantity,UserId,BookId)
	VALUES ( @BookQuantity,@UserId, @BookId);
END;

--------- Update BookQuantity in Cart --------

CREATE PROCEDURE UpdateCart
(
	@BookQuantity int,@BookId int,@UserId int,@CartId int
)
AS
BEGIN
UPDATE Cart set BookId=@BookId,UserId=@UserId,Book_Quantity=@BookQuantity where CartId=@CartId;
END

-------------- For Remove Books From Cart ----------

CREATE PROCEDURE RemoveCart
(
@CartId int
)
AS
BEGIN

	DELETE from Cart where CartId = @CartId;
END;