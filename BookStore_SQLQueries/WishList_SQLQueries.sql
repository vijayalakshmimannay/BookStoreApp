use BookStoreDB

----Create Table for WishList -----

Create table WishList
(
	WishListId int identity(1,1) not null primary key,
	UserId int foreign key references Users(ID) on delete no action,
	BookId int foreign key references Book(BookId) on delete no action
);

Select * from WishList

----------- Store procedure for Add Wishlist ----------
CREATE PROCEDURE AddWishList
(@UserId int,@BookId int)
As
Begin
 INSERT INTO WishList VALUES (@UserId,@BookId);
END;