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

----------------- Store procedure for Get Wishlist ------------------
CREATE PROCEDURE GetWishList
(@UserId int)
As
Begin

SELECT WishListId,UserId,c.BookId,BookName,AuthorName,
	DiscountPrice,ActualPrice,BookImage from WishList c join Book b on c.BookId=b.BookId 
WHERE UserId=@UserId;
END;

------------- Store procedure for Delete wishlist ----------------
create procedure DeleteWishList
(
@WishListId int,
@UserId int
)
as
begin
delete WishList where WishListId = @WishListId and UserId=@UserId;
end;


